using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsUI : MonoBehaviour
{
    private SceneManager sceneManager;
    private AudioManager audioManager;
    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void PlayLevel(int i)
    {
        audioManager.StopAll();
        audioManager.Play("Background game");
        sceneManager.LoadSceneLevel(i);
    }
    public void RandomPlayLevel()
    {
        int randomLevel = Random.Range(1,10);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + randomLevel);
    }
}
