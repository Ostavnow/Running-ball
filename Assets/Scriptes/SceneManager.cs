using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    public int avalibleLevels;
    public int currentLevel;
    public int fakeCurrentLevel;
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
        fakeCurrentLevel = id;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + id);
    }

}
