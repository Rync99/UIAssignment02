using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsSystem : MonoBehaviour
{
   public static StatsSystem m_stateSystem;


    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float health;
    [SerializeField]
    private float fuel;
    [SerializeField]
    private float engine;


    private float maxspeed = 100.0f;
    private float maxdamage = 100.0f;
    private float maxhealth = 100.0f;
    private float maxfuel = 100.0f;
    private float maxengine = 100.0f;

    public Slider[] sliderArray;


    // Use this for initialization
    void Start()
    {
        m_stateSystem = this;

        sliderArray[0].value = CaculateHealth();
        sliderArray[1].value = CaculateSpeed();
        sliderArray[2].value = CaculateEngine();
        sliderArray[3].value = CaculateFuel();
        sliderArray[4].value = CaculateDamage();
    }


    float CaculateHealth()
    {
        return health / maxhealth;
    }

    public void IncreaseHealth(float increaseValue)
    {
        health += increaseValue;
        sliderArray[0].value = CaculateHealth();
    }


    public void SetHealthStats()
    {
        sliderArray[0].value = CaculateHealth();
        sliderArray[1].value = 0;
        sliderArray[2].value = 0;
        sliderArray[3].value = 0;
        sliderArray[4].value = 0;
    }

    public void UnSetStats()
    {
        sliderArray[0].value = CaculateHealth();
        sliderArray[1].value = CaculateSpeed();
        sliderArray[2].value = CaculateEngine();
        sliderArray[3].value = CaculateFuel();
        sliderArray[4].value = CaculateDamage();
    }


    //----------------------------------------------

    float CaculateSpeed()
    {
        return speed / maxspeed;
    }

    public void IncreaseSpeed(float increaseValue)
    {
        speed += increaseValue;
        sliderArray[1].value = CaculateSpeed();
    }

    public void SetSpeedStats()
    {
        sliderArray[0].value = 0;
        sliderArray[1].value = CaculateSpeed();
        sliderArray[2].value = 0;
        sliderArray[3].value = 0;
        sliderArray[4].value = 0;
    }

    //----------------------------------------------

    float CaculateEngine()
    {
        return engine / maxengine;
    }

    public void IncreaseEngine(float increaseValue)
    {
        engine += increaseValue;
        sliderArray[2].value = CaculateEngine();
    }

    public void SetEngineStats()
    {
        sliderArray[0].value = 0;
        sliderArray[1].value = 0;
        sliderArray[2].value = CaculateEngine();
        sliderArray[3].value = 0;
        sliderArray[4].value = 0;
    }


    //----------------------------------------------

    float CaculateFuel()
    {
        return fuel / maxfuel;
    }

    public void IncreaseFuel(float increaseValue)
    {
        fuel += increaseValue;
        sliderArray[3].value = CaculateFuel();
    }

    public void SetFuelStats()
    {
        sliderArray[0].value = 0;
        sliderArray[1].value = 0;
        sliderArray[2].value = 0;
        sliderArray[3].value = CaculateFuel();
        sliderArray[4].value = 0;
    }



    //----------------------------------------------

    float CaculateDamage()
    {
        return damage / maxdamage;
    }

    public void IncreaseDamage(float increaseValue)
    {
        damage += increaseValue;
        sliderArray[4].value = CaculateDamage();
    }

    public void SetDamageStats()
    {
        sliderArray[0].value = 0;
        sliderArray[1].value = 0;
        sliderArray[2].value = 0;
        sliderArray[3].value = 0;
        sliderArray[4].value = CaculateDamage();
    }

}
