using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class DetectHover : MonoBehaviour
     , IPointerEnterHandler
     , IPointerExitHandler
{

    [SerializeField]
    GameObject theObject;

    [SerializeField]
    GameObject thePlane;

   
    public void OnPointerEnter(PointerEventData eventData)
    {
        theObject.SetActive(true);
        thePlane.SetActive(false);
        Debug.Log("hello");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theObject.SetActive(false);
        thePlane.SetActive(true);
        Debug.Log("Bye");
    }
}

