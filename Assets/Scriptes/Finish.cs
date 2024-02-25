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
    private void Start()
    {
        moneyCounter = FindObjectOfType<MoneyCounter>();
        FindObjectOfType<PlayerController>().Finish += MethodFinish;
    }
    private void MethodFinish()
    {
        panelFinishUI.SetActive(true);
        FindObjectOfType<PlayerController>().GetComponent<Rigidbody>().isKinematic = true;
        moneyText.text = moneyCounter.CountMoney.ToString();
    }
}
