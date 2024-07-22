using TMPro;
using UnityEngine;

abstract class ChangeText : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _textMeshProName;
    [SerializeField] protected TextMeshProUGUI _textMeshProProfitNumber;
    [SerializeField] protected TextMeshProUGUI _textMeshProProfitUnit;
    [SerializeField] protected TextMeshProUGUI _textMeshProPriceToUpgrade;

    abstract public void UpdateInfoDisplay();
}
    
