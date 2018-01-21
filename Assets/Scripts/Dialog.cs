using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialog  {

    [SerializeField]
    public GameObject dialogBox;

    //dialogBoxID is the same as UpgradeID
    [SerializeField]
    public int dialogBoxID;

    [SerializeField]
    public Text modifiedText;

    public bool b_isPurchaseSuccess = false;

}
