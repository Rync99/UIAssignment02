using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Remove Monobehavior , to allow System.Serializable to work 
// allow modifications of the variables below , through the inspector
[System.Serializable]
public class Upgrade {

    public string upgradeName;
    public int upgradeID;
    public int upgradePrice;

    public Sprite BroughtSprite;
    public Sprite unBroughSprite;

    public bool isBought = false;
     
   
}
