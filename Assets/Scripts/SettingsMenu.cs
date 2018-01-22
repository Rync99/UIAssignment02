using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public Dropdown resolutionDropDown;
    public AudioMixer audioMixer;

    Resolution[] resolutions;

    // Use this for initialization
    void Start()
    {
        resolutions = Screen.resolutions;
        //Clear previous option
        resolutionDropDown.ClearOptions();

        List<string> optionsList = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            //Formated string
            string option = resolutions[i].width + " x " + resolutions[i].height;
            //add the Formated string into the optionList
            optionsList.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }


        }

        //Add the optionList into the dropdown list
        resolutionDropDown.AddOptions(optionsList);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);

    }




}
