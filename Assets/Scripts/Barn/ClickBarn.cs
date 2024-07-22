using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickBarn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Barn _barn;
    [SerializeField] private Money _money;

    [SerializeField] private GameObject _phrase3;
    private bool _isUsedPhrase3 = false;

    [SerializeField] private GameObject _phrase4;
    private bool _isUsedPhrase4 = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        _money.IncreaseMoney(_barn.profit);

        if (!_isUsedPhrase4 && _money.CurrentMoney == 100 && _isUsedPhrase3 == true && _phrase3 != null)
        {
            Destroy(_phrase3);
            _phrase4.SetActive(true);
            _isUsedPhrase4 = true;
        }

        if (!_isUsedPhrase3 && _money.CurrentMoney >= 100 && _phrase4 != null)
        {
            _phrase3.SetActive(true);
            _isUsedPhrase3 = true;
        }
    }
}
