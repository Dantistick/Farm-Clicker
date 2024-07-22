using UnityEngine;
using TMPro;
using System;

[Serializable]
public class Money : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    public long CurrentMoney { get; set; }

    private void Awake()
    {
        CurrentMoney = 90;
        UpdateMoneyDisplay();
    }

    public void IncreaseMoney(long value)
    {
        CurrentMoney += value;
        UpdateMoneyDisplay();
    }

    public void DecreaseMoney(long value)
    {
        if(CurrentMoney >= value)
        {
            CurrentMoney -= value;
            UpdateMoneyDisplay();
        }
    }

    public bool EnoughMoney(long value)
    {
        return CurrentMoney >= value;
    }

    private void UpdateMoneyDisplay()
    {
        _moneyText.text = CurrentMoney.ToString();
    } 
}
