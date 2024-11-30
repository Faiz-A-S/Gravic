using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizBarChart : MonoBehaviour
{
    public TMP_Text JudulSoalText;
    public TMP_Text SoalText;
    public Slider npcSC1, npcSC2, npcSC3;
    public float jawabanBenar1, jawabanBenar2, jawabanBenar3;
    public string namaSoal;
    public int kodeSoal;
    public Sprite gambarSoal;
    private bool benar = false;

    private CSVReader _csvRead;

    private static QuizBarChart _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _csvRead = FindObjectOfType<CSVReader>();
        Ngerandom();
        Debug.Log("Start " + this.transform.root.gameObject.name);
    }

    void Update()
    {
        GetSoal();
    }

    private void GetSoal()
    {
        (List<string> questionList, List<string> answerListSlider1, List<string> answerListSlider2, List<string> answerListSlider3, List<string> questionTitle) questionData = _csvRead.GetQuestion();
        SoalText.text = questionData.questionList[kodeSoal];
        jawabanBenar1 = float.Parse(questionData.answerListSlider1[kodeSoal]);
        jawabanBenar2 = float.Parse(questionData.answerListSlider2[kodeSoal]);
        jawabanBenar3 = float.Parse(questionData.answerListSlider3[kodeSoal]);
        JudulSoalText.text = questionData.questionTitle[kodeSoal];

        if (gambarSoal == null)
        {
            return;
        }
    }

    public void Jawaban()
    {
        if (jawabanBenar1 == (npcSC1.value * 100) && jawabanBenar2 == (npcSC2.value * 100) && jawabanBenar3 == (npcSC3.value * 100))
        {
            benar = true;
            printFungusMessage();
            Debug.Log(namaSoal + " benar");
        }
        else
        {
            benar = false;
            printFungusMessage();
            Debug.Log(namaSoal + " salah");
        }
    }

    void Ngerandom()
    {
        npcSC1.value = Random.Range(0, 6);
        npcSC2.value = Random.Range(0, 6);
        npcSC3.value = Random.Range(0, 6);
    }
    void printFungusMessage()
    {
        if (namaSoal.Equals("Suster"))
        {
            if (benar)
            {
                Fungus.Flowchart.BroadcastFungusMessage("benarSuster");
            }
            else
            {
                Fungus.Flowchart.BroadcastFungusMessage("salahSuster");
            }
        }
        if (namaSoal.Equals("Penjaga Resto"))
        {
            if (benar)
            {
                Fungus.Flowchart.BroadcastFungusMessage("benarPenjagaResto");
            }
            else
            {
                Fungus.Flowchart.BroadcastFungusMessage("salahPenjagaResto");
                Ngerandom();
            }
        }
        if (namaSoal.Equals("Kang Parkir"))
        {
            if (benar)
            {
                Fungus.Flowchart.BroadcastFungusMessage("benarKangParkir");
            }
            else
            {
                Fungus.Flowchart.BroadcastFungusMessage("salahKangParkir");
            }
        }
        if (namaSoal.Equals("Penjual Minuman"))
        {
            if (benar)
            {
                Fungus.Flowchart.BroadcastFungusMessage("benarPenjualMinuman");
            }
            else
            {
                Fungus.Flowchart.BroadcastFungusMessage("salahPenjualMinuman");
            }
        }
    }
}
