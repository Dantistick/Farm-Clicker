using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

class JsonReadWriteSystem : MonoBehaviour
{
    public Money money;
    public Barn barn;
    public List<OtherBuilding> otherBuildings;
    public List<Product> products;

    [SerializeField] private List<Button> _buttons;
    [SerializeField] private GameObject _introduction;

    [Header("Save Config")]
    [SerializeField] private string savePath;
    [SerializeField] private string saveFileName = "data.json";

    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        savePath = Path.Combine(Application.pestistanceDataPath, saveFileName);
#else
        savePath = Path.Combine(Application.dataPath, saveFileName);
#endif
        LoadFromJson();
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }

    private void OnApplicationPause(bool pause)
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            SaveToJson();
        }
    }

    public void SaveToJson()
    {
        SaveDataAll saveDataAll = new SaveDataAll();

        //save current money
        saveDataAll.saveDataMoney = new SaveDataMoney();
        saveDataAll.saveDataMoney.money = money.CurrentMoney.ToString();

        //save barn
        saveDataAll.saveDataBarn = new SaveDataBarn();
        saveDataAll.saveDataBarn.nameBuilding = barn.nameBuilding;
        saveDataAll.saveDataBarn.level = barn.level;
        saveDataAll.saveDataBarn.maxLevel= barn.maxLevel;
        saveDataAll.saveDataBarn.priceToUpgrade = barn.priceToUpgrade;
        saveDataAll.saveDataBarn.profit = barn.profit;
        saveDataAll.saveDataBarn.unit = barn.unit;

        //save other buildings
        saveDataAll.saveDataOtherBuildings = new List<SaveDataOtherBuilding>(otherBuildings.Count);
        for (int i = 0; i < otherBuildings.Count; ++i)
        {
            saveDataAll.saveDataOtherBuildings.Add(new SaveDataOtherBuilding());
            saveDataAll.saveDataOtherBuildings[i].nameBuilding = otherBuildings[i].nameBuilding;
            saveDataAll.saveDataOtherBuildings[i].level = otherBuildings[i].level;
            saveDataAll.saveDataOtherBuildings[i].maxLevel = otherBuildings[i].maxLevel;
            saveDataAll.saveDataOtherBuildings[i].priceToUpgrade = otherBuildings[i].priceToUpgrade;
            saveDataAll.saveDataOtherBuildings[i].profit = otherBuildings[i].profit;
            saveDataAll.saveDataOtherBuildings[i].unit = otherBuildings[i].unit;
            saveDataAll.saveDataOtherBuildings[i].priceToBuy = otherBuildings[i].priceToBuy;
            saveDataAll.saveDataOtherBuildings[i].profitUpgrade = otherBuildings[i].profitUpgrade;
            saveDataAll.saveDataOtherBuildings[i].isBuild = otherBuildings[i].isBuild;
        }

        //save products
        saveDataAll.saveDataProducts = new List<SaveDataProduct>(products.Count);
        for (int i = 0; i < products.Count; ++i)
        {
            saveDataAll.saveDataProducts.Add(new SaveDataProduct());
            saveDataAll.saveDataProducts[i].nameProduct = products[i].nameProduct;
            saveDataAll.saveDataProducts[i].price = products[i].price;
            saveDataAll.saveDataProducts[i].quantity = products[i].quantity;
        }

        string jsonDataAll = JsonUtility.ToJson(saveDataAll, true);
        File.WriteAllText(savePath, jsonDataAll);
    }

    public void LoadFromJson()
    {
        try
        {
            if (!File.Exists(savePath))
            {
                Debug.Log("No json File Exist");
            }
            else
            {
                Destroy(_introduction);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occurred while checking the existence of the JSON file: " + ex.Message);
        }


        string jsonDataAll = File.ReadAllText(savePath);

        SaveDataAll saveDataAll = JsonUtility.FromJson<SaveDataAll>(jsonDataAll);

        //money
        money.CurrentMoney = long.Parse(saveDataAll.saveDataMoney.money);

        //barn
        barn.nameBuilding = saveDataAll.saveDataBarn.nameBuilding;
        barn.level = saveDataAll.saveDataBarn.level;
        barn.maxLevel = saveDataAll.saveDataBarn.maxLevel;
        barn.priceToUpgrade = saveDataAll.saveDataBarn.priceToUpgrade;
        barn.profit = saveDataAll.saveDataBarn.profit;
        barn.unit = saveDataAll.saveDataBarn.unit;

        //other buildings
        for (int i = 0; i < otherBuildings.Count; ++i)
        {
            otherBuildings[i].nameBuilding = saveDataAll.saveDataOtherBuildings[i].nameBuilding;
            otherBuildings[i].level = saveDataAll.saveDataOtherBuildings[i].level;
            otherBuildings[i].maxLevel = saveDataAll.saveDataOtherBuildings[i].maxLevel;
            otherBuildings[i].priceToUpgrade = saveDataAll.saveDataOtherBuildings[i].priceToUpgrade;
            otherBuildings[i].profit = saveDataAll.saveDataOtherBuildings[i].profit;
            otherBuildings[i].unit = saveDataAll.saveDataOtherBuildings[i].unit;
            otherBuildings[i].priceToBuy = saveDataAll.saveDataOtherBuildings[i].priceToBuy;
            otherBuildings[i].profitUpgrade = saveDataAll.saveDataOtherBuildings[i].profitUpgrade;
            otherBuildings[i].isBuild = saveDataAll.saveDataOtherBuildings[i].isBuild;
        }

        //save products
        for (int i = 0; i < products.Count; ++i)
        {
            products[i].nameProduct = saveDataAll.saveDataProducts[i].nameProduct;
            products[i].price = saveDataAll.saveDataProducts[i].price;
            products[i].quantity = saveDataAll.saveDataProducts[i].quantity;
        }

        //--------------------------------------

        //display money
        money.IncreaseMoney(0);


        //display all panels
        for (int i = 0; i < otherBuildings.Count; ++i)
        {
            if (otherBuildings[i].isBuild)
            {
                BuildBuilding buildBuilding = _buttons[i].GetComponent<BuildBuilding>();
                ProfitableMoney profitableMoney = _buttons[i].GetComponent<ProfitableMoney>();
                ProfitableProduct profitableProduct = _buttons[i].GetComponent<ProfitableProduct>();

                 
                if (buildBuilding != null)
                {
                    buildBuilding.Build();
                }
                if (profitableMoney != null)
                {
                    profitableMoney.CLick();
                }
                if (profitableProduct != null)
                {
                    profitableProduct.Click();
                }
                    
            }
        }
    }
}