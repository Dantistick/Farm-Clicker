using System;

[Serializable]
class SaveDataOtherBuilding
{
    public string nameBuilding;
    public short level = 1;
    public short maxLevel;
    public long priceToUpgrade;
    public long profit;
    public string unit;
    public long priceToBuy;
    public long profitUpgrade;
    public bool isBuild = false;
}