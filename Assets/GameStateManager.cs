using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class GameStateManager : MonoBehaviour
{
    public enum GameState
    {
        None,
        init,
        Gameplay,
        MainMenu,
        paused,
        settings,
        credits
    }
    public UIManager uimanager;
    public GameState currentstate;
    public GameState previousstate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        uimanager = Servicehub.Instance.uiManager;
        if (uimanager != null) { Debug.Log("NO UI MANAGER"); }
        SetState(GameState.init);

        
    }
    public void SetState(GameState newState)
    {
        if (currentstate == newState) return;
        previousstate = currentstate; 
        currentstate = newState;
        OnStateChange(previousstate, currentstate);
    }

    public void OnStateChange(GameState previousState, GameState newState)
    {
        switch (newState)
        {
            case GameState.init:
                SetState(GameState.MainMenu);
                break;
            case GameState.MainMenu:
                uimanager.OpenMainMenu();
                Time.timeScale = 0;
                break;

            case GameState.Gameplay:
                uimanager.OpenGameplay(); Time.timeScale = 1; break;
            case GameState.settings:
                uimanager.OpenSettings(); Time.timeScale = 0; break;
            case GameState.credits:
                uimanager.OpenCredits(); Time.timeScale = 0; break;
            case GameState.paused:
                uimanager.OpenPause(); Time.timeScale = 0; break;
        }
    }

    public void StartGane()
    {
        SetState(GameState.Gameplay);
    }
    public void TogglePause()
    {
        if(currentstate == GameState.paused)
        {
            if (currentstate == GameState.Gameplay) return;
            SetState(GameState.Gameplay);
        }
        else if(currentstate == GameState.Gameplay)
        {
            if (currentstate == GameState.paused) return;
            SetState(GameState.paused);
        }
    }
    public void MainMenu()
    {
        SetState(GameState.MainMenu);
    }
    public void Credits()
    {
        SetState(GameState.credits);
    }
    public void settings()
    {
        SetState(GameState.settings);
    }
    public void back()
    {
        SetState(previousstate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
