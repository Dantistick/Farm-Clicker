using System.Diagnostics;
using TMPro;
using UnityEngine;

class ChangeProductText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProNameProduct;
    [SerializeField] private TextMeshProUGUI _textMeshProQuality;
    [SerializeField] private TextMeshProUGUI _textMeshProPrice;

    [SerializeField] private Product _product;

    private void Awake()
    {
        UpdateInfoDisplay();
    }

    public void UpdateInfoDisplay()
    {
        _textMeshProNameProduct.text = _product.name;
        _textMeshProPrice.text = $"Price: {_product.price}";
        _textMeshProQuality.text = $"Quality: {_product.quantity}";
    }
}