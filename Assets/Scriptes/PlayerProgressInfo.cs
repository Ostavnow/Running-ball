using System;
using UnityEngine;
[Serializable]
public class PlayerProgressInfo : IProgressInfo
{
    [SerializeField]
    [HideInInspector]
    private int numberLevelsСompleted;
    public int NumberLevelsСompleted
    {
        get{return numberLevelsСompleted;}
        set{numberLevelsСompleted = value;}
    }
    [SerializeField]
    [HideInInspector]
    private int amountMoney;
    public int AmountMoney
    {
        get{return amountMoney;}
        set{amountMoney = value;}
    }
    public PlayerProgressInfo(int numberLevelsСompleted, int amountMoney)
    {
        NumberLevelsСompleted = numberLevelsСompleted;
        AmountMoney = amountMoney;
    }
    public PlayerProgressInfo()
    {
        NumberLevelsСompleted = 1;
        AmountMoney = 0;
    }
}
