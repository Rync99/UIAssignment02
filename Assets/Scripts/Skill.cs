using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skill 
{
    public bool hasbeenBought;
    public Button button;
    public ParticleSystem ps;
	// Use this for initialization
	void Start ()
    {
        hasbeenBought = false;
        ps.Stop();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
