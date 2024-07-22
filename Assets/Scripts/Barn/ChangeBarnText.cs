using UnityEngine;

class ChangeBarnText : ChangeUpgradeText
{
    [SerializeField] private Barn _barn;
    public override void UpdateInfoDisplay()
    {
        _textMeshProName.text = $"{_barn.nameBuilding} lvl {_barn.level}";
        _textMeshProProfitUnit.text = $"{_barn.unit}";
        _textMeshProProfitNumber.text = $"{_barn.profit}";
        _textMeshProPriceToUpgrade.text = $"{_barn.priceToUpgrade}";
    }

    public override void UpdateMaxLevelInfo()
    {
        _textMeshProName.text = $"Max Level!";
        Destroy(_textMeshProProfitUnit);
        Destroy(_textMeshProProfitNumber);
        Destroy(_textMeshProPriceToUpgrade);
    }
}