using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class DetectHover : MonoBehaviour
     , IPointerEnterHandler
     , IPointerExitHandler
{

    [SerializeField]
    GameObject theObject = null;

    [SerializeField]
    GameObject thePlane = null;

    public enum STAT_TYPE
    {
        WEAPON_STAT,
        ENGINE_STAT,
        WING_STAT,
        BOOSTER_STAT,
        BODY_STAT,
    }

    [SerializeField]
    STAT_TYPE typeState = STAT_TYPE.WEAPON_STAT;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Set the GameObject's active = true to render
        theObject.SetActive(true);
        thePlane.SetActive(false);
        Debug.Log("hello");


        //E.g if mouse is hover the weapon button, only show the damage stats
        // while other stats == zero
        switch (typeState)
        {
            case STAT_TYPE.WEAPON_STAT:
                StatsSystem.m_stateSystem.SetDamageStats();
                break;
            case STAT_TYPE.ENGINE_STAT:
                StatsSystem.m_stateSystem.SetEngineStats();
                break;
            case STAT_TYPE.WING_STAT:
                StatsSystem.m_stateSystem.SetSpeedStats();
                break;
            case STAT_TYPE.BOOSTER_STAT:
                StatsSystem.m_stateSystem.SetFuelStats();
                break;
            case STAT_TYPE.BODY_STAT:
                StatsSystem.m_stateSystem.SetHealthStats();
                break;

        }

     
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //  //Set the GameObject's active = false to NOT render
        theObject.SetActive(false);
        thePlane.SetActive(true);
        Debug.Log("Bye");

        //Restore the default stats(the ship stats) when the mouse is not hovered over it
        StatsSystem.m_stateSystem.UnSetStats();
    }
}

