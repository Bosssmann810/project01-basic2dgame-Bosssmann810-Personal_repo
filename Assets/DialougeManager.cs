using UnityEngine; 
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class DialougeManager : MonoBehaviour
{
    private Queue<string> sentences;
    public UIManager uIManager;
    public playerinputs playerinputs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       sentences = new Queue<string>();   
    }

    public void StartDialouge(Dialouge dialouge)
    {
        sentences.Clear();
        uIManager.ShowDialouge();
        foreach (string sentence in dialouge.sentances)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextText();
    }

    public void DisplayNextText()
    {
        playerinputs.EnterDialouge();
        if (sentences.Count <= 0)
        {
            uIManager.HideDialouge();
            playerinputs.ExitDialouge();
        }
        string sentance = sentences.Dequeue();
        uIManager.Changetext(sentance);
    }

    public bool DialougEnded()
    {
       return sentences.Count > 0;
    }
}
