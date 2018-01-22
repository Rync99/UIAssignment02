using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReturnToGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToShop()
    {
        SceneManager.LoadScene(2);
    }

    public void ReturnToOptionMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void ReturnToSkillTree()
    {
        SceneManager.LoadScene(4);
    }
}
