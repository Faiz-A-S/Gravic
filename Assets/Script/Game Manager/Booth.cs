using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booth : MonoBehaviour
{
    public Fungus.Flowchart myFlow;
    public bool coll = false;
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent < Rigidbody2D >();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (coll == true)
        {
            myFlow.ExecuteBlock("Percakapan");
        }
        
    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

       coll =  myFlow.GetBooleanVariable("Coll") ;
    }

    void onTriggerExit2D(Collider2D collision)
    {
      coll = myFlow.GetBooleanVariable("Coll");
        coll = false;
    }


}
