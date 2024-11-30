using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCollider : MonoBehaviour
{
    private GameObject PlayerGameObject;
    public GameObject E;
    private AudioSource audioSource;
    private bool isPlayerInsideTrigger = false;

    private void Awake()
    {
        PlayerGameObject = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        // Check if the player is inside the trigger and the E key is pressed
        if (isPlayerInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Play(); // Play the sound effect
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject == PlayerGameObject)
        {
            E.SetActive(true);
            isPlayerInsideTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerGameObject)
        { 
            E.SetActive(false);
            isPlayerInsideTrigger = false;
        }
    }
}
