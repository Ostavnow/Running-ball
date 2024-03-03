using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUI : MonoBehaviour
{
    private SceneManager sceneManager;
    private AudioManager audioManager;
    [SerializeField]
    private Transform levelButtonGroup;
    private DataManager dataManager;
    private void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        audioManager = FindObjectOfType<AudioManager>();
        dataManager = FindObjectOfType<DataManager>();
        UpdatesAvailableLevelButtons();
    }
    public void PlayLevel(int i)
    {
        audioManager.StopAll();
        audioManager.Play("Background game");
        sceneManager.LoadSceneLevel(i);
    }
    public void RandomPlayLevel(int i)
    {
        sceneManager.fakeCurrentLevel = i;
        int randomLevel = Random.Range(1,10);
        sceneManager.currentLevel = randomLevel;
        audioManager.StopAll();
        audioManager.Play("Background game");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + randomLevel);
    }
    private void UpdatesAvailableLevelButtons()
    {
        int numberAvaliableLevels = dataManager.ProgressInfoPlayer.NumberLevelsСompleted;
        for(int i = 1; i < numberAvaliableLevels; i++)
        {
            levelButtonGroup.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }
}
