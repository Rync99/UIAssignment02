﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    GameObject ship = null;
 

    Vector3 ship_position;
 
    public void QuitGame()
    {
        Debug.Log("Quit");

        if (Application.platform == RuntimePlatform.Android)
        {
            Application.Quit();
        }
    }

    public void Start()
    {
        ship.GetComponent<Rigidbody>().AddForce(ship.transform.forward * 2.0f, ForceMode.VelocityChange);
        ship_position = ship.transform.position;
    }

    public void Update()
    {
        if (ship == null)
            return;


        Camera mainCam = GameObject.FindWithTag("UICamera").GetComponent<Camera>();

       // Debug.Log(mainCam.WorldToScreenPoint(ship.transform.position).x);

        if (mainCam.WorldToScreenPoint(ship.transform.position).x <= -50)
        {
            ship.transform.position = new Vector3(ship_position.x, ship_position.y, ship_position.z);
        }
    }

    void OnCollisionEnter(Collision other)
    {

    }
}
