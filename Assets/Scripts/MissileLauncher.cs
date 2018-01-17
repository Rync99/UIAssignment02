using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour {

    [SerializeField]
    GameObject missile;
    bool K_pressed = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.W))
        {
           GameObject go = Instantiate(missile, transform.position, transform.rotation);
            go.GetComponent<Rigidbody>().AddForce(go.transform.forward * 1000);
        }
	}
}
