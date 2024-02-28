using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasMenu;
    [SerializeField]
    private GameObject canvasLevels;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void OpenSettings(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void CancelSettings(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void OpenSceneMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        audioManager.StopAll();
        audioManager.Play("Background menu");
    }
    public void OpenWindowLevels()
    {
        canvasMenu.SetActive(false);
        canvasLevels.SetActive(true);
    }
    public void CancelWindowLevels()
    {
        canvasMenu.SetActive(true);
        canvasLevels.SetActive(false);
    }
    public void ButtonSoundEffect()
    {
        audioManager.Play("Button");
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
}