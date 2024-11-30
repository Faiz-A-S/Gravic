using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public List<BGMFile> listOfBGM;
    public AudioSource musicPlayer;
    public static bool isPlayingSomething = false;

    // Start is called before the first frame update
    void Awake()
    {
        musicPlayer = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(musicPlayer == null)
        {
            musicPlayer = gameObject.GetComponent<AudioSource>();
        }
    }

    public void PlaySong(int i)
    {
        musicPlayer.clip = listOfBGM[i].musicFile;
        musicPlayer.Play();
    }

    public void StopSong()
    {
        musicPlayer.clip = null;
    }
}
