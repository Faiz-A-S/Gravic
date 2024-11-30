using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawabanScript : MonoBehaviour
{
    public bool isCorrect = false;
    private bool benar = false;
    public string namaSoal;

    public void Jawaban()
    {
        if (isCorrect)
        {
            benar = true;
            PrintFungusMessage();
        }
        else
        {
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