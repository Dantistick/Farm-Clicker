using UnityEngine;
using UnityEngine.UI;

class ProfitableMoney : ProfitableBuilding
{
    [SerializeField] protected Money _money;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        if (_money.EnoughMoney(_otherBuilding.priceToBuy))
        {
            InvokeRepeating("ReceiveProfit", 0f, 1f);
        }
    }

    public void CLick()
    {
        InvokeRepeating("ReceiveProfit", 0f, 1f);
    }

    public override void ReceiveProfit()
    {
        _money.IncreaseMoney(_otherBuilding.profit);
    }
}