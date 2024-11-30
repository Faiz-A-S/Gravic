using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStop : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D playerRB;


    private void Start()
    {
        _player = this.transform.gameObject;
        playerRB = GetComponent<Rigidbody2D>();
    }

    public void StopMovingPlease()
    {
       _player.GetComponent<PlayerController>().enabled = false;
        playerRB.velocity = new Vector2(0, 0);
    }

    public void AlrightMove()
    {
        _player.GetComponent<PlayerController>().enabled = true;
    }
}
