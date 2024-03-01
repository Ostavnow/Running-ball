using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatingAmountOfMoney : MonoBehaviour
{
    private DataManager dataManager;
    private TMP_Text amountMoneyText;
    void Start()
    {
        amountMoneyText = GetComponent<TMP_Text>();
        dataManager = FindObjectOfType<DataManager>();
        Debug.Log(dataManager.ProgressInfoPlayer);
        amountMoneyText.text = dataManager.ProgressInfoPlayer.AmountMoney.ToString(); 
    }
}
