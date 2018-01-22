using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour {

    [SerializeField]
    GameObject missileModel = null;

    [SerializeField]
    Rigidbody homingMissile;

    private Transform target;
    private float missileVelocity = 300.0f;

    private float turn = 20.0f;

	// Use this for initialization
	void Start () {

        homingMissile = GetComponent<Rigidbody>();
        Fire();

    }

    void Fire()
    {
        var distance = Mathf.Infinity;

        //Find all the enemy game objects
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject go in gos)
        {
            var diff = (go.transform.position - transform.position).sqrMagnitude;

            //Find which enemy game object has the shortest distance with the homing missile
            if (diff < distance)
            {
                distance = diff;
                target = go.transform;
            }
        }
    }

    void FixedUpdate()
    {
        //Error checking
        if (target == null || homingMissile == null)
            return;

        homingMissile.velocity = transform.forward * missileVelocity ;

        //Rotate towards target
        var targetRotation = Quaternion.LookRotation(target.position - transform.position);
        homingMissile.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destroy missile game object upon collision with enemy
       if(collision.gameObject.name == "Enemy")
        {
            Destroy(missileModel.gameObject);
        }
    }
}
