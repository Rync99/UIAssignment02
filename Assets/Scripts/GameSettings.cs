using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to play the same settings changed in the option menu
public class GameSettings : MonoBehaviour
{

    public static int resolutionIndex;

    public static float musicVolume = 1.0f;


    void Start()
    {
        GameObject Object = GameObject.FindGameObjectWithTag("InGameMusic");
        if (Object != null)
        {
            GameObject.FindGameObjectWithTag("InGameMusic").GetComponent<AudioSource>().volume = musicVolume;
        }

        //GameObject Object2 = GameObject.FindGameObjectWithTag("Music1");
        //if (Object2 != null)
        //GameObject.FindGameObjectWithTag("Music1").GetComponent<AudioSource>().volume = musicVolume;

        GameObject[] multipleObjects = GameObject.FindGameObjectsWithTag("Music1");

        if (multipleObjects != null)
        {
            //Adjust the volume of main menu , shop (they all have the same music)
            foreach (var obj in GameObject.FindGameObjectsWithTag("Music1"))
            {
                AudioSource sourceAudio = obj.GetComponent<AudioSource>();
                sourceAudio.volume = musicVolume;
            }
        }

    }


}
