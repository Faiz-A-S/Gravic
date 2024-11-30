using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;

public class CSVReader : MonoBehaviour
{
    private string csvFilePath = ""; // Set in the Inspector
    [SerializeField] private List<string> questionList = new List<string>();
    [SerializeField] private List<string> answerListSlider1 = new List<string>();
    [SerializeField] private List<string> answerListSlider2 = new List<string>();
    [SerializeField] private List<string> answerListSlider3 = new List<string>();
    [SerializeField] private List<string> questionTitle = new List<string>();
    private GoogleSheetsImporter googleSheets;

    private Dictionary<string, List<string>> csvData;

    void Awake(){
        csvFilePath = Application.persistentDataPath + "/SoalGravic.csv";
        Debug.Log(csvFilePath);
    }

    public void ReadCSV()
    {
        // Mengelompokkan data sesuai header pada google sheet
        csvData = new Dictionary<string, List<string>>();

        string[] lines = File.ReadAllLines(csvFilePath);
        string[] headers = lines[0].Split(',');

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');

            for (int j = 0; j < values.Length; j++)
            {
                Debug.Log($"Accessing data: header = {headers[j]}, value = {values[j]}");
                if (!csvData.ContainsKey(headers[j]))
                {
                    csvData[headers[j]] = new List<string>();
                }
                csvData[headers[j]].Add(values[j]);
            }
        }

        UpdateSerializedFields();
    }

    private void UpdateSerializedFields()
    {
        questionList = csvData["question"];
        answerListSlider1 = csvData["jawaban_benar_slider_1"];
        answerListSlider2 = csvData["jawaban_benar_slider_2"];
        answerListSlider3 = csvData["jawaban_benar_slider_3"];
        questionTitle = csvData["judul_soal"];
    }

    public (List<string> questionList, List<string> answerListSlider1, List<string> answerListSlider2, List<string> answerListSlider3, List<string> questionTitle) GetQuestion()
    {
        if (questionList.Count == 0)
        {
            ReadCSV();
        }

        return (questionList, answerListSlider1, answerListSlider2, answerListSlider3, questionTitle);
    }
}
