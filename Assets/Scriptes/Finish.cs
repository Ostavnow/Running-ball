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
    private void Start()
    {
        moneyCounter = FindObjectOfType<MoneyCounter>();
        FindObjectOfType<PlayerController>().Finish += MethodFinish;
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void MethodFinish()
    {
        panelFinishUI.SetActive(true);
        FindObjectOfType<PlayerController>().GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(AnimatePlayer());
        moneyText.text = moneyCounter.CountMoney.ToString();
        audioManager.Play("Finish");
    }
    private IEnumerator AnimatePlayer()
    {
        Transform playerTransform = FindObjectOfType<PlayerController>().transform;
        Vector3 startPosition = playerTransform.position;
        Vector3 endPosition = new Vector3(transform.position.x + 3f,transform.position.y + 0.5f,transform.position.z);
        while(playerTransform.position.z + 5 < transform.position.z)
        {
            playerTransform.position = Vector3.Lerp(playerTransform.position,endPosition,Time.deltaTime / 1f);
            yield return null;
        }
    }
}
