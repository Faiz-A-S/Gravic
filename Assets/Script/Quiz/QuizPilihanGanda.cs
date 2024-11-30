using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizPilihanGanda : MonoBehaviour
{
    public Text SoalText;
    public Image SoalPic;
    public List<GameObject> ButtonJawaban;
    public Text JudulSoalText;
    public int kodeSoal;
    public List<string> Jawaban = new List<string>();
    public string namaSoal;
    private bool benar = false;

    private List<string> JawabanAcak = new List<string>();
    private CSVReader _csvRead;
    private QuestManager _qM;
    private GoogleSheetsImporter _csvImport;
    private GoogleDriveImporter _driveImport;
    private Transform child;
    private bool acak = false;

    private static QuizPilihanGanda _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        child = this.transform.GetChild(0);
        _driveImport = FindObjectOfType<GoogleDriveImporter>();
        _csvImport = FindObjectOfType<GoogleSheetsImporter>();
        _csvRead = FindObjectOfType<CSVReader>();
        _qM = FindObjectOfType<QuestManager>();

        foreach (GameObject button in ButtonJawaban)
        {
            Button buttons = button.GetComponent<Button>();

            buttons?.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (child.gameObject.activeSelf)
        {
            if (!acak)
            {
                PasangSoal();
                acak = true;
            }
        }
        else
        {
            acak = false;
        }
    }

    private void PasangSoal()
    {
        GetSoal();
        SetSoal();
    }

    private void GetSoal()
    {
        (List<string> questionList, List<string> answerListSlider1, List<string> answerListSlider2, List<string> answerListSlider3, List<string> questionTitle) questionData = _csvRead.GetQuestion();
        SoalText.text = questionData.questionList[kodeSoal];
        Jawaban[0] = questionData.answerListSlider1[kodeSoal];
        Jawaban[1] = questionData.answerListSlider2[kodeSoal];
        Jawaban[2] = questionData.answerListSlider3[kodeSoal];
        SoalPic.sprite = _driveImport.SpriteSoal[kodeSoal - 4];
    }

    private void SetSoal()
    {
        JawabanAcak = new List<string>(Jawaban);
        ShuffleJawaban(JawabanAcak);
        AssignLabelsToTexts(JawabanAcak);
    }

    private void ShuffleJawaban<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void AssignLabelsToTexts(List<string> shuffledLabels)
    {
        for (int i = 0; i < ButtonJawaban.Count; i++)
        {
            ButtonJawaban[i].GetComponentInChildren<Text>().text = shuffledLabels[i];
        }
    }

    private void OnButtonClick(GameObject buttonObject)
    {
        // Do something when the button is clicked
        Debug.Log($"Button in {buttonObject.name} clicked.");
        if (buttonObject.GetComponentInChildren<Text>().text == Jawaban[0])
        {
            benar = true;
            PrintFungusMessage();
        }else{
            benar = false;
            PrintFungusMessage();
        }
    }
    void PrintFungusMessage()
    {
        if (namaSoal.Equals("Panitia Booth"))
        {
            if (benar)
            {
                Fungus.Flowchart.BroadcastFungusMessage("benarPanitiaBooth");
            }
            else
            {
                Fungus.Flowchart.BroadcastFungusMessage("salahPanitiaBooth");
            }
        }
        if (namaSoal.Equals("Minuman"))
        {
            if (benar)
            {
                Fungus.Flowchart.BroadcastFungusMessage("benarMinuman");
            }
            else
            {
                Fungus.Flowchart.BroadcastFungusMessage("salahMinuman");
            }
        }
        if (namaSoal.Equals("Buah"))
        {
            if (benar)
            {
                Fungus.Flowchart.BroadcastFungusMessage("benarBuah");
            }
            else
            {
                Fungus.Flowchart.BroadcastFungusMessage("salahBuah");
            }
        }
        if (namaSoal.Equals("Mobil"))
        {
            if (benar)
            {
                Fungus.Flowchart.BroadcastFungusMessage("benarMobil");
            }
            else
            {
                Fungus.Flowchart.BroadcastFungusMessage("salahMobil");
            }
        }
    }
}
