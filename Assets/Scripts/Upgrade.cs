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

    public bool isBought = false;
     
   
}
