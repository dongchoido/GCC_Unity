using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] PausePanel pausePanel;

    [SerializeField] Button pauseButton;
    public void ShowPausePanel()
    {
        pausePanel.gameObject.SetActive(true);
        DataManager.instance.PauseGame();
        pausePanel.Popup(true);
        pauseButton.interactable = false;
    }
    public void HidePausePanel()
    {
        DataManager.instance.UnPauseGame();
        pausePanel.Popup(false);
        pauseButton.interactable = true;
    }
}
