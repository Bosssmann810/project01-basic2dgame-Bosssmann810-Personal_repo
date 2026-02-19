using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameplayUI;
    [SerializeField] private GameObject _pausedUI;
    [SerializeField] private GameObject _mainMenuUI;
    [SerializeField] private GameObject _settingsUI;
    [SerializeField] private GameObject _creditsUI;

    public void DisableAllUI()
    {
        _gameplayUI.SetActive(false);
        _pausedUI.SetActive(false);
        _mainMenuUI.SetActive(false);
        _settingsUI.SetActive(false);
        _creditsUI.SetActive(false); 
    }

    public void OpenSettings()
    {
        DisableAllUI();
        _settingsUI.SetActive(true);

    }

    public void OpenGameplay()
    {
        DisableAllUI();
        _gameplayUI.SetActive(true);
    }

    public void OpenPause()
    {
        DisableAllUI();
        _pausedUI.SetActive(true);
        _gameplayUI.SetActive(true);
    }
    public void OpenCredits()
    {
        DisableAllUI();
        _creditsUI.SetActive(true);
    }
}
