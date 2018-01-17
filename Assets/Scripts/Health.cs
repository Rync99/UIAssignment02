using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float healthPoints = 100.0f;
    bool P_keypressed = false;
    bool b_smoking = false;
    // Uber cool this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P) && !P_keypressed)
        {
            AddHealth(-10);
            P_keypressed = true;
            // GameObject.FindWithTag("ShipSmoke").GetComponent<ParticleSystem>().Play();
        }
        else if (!Input.GetKey(KeyCode.P))
        {
            P_keypressed = false;
        }
        if (healthPoints < 70 && !b_smoking)
        {
            GameObject.FindWithTag("ShipSmoke").GetComponent<ParticleSystem>().Play();
            b_smoking = true;
        }
    }

    public void AddHealth(float amt)
    {
        healthPoints += amt;
        //more than maxhealth, equals max health
    }
    public float GetHealthPoints()
    {
        return healthPoints;
    }
}
