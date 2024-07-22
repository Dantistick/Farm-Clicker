using UnityEngine;
using UnityEngine.UI;

class UpgradeBarn : MonoBehaviour
{
    [SerializeField] private Barn _barn;
    [SerializeField] private ChangeBarnText _changeBarnText;
    [SerializeField] private Money _money;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (_money.EnoughMoney(_barn.priceToUpgrade))
        {
            _money.DecreaseMoney(_barn.priceToUpgrade);
            ++_barn.level;
            switch (_barn.level)
            {
                case 2:
                    {
                        _barn.profit = 10;
                        _barn.priceToUpgrade = 10_000;
                        _changeBarnText.UpdateInfoDisplay();
                        break;
                    }

                case 3:
                    {
                        _barn.profit = 100;
                        gameObject.SetActive(false);
                        _changeBarnText.UpdateMaxLevelInfo();
                        break;
                    }
            }
        }
    }
}
