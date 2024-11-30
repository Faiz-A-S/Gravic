using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class IntroDead : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject intro;

    void Update()
    {
        if (director.state != PlayState.Playing)
        {
            intro.SetActive(false);
        }
    }

}
