using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private GameObject panelFinishUI;
    [SerializeField]
    private TMP_Text moneyText;
    private MoneyCounter moneyCounter;
    private AudioManager audioManager;
    private PlayerController playerController;
    private SceneManagerUser sceneManager;
    private DataManager dataManager;
    private CameraAnimation cameraAnimation;
    private int numberCalls = 0;
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.Finish += MethodFinish;
        moneyCounter = FindObjectOfType<MoneyCounter>();
        audioManager = FindObjectOfType<AudioManager>();
        sceneManager = FindObjectOfType<SceneManagerUser>();
        dataManager = FindObjectOfType<DataManager>();
        cameraAnimation = FindObjectOfType<CameraAnimation>();
    } 
    private void MethodFinish()
    {
        if(numberCalls == 0)
        {
        numberCalls++;
        if(sceneManager.fakeCurrentLevel == sceneManager.avalibleLevels)
        {
            sceneManager.avalibleLevels++;
        }
        sceneManager.fakeCurrentLevel++;
        Debug.Log(gameObject.name);
        int amountMoney = dataManager.ProgressInfoPlayer.AmountMoney + moneyCounter.CountMoney;
        int numberLevelsСompleted = sceneManager.avalibleLevels;
        IProgressInfo playerProgress = new PlayerProgressInfo(numberLevelsСompleted,amountMoney);
        dataManager.SaveProgress(playerProgress);
        panelFinishUI.SetActive(true);
        playerController.GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(AnimatePlayer());
        moneyText.text = moneyCounter.CountMoney.ToString();
        FindObjectOfType<FollowCamera>().enabled = false;
        cameraAnimation.PlayAnimation();
        audioManager.Play("Finish");
        }
       
    }
    private IEnumerator AnimatePlayer()
    {
        Transform playerTransform = FindObjectOfType<PlayerController>().transform;
        Vector3 startPosition = playerTransform.position;
        Vector3 endPosition = new Vector3(transform.position.x + 4.7f,transform.position.y + 0.5f,transform.position.z);
        while(playerTransform.position.z + 5 < transform.position.z)
        {
            playerTransform.position = Vector3.Lerp(playerTransform.position,endPosition,Time.deltaTime);
            yield return null;
        }
    }
}
