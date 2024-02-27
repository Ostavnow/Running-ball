using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerUIHundler : MonoBehaviour
{
    private SceneManager sceneManager;
    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
    }
    public void Pause(GameObject obj)
    {
        obj.SetActive(true);
        Time.timeScale = 0;
    }
    public void CancelPause(GameObject obj)
    {
        obj.SetActive(false);
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + ++sceneManager.currentLevel);
    }
    public void LevelRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + sceneManager.currentLevel);
    }
}
