using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PlayerUIHundler : MonoBehaviour
{
    private SceneManagerUser sceneManager;
    [SerializeField]
    private TMP_Text levelText;
    private AudioManager audioManager;
    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManagerUser>();
        levelText.text = "Level " + sceneManager.fakeCurrentLevel.ToString();
        audioManager = FindObjectOfType<AudioManager>();
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
    public void ExitPause()
    {
        Time.timeScale = 1;
        audioManager.StopAll();
        audioManager.Play("Background menu");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    public void NextLevel()
    {
        if(sceneManager.currentLevel + 1 > 10)
        {
        int randomLevel = Random.Range(1,10);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + randomLevel);
        }
        else
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + ++sceneManager.currentLevel);
    }
    public void LevelRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + sceneManager.currentLevel);
    }
}
