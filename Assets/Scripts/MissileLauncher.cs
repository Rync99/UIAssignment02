using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour {

    [SerializeField]
    GameObject missile = null;

 
    public void LaunchMissile()
    {
        GameObject go = Instantiate(missile, transform.position, transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(go.transform.forward * 1000);
    }
	
	
}
