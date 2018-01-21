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

    public enum STAT_TYPE
    {
        WEAPON_STAT,
        ENGINE_STAT,
        WING_STAT,
        BOOSTER_STAT,
        BODY_STAT,
    }

    [SerializeField]
    STAT_TYPE typeState;

    public void OnPointerEnter(PointerEventData eventData)
    {
        theObject.SetActive(true);
        thePlane.SetActive(false);
        Debug.Log("hello");


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
        theObject.SetActive(false);
        thePlane.SetActive(true);
        Debug.Log("Bye");

        StatsSystem.m_stateSystem.UnSetStats();
    }
}

