using UnityEngine;

class ChangeUpgradeText : ChangeText
{
    [SerializeField] private OtherBuilding _otherBuilding;

    private void Awake()
    {
        UpdateInfoDisplay();
    }

    public override void UpdateInfoDisplay()
    {
        _textMeshProName.text = $"{_otherBuilding.nameBuilding} lvl {_otherBuilding.level}";
        _textMeshProProfitUnit.text = $"{_otherBuilding.unit}";
        _textMeshProProfitNumber.text = $"{_otherBuilding.profit}";
        _textMeshProPriceToUpgrade.text = $"{_otherBuilding.priceToUpgrade}";
    }

    public virtual void UpdateMaxLevelInfo()
    {
        _textMeshProName.text = $"Max Level!";
        _textMeshProProfitUnit.text = "";
        _textMeshProProfitNumber.text = "";
        _textMeshProPriceToUpgrade.text = "";
    }
}