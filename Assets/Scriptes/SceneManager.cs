using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    public int avalibleLevels;
    public int currentLevel;
    private AudioManager audioManager;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioManager = GetComponent<AudioManager>();
        audioManager.Play("Background menu");
        avalibleLevels = GetComponent<DataManager>().ProgressInfoPlayer.NumberLevelsСompleted;
    }
    public void LoadSceneLevel(int id)
    {
        currentLevel = id;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + id);
    }
    
    public void OpenSettings(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void CancelSettings(GameObject obj)
    {
        obj.SetActive(false);
    }
}
