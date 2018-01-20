using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    public int ID;
    public Image TargetImage;
    public Sprite changeSprite;
    public Text OutPutText;

    [SerializeField]
    public GameObject theYesObj;
    [SerializeField]
    public GameObject theNoObj;

    [SerializeField]
    public GameObject theCloseObj;

    public enum ImageType
    {
        WEAPON_IMAGE,
        ENGINE_IMAGE,
        WINGS_IMAGE,
        BOOSTER_IMAGE,
        BODY_IMAGE,
    }

    public ImageType imageType;


    public void Start()
    {
  
        switch (imageType)
        {
            case ImageType.WEAPON_IMAGE:
                TargetImage = GameObject.FindGameObjectWithTag("ImageWeapon").GetComponent<Image>();
                break;
            case ImageType.ENGINE_IMAGE:
                TargetImage = GameObject.FindGameObjectWithTag("ImageEngine").GetComponent<Image>();
                break;
            case ImageType.WINGS_IMAGE:
                TargetImage = GameObject.FindGameObjectWithTag("ImageWing").GetComponent<Image>();
                break;
            case ImageType.BOOSTER_IMAGE:
                TargetImage = GameObject.FindGameObjectWithTag("ImageBooster").GetComponent<Image>();
                break;
            case ImageType.BODY_IMAGE:
                TargetImage = GameObject.FindGameObjectWithTag("ImageBody").GetComponent<Image>();
                break;

        }

    }

    public void Purchase()
    {
        //Loop through the UpgradeList to check which item is selected to be bought
        for (int i = 0; i < UpgradeManager.upgrademanager.m_upgradeList.Count; i++)
        {
            if (UpgradeManager.upgrademanager.m_upgradeList[i].upgradeID == ID)
            {
                int priceOfUpgrade = UpgradeManager.upgrademanager.m_upgradeList[i].upgradePrice;

                //Have enough currency to buy the upgrade and the upgrade has not been bought
                if (CurrencyManager.m_currencymanager.RequestCurrency(priceOfUpgrade) == true &&
                    UpgradeManager.upgrademanager.m_upgradeList[i].isBought == false)
                {
                    CurrencyManager.m_currencymanager.AddCurrency(-priceOfUpgrade);
                    UpgradeManager.upgrademanager.m_upgradeList[i].isBought = true;
                    TargetImage.sprite = changeSprite;
                    OutPutText.text = "Purchase Successfully!";

                    //GameObject.FindGameObjectWithTag("CloseDialogButton").SetActive(true);
                    //GameObject.FindGameObjectWithTag("YesDialogButton").SetActive(false);
                    //GameObject.FindGameObjectWithTag("NoDialogButton").SetActive(false);

                    theYesObj.SetActive(false);
                    theNoObj.SetActive(false);
                    theCloseObj.SetActive(true);
                }
                else if (CurrencyManager.m_currencymanager.RequestCurrency(priceOfUpgrade) == false)
                {
                    OutPutText.text = "You do not have enough coins";
                }
            }

        }

    }


}
