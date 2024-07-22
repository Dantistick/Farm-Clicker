using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

class ChangeBuildingText : ChangeText
{
    [SerializeField] private OtherBuilding _otherBuilding;
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private GameObject _imageIsBuilt;
    [SerializeField] private GameObject _productImage;

    private void Awake()
    {
        FirstUpdateInfoDisplay();
    }

    public void FirstUpdateInfoDisplay()
    {
        _textMeshProName.text = $"{_otherBuilding.nameBuilding}";
        _textMeshProProfitUnit.text = $"{_otherBuilding.unit}";
        _textMeshProProfitNumber.text = $"{_otherBuilding.profit}";
        _textMeshProPriceToUpgrade.text = $"{_otherBuilding.priceToBuy}";
    }

    public override void UpdateInfoDisplay()
    {
        Destroy(_textMeshProPriceToUpgrade);
        Destroy(_textMeshProProfitNumber);
        Destroy(_textMeshProProfitUnit);
        Destroy(_productImage);

        _upgradePanel.SetActive(true);
        _imageIsBuilt.SetActive(true);

        Transform childTransform = transform.Find("Button");
        if (childTransform != null)
        {
            childTransform.gameObject.SetActive(false);
        }

    }
}

