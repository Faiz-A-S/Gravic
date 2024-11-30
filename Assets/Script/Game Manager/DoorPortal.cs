using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPortal : MonoBehaviour
{
    private GameObject PlayerGameObject;
    private Transform PlayerGameObjectTransform;
    private Rigidbody2D playerRB;

    [Header("Where to Teleport?")]
    public GameObject targetPositionGameObject;
    private Transform targetPositionTransform;

    [Header("How long it takes to teleport")]
    public static float teleportTime = 1.0f;
    private bool canTeleport = false;

    private GameObject fadeCanvas;
    private Fade fadeCanvasGroup;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerGameObject = GameObject.Find("Player");
        fadeCanvas = GameObject.Find("Fade to Black");
        playerRB = PlayerGameObject.GetComponent<Rigidbody2D>();

        PlayerGameObjectTransform = PlayerGameObject.GetComponent<Transform>();
        targetPositionTransform = targetPositionGameObject.GetComponent<Transform>();
        fadeCanvasGroup = fadeCanvas.GetComponent<Fade>();
    }

    public IEnumerator TeleportToLocation()
    {   
        playerRB.GetComponent<PlayerStop>().StopMovingPlease(); 
        fadeCanvasGroup.DoFadeIn(); 
        yield return new WaitForSeconds(1);
        PlayerGameObjectTransform.position = targetPositionTransform.position;
        fadeCanvasGroup.DoFadeOut();
        yield return new WaitForSeconds(1);
        playerRB.GetComponent<PlayerStop>().AlrightMove();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == PlayerGameObject)
        {
            canTeleport = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerGameObject)
        {
            canTeleport = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTeleport)
        {
            StartCoroutine(TeleportToLocation());
        }
    }
}
