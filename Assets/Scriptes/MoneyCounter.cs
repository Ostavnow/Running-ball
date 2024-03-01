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
    
    void Start()
    {
        GetComponent<PlayerController>().TookMoney += TookMoney;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Money"))
        {
            TookMoney();
            other.GetComponent<AudioSource>().Play();
            SpriteRenderer sprite = other.GetComponent<SpriteRenderer>();
            sprite.enabled = false;
            Destroy(other.gameObject,0.5f);
        }
    }
    private void TookMoney()
    {
        CountMoney++;
        textCountMoney.text = CountMoney.ToString();
    }
}
