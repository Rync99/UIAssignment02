using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMain : MonoBehaviour {

    Health healthscript;

    private bool injured = false;
    private float injuredtimer = 0.0f;
    private float injuredcountdown = 1.0f;

	// Use this for initialization
	void Start ()
    {
        healthscript = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update ()
    {
      if(injured)
        {//Player gets injured every 1 seond of touching the enemy
            injuredtimer += Time.deltaTime;
            if(injuredtimer > injuredcountdown)
            {
                injuredtimer = 0.0f;
                injured = false;
            }
        }
        Debug.Log(healthscript.GetHealthPoints());
    }


    void OnCollisionEnter(Collision collision)
    {
        if (!injured)
        {//when player collides with enemy
            healthscript.AddHealth(-10);//reduce health
            injured = true;
        }
    }
}
