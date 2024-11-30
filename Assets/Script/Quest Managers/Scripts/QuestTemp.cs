using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTemp : MonoBehaviour
{
    public Text textVisibility;
    public static int howManyQuestDone = 0;
    private CanvasGroup outroQuest;

    private Color currentColor;
    private bool isFadingOut = false;
    private Fungus.Flowchart outroFlowchart;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        textVisibility = gameObject.GetComponent<Text>();
        currentColor = textVisibility.color;
        outroQuest = GameObject.Find("Canvas Quest Back To Class").GetComponent<CanvasGroup>();
        outroQuest.alpha = 0;        
        outroFlowchart = GameObject.Find("Guru").GetComponent<Fungus.Flowchart>();
    }

    public void TurnInvisible()
    {
        isFadingOut = true;
        textVisibility.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
        howManyQuestDone++;
        Debug.Log("Quest done : " + howManyQuestDone);

        if (howManyQuestDone == 10)
        {
            outroQuest.alpha = 1;
            outroFlowchart.SetBooleanVariable("Outro", true);
        }
    }

}
