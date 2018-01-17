using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    float movementSpeed = 10;
    [SerializeField]
    ParticleSystem explosion;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.up * movementSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        //Health healthscript = other.GetComponent<Health>();

        //if (healthscript != null)
        //{
        //    ParticleSystem thisExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        //    thisExplosion.Play();
        //    healthscript.AddHealth(-10);
        //}
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        ParticleSystem thisExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        thisExplosion.Play();
        Destroy(gameObject);
    }
}
