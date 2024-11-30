using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest Location", menuName = "Quest Manager/Quest Location", order = 2)]
public class QuestLocation : ScriptableObject
{
    [Header("Location Name")]
    public string locationName;

    [Header("All Quest Available")]
    public List<Quest> allQuest;

    [Header("Remaining Quest")]
    public List<Quest> remainingQuest;

}
