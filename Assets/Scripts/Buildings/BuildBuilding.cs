using UnityEngine;
using UnityEngine.UI;

class BuildBuilding : MonoBehaviour
{
    [SerializeField] private OtherBuilding _building;
    [SerializeField] private ChangeBuildingText _changeBuildingText;
    [SerializeField] private ChangeProductText _changeProductText;
    [SerializeField] private Money _money;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (_money.EnoughMoney(_building.priceToBuy))
        {
            _money.DecreaseMoney(_building.priceToBuy);
            _building.isBuild = true;
            _building.gameObject.SetActive(true);
            if (_changeProductText != null)
                _changeProductText.gameObject.SetActive(true);
            _changeBuildingText.UpdateInfoDisplay();
        }
    }

    public void Build()
    {
        _building.gameObject.SetActive(true);
        if(_changeProductText != null)
            _changeProductText.gameObject.SetActive(true);
        _changeBuildingText.UpdateInfoDisplay();
    }
}
