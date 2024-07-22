using UnityEngine;
using UnityEngine.UI;

class ProfitableProduct : ProfitableBuilding
{
    [SerializeField] private Money _money;
    [SerializeField] private Product _product;
    [SerializeField] private ChangeProductText _changeProductText;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnCLick);
    }

    public void OnCLick()
    {
        if (_money.EnoughMoney(_otherBuilding.priceToBuy))
        {
            InvokeRepeating(nameof(ReceiveProfit), 60f, 60f);
        }
    }

    public void Click()
    {
        InvokeRepeating(nameof(ReceiveProfit), 60f, 60f);
    }

    public override void ReceiveProfit()
    {
        _product.quantity += _otherBuilding.profit;
        _changeProductText.UpdateInfoDisplay();
    }
}