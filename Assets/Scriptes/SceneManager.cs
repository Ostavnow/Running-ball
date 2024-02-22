using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour
{
    
    public void SceneLevels()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Levels");
    }
    public void OpenSettings(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void CancelSettings(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void PlayLevel(int i)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + i);
    }
    public void RandomPlayLevel()
    {
        int randomLevel = Random.Range(1,10);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level " + randomLevel);
    }
}
