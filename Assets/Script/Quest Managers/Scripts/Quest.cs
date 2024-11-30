using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest Manager/Quest", order = 1)]
public class Quest : ScriptableObject
{
    [Header("Quest Attribute")]
    [SerializeField] private string questId;
    [SerializeField] private string questDescription;

    [Header("Quest Condition")]
    [SerializeField] private bool isDone;

    
}
