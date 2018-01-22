using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    public int ID;
    public Image TargetImage;
    public Sprite changeSprite;

    [SerializeField]
    public GameObject theYesObj = null;
    [SerializeField]
    public GameObject theNoObj = null;

    [SerializeField]
    public GameObject theCloseObj = null;

    [SerializeField]
    GameObject[] changedObjects = null;

    [SerializeField]
    Material myNewMaterial = null;

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

        //Set the image accordingly to the correct tag name
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

                    DialogManager.m_dialogManager.ModifiyText(i, "Purchase Successfully!");
                    DialogManager.m_dialogManager.m_dialogList[i].b_isPurchaseSuccess = true;

                    //GameObject.FindGameObjectWithTag("CloseDialogButton").SetActive(true);
                    //GameObject.FindGameObjectWithTag("YesDialogButton").SetActive(false);
                    //GameObject.FindGameObjectWithTag("NoDialogButton").SetActive(false);

                    switch (i)
                    {
                        case 0:
                            StatsSystem.m_stateSystem.IncreaseDamage(20);
                            break;
                        case 1:
                            StatsSystem.m_stateSystem.IncreaseEngine(30);
                            break;
                        case 2:
                            StatsSystem.m_stateSystem.IncreaseSpeed(40);
                            break;
                        case 3:
                            StatsSystem.m_stateSystem.IncreaseFuel(10);
                            break;
                        case 4:
                            StatsSystem.m_stateSystem.IncreaseDamage(10);
                            break;

                    }

                    //Change the material
                    for (int j = 0; j < changedObjects.Length; j++)
                    {
                        if (changedObjects[j].GetComponent<Renderer>().material != null)
                        changedObjects[j].GetComponent<Renderer>().material = myNewMaterial;

                    }

                    //don't render the yes and no button
                    theYesObj.SetActive(false);
                    theNoObj.SetActive(false);
                    //render the close button
                    theCloseObj.SetActive(true);
                    break;
                }
                else if (CurrencyManager.m_currencymanager.RequestCurrency(priceOfUpgrade) == false)
                {
                    DialogManager.m_dialogManager.ModifiyText(i, "You do not have enough coins!");
                    theYesObj.SetActive(false);
                    theNoObj.SetActive(false);
                    //render the close button
                    theCloseObj.SetActive(true);
                    break;

                }
            }

        }

    }


}
