using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public List<Dialog> m_dialogList = new List<Dialog>();
    public static DialogManager m_dialogManager;

    // Use this for initialization
    void Start()
    {
        m_dialogManager = this;

        //Output text
        m_dialogList[0].modifiedText.text = "Do you want to purchase the upgrade? Upgrade Cost: "
            + UpgradeManager.upgrademanager.m_upgradeList[0].upgradePrice;

        m_dialogList[1].modifiedText.text = "Do you want to purchase the upgrade? Upgrade Cost: "
            + UpgradeManager.upgrademanager.m_upgradeList[1].upgradePrice;

        m_dialogList[2].modifiedText.text = "Do you want to purchase the upgrade? Upgrade Cost: "
          + UpgradeManager.upgrademanager.m_upgradeList[2].upgradePrice;

        m_dialogList[3].modifiedText.text = "Do you want to purchase the upgrade? Upgrade Cost: "
          + UpgradeManager.upgrademanager.m_upgradeList[3].upgradePrice;

        m_dialogList[4].modifiedText.text = "Do you want to purchase the upgrade? Upgrade Cost: "
          + UpgradeManager.upgrademanager.m_upgradeList[4].upgradePrice;

    }
	// Update is called once per frame
	void Update () {
		
	}

    //open a dialogBox  accordingly to the index
    //E.g index = 0 , open the weapon upgrade dialog box
    public void OpenDialog(int index)
    {
        //Enable dialogbox
        m_dialogList[index].dialogBox.SetActive(true);

        //Disable all upgradable buttons
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Dialog");

        foreach (GameObject button in objs)
        {
            button.GetComponent<Button>().interactable = false;
        }

        if (m_dialogList[index].b_isPurchaseSuccess == true)
        {
            m_dialogList[index].modifiedText.text = "You have already purchased the item";
        }
      
    }

    public void CloseDialog(int index)
    {
        //Disable dialogbox
        m_dialogList[index].dialogBox.SetActive(false);

        //Enable all upgradable buttons
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Dialog");

        foreach (GameObject button in objs)
        {
            button.GetComponent<Button>().interactable = true;
        }
    }

    public void ModifiyText(int index , string inputString)
    {
        m_dialogList[index].modifiedText.text = inputString;
    }
}
