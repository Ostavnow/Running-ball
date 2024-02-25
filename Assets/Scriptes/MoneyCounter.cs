using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyCounter : MonoBehaviour
{
    private int countMoney;
    public int CountMoney{private set; get;}
    [SerializeField]
    private TMP_Text textCountMoney;
    private AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        GetComponent<PlayerController>().TookMoney += TookMoney;
    }

    private void TookMoney()
    {
        CountMoney++;
        textCountMoney.text = CountMoney.ToString();
        audioManager.Play("Took money");
    }
}
