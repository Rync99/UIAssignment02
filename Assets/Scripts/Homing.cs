using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour {

    [SerializeField]
    GameObject missileModel = null;

    [SerializeField]
    Rigidbody homingMissile;

    [SerializeField]
    ParticleSystem explosion = null;

    private Transform target;
    private float missileVelocity = 500.0f;

    private float turn = 20.0f;

	// Use this for initialization
	void Start () {

        homingMissile = GetComponent<Rigidbody>();
        Fire();

    }

    void Fire()
    {
     
    }

    void FixedUpdate()
    {
        //Error checking
        if (target == null || homingMissile == null)
            return;

        homingMissile.velocity = transform.forward * missileVelocity ;

        homingMissile.MovePosition( homingMissile.velocity *Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        ParticleSystem thisExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        thisExplosion.Play();
        Destroy(gameObject);
    }
}
