using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Music Track", menuName = "Audio/Music", order = 1)]
public class BGMFile : ScriptableObject
{
    [Header("Music Details")]
    public AudioClip musicFile;

    [Header("Where to use Music")]
    public string whereToUse;
}
