using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class QuestManager : MonoBehaviour
{
    private Queue<string> tasks = new Queue<string>();
    public UIManager uIManager;
    public Quest currentquest = new Quest();
    bool inquest;
    [SerializeField]
    int questsComplete;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questsComplete = 0;
        currentquest = null;
        inquest = false;
        uIManager.UpdateQuestText("Find a skull");
    }
    public void CompletedQuest()
    {
        questsComplete++;
    }
    public int TotalCompleted()
    {
        return questsComplete;
    }
    public Quest GetCurrentQuest()
    {
        return currentquest;
    }
    public bool InQuest()
    {
        return inquest;
    }
    public void StartQuest(Quest newQuest)
    {
        if(newQuest == null)
        {
            Debug.Log("I messed up");
        }
      
        
        if(inquest == true )
        {
            return;
        }
        tasks.Clear();
        currentquest = newQuest;
        inquest = true;
        foreach (string task in newQuest.tasks)
        {
            tasks.Enqueue(task);
        }
        AdvanceQuest();
        
    }
    public void AdvanceQuest()
    {
        if(tasks.Count <= 0)
        {
            currentquest = null;
            uIManager.UpdateQuestText("Find a skull");
            inquest = false;
            return;
        }
        string task = tasks.Dequeue();
        uIManager.UpdateQuestText(task);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
