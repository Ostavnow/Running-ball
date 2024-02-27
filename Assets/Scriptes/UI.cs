using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{
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
    public void OpenSceneLevels()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Levels");
    }
    public void ButtonSoundEffect()
    {
        audioManager.Play("Button");
    }
}