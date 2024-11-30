using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestNetwork : MonoBehaviour
{
    public TMP_Text yes;

    // Update is called once per frame
    void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
            yes.text = "Error. Check internet connection!";
        }else{
            yes.text = "ada inet";
        }

    }
}
