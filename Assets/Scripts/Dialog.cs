using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

    [SerializeField]
    public GameObject dialogBox;

  
    public void OpenDialog()
    {
        dialogBox.SetActive(true);
  
        //Disable all upgradable buttons
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Dialog");

        foreach (GameObject button in objs)
        {
            button.GetComponent<Button>().interactable = false;
        }

    }

    public void CloseDailog()
    {
        dialogBox.SetActive(false);

        //Disable all upgradable buttons
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Dialog");

        foreach (GameObject button in objs)
        {
            button.GetComponent<Button>().interactable = true;
        }
    }


}
