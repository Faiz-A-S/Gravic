using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public GameObject TownCam;
    public GameObject PizzariaCam;
    public GameObject ClassroomCam;

    [SerializeField]
    private float _speed;
    private Rigidbody2D playerRB;
    private Animator playerAnim;

    public GameObject BGMManagerGo;
    public BGMManager BGMManagerInstance;

    public int bgmSize;
    public string bgmName;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();       

        BGMManagerGo = GameObject.Find("BGM Manager");
        BGMManagerInstance = BGMManagerGo.GetComponent<BGMManager>();
        bgmSize = BGMManagerInstance.listOfBGM.Count;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _speed;
        playerAnim.SetFloat("MoveX", playerRB.velocity.x);
        playerAnim.SetFloat("MoveY", playerRB.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BGM"))
        {
            if (BGMManager.isPlayingSomething == true)
            {
                BGMManagerInstance.StopSong();
            }

            bgmName = collision.gameObject.name;
            for (int i = 0; i < bgmSize; i++)
            {
                Debug.Log("Looking for song to play..");
                if(BGMManagerInstance.listOfBGM[i].whereToUse == bgmName)
                {
                    BGMManagerInstance.PlaySong(i);
                    Debug.Log("Playing Song");
                    break;
                }
            }
            BGMManager.isPlayingSomething = true;
        }
        if (collision.gameObject.CompareTag("Town"))
        {
            AudioListener.pause = false;
            PizzariaCam.SetActive(false);
            ClassroomCam.SetActive(false);
            TownCam.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Pizzaria"))
        {
            TownCam.SetActive(false);
            ClassroomCam.SetActive(false);
            PizzariaCam.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Classroom"))
        {
            TownCam.SetActive(false);
            PizzariaCam.SetActive(false);
            ClassroomCam.SetActive(true);
        }
    }
}
