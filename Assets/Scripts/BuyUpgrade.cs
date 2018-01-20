using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgrade : MonoBehaviour
{
    public int ID;

    public void Purchase()
    {
        //Loop through the UpgradeList to check which item is selected to be bought
        for(int i = 0; i < UpgradeManager.upgrademanager.m_upgradeList.Count; i++)
        {
            if(UpgradeManager.upgrademanager.m_upgradeList[i].upgradeID == ID)
            {
                int priceOfUpgrade = UpgradeManager.upgrademanager.m_upgradeList[i].upgradePrice;

                //Have enough currency to buy the upgrade and the upgrade has not been bought
                if (CurrencyManager.m_currencymanager.RequestCurrency(priceOfUpgrade) == true &&
                    UpgradeManager.upgrademanager.m_upgradeList[i].isBought == false)
                {
                    CurrencyManager.m_currencymanager.AddCurrency(-priceOfUpgrade);
                    UpgradeManager.upgrademanager.m_upgradeList[i].isBought = true;


                }
            }

        }

    }


}
