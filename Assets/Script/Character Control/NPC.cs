using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    private Rigidbody2D npcRB;
    private Animator npcAnim;
    [SerializeField]
    private float lamaJalan = 3f;
    private bool flip = false;

    // Start is called before the first frame update
    void Start()
    {
        npcRB = GetComponent<Rigidbody2D>();
        npcAnim = GetComponent<Animator>();
        StartCoroutine(Flip());

    }

    // Update is called once per frame
    void Update()
    {
        if(flip == true)
        {
            npcRB.velocity = new Vector2(_speed, 0);
            npcAnim.SetFloat("MoveX", npcRB.velocity.x);
        }else if(flip == false)
        {
            npcRB.velocity = new Vector2(-_speed, 0);
            npcAnim.SetFloat("MoveX", npcRB.velocity.x);
        }
                  

    }

    private IEnumerator Flip()
    {
        while (true)
        {
            flip = false;
            yield return new WaitForSeconds(lamaJalan);
            flip = true;
            yield return new WaitForSeconds(lamaJalan);

        }

    }


}
