using UnityEngine;
using UnityEngine.UI;

class SellAllProduct : MonoBehaviour
{
    [SerializeField] private Product _product;
    [SerializeField] private ChangeProductText _changeProductText;
    [SerializeField] private Money _money;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _money.IncreaseMoney(_product.price * _product.quantity);
        _product.quantity = 0;
        _changeProductText.UpdateInfoDisplay();
    }
}

