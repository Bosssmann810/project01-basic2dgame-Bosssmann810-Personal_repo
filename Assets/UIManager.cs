using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameplayUI;
    [SerializeField] private GameObject _pausedUI;
    [SerializeField] private GameObject _mainMenuUI;
    [SerializeField] private GameObject _settingsUI;
    [SerializeField] private GameObject _creditsUI;
    [SerializeField] private GameObject _dialogeBox;
    public TMP_Text _text;


    public void DisableAllUI()
    {
        _gameplayUI.SetActive(false);
        _pausedUI.SetActive(false);
        _mainMenuUI.SetActive(false);
        _settingsUI.SetActive(false);
        _creditsUI.SetActive(false); 
    }

    public void ShowDialouge()
    {
        _dialogeBox.SetActive(true);
    }
    public void HideDialouge()
    {
        _dialogeBox.SetActive(false);
    }
    public void Changetext(string text)
    {
        _text.text = text;
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
    public void OpenMainMenu()
    {
        DisableAllUI();
        _mainMenuUI.SetActive(true);
    }
}
