using UnityEngine;
using UnityEngine.UI;

class UpgradeBuilding : MonoBehaviour
{
    [SerializeField] private OtherBuilding _building;
    [SerializeField] private ChangeUpgradeText _changeUpgradeText;
    [SerializeField] private Money _money;

    [SerializeField] private ProfitableProduct _profitableProduct;
    public double koefToUpgrade = 1.1;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (_money.EnoughMoney(_building.priceToUpgrade))
        {
            ++_building.level;

            _money.DecreaseMoney(_building.priceToUpgrade);
            _building.priceToUpgrade = (long)(_building.priceToUpgrade * koefToUpgrade);
            _building.profit += _building.profitUpgrade;

            if (_building.level == _building.maxLevel)
            {
                _changeUpgradeText.UpdateMaxLevelInfo();
                gameObject.SetActive(false);
            }
            else
            {
                _changeUpgradeText.UpdateInfoDisplay();
            }
        }
    }
}