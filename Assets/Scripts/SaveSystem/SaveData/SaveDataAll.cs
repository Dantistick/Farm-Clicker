using System;
using System.Collections.Generic;

[Serializable]
class SaveDataAll
{
    public SaveDataMoney saveDataMoney;
    public SaveDataBarn saveDataBarn;
    public List<SaveDataOtherBuilding> saveDataOtherBuildings;
    public List<SaveDataProduct> saveDataProducts;
}
