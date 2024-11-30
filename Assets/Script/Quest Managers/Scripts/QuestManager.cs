using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private GoogleSheetsImporter _csvImport;
    private CSVReader _csvRead;
    private GoogleDriveImporter _driveImport;

    //public Button Reload;
    //public bool _reloaded;

    [Header("Pop Up Menu")]
    public GameObject popUpBox;
    public Animator animator;
    /*public Text popUpText;*/

    // Method untuk refresh/reload soal di main menu
    //// Start is called before the first frame update
    //void Start()
    //{
    //    _csvImport = FindObjectOfType<GoogleSheetsImporter>();
    //    _csvRead = FindObjectOfType<CSVReader>();
    //    _driveImport = FindObjectOfType<GoogleDriveImporter>();

    //    _csvImport.Import();
    //    _driveImport.Import();
    //    _csvRead.ReadCSV();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (_reloaded)
    //    {
    //        _csvImport.Import();
    //        _driveImport.Import();
    //        _csvRead.ReadCSV();
    //        _reloaded = false;
    //    }
    //}

    //public void importcoba()
    //{
    //    _csvImport.Import();
    //    _driveImport.Import();
    //    _csvRead.ReadCSV();
    //}

    public void PopUp()
    {
        /*popUpBox.SetActive(true);*/
        /*popUpText.text = text;*/
        if (animator.GetBool("isActive") == true)
        {
            Debug.Log("Activating..");
            animator.SetBool("isActive", false);
        }
        else if (animator.GetBool("isActive") == false)
        {
            Debug.Log("Deactivating..");
            animator.SetBool("isActive", true);
        }

    }
}
