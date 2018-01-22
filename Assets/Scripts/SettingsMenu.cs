using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public Dropdown resolutionDropDown = null;
    public Slider musicVolumeSlider;
    public AudioSource musicSource;

    private static float defaultSliderValue = 1;

    Resolution[] resolutions = null;

    // Use this for initialization
    void Start()
    {

        //If there are any default slider value , set it to the slider
        musicVolumeSlider.value = defaultSliderValue;

        ////Set default music volume
        SetMusicVolume();

        //Clear previous option
        resolutionDropDown.ClearOptions();

        //Container that stored only unique value
        HashSet<string> uniqueStringHash = new HashSet<string>();

        List<string> optionsList = new List<string>();

        //get  all the resolution
        resolutions = Screen.resolutions;

        for (int i = 0; i < resolutions.Length; i++)
        {
            //Formated string
            string option = resolutions[i].width + " x " + resolutions[i].height;

            uniqueStringHash.Add(option);

        }
        //loop through the hashset and stored it into list
        foreach (var storedValue in uniqueStringHash)
        {
            optionsList.Add(storedValue);
        }

        //Add the optionList into the dropdown list
        resolutionDropDown.AddOptions(optionsList);
        resolutionDropDown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionDropDown.value].width, resolutions[resolutionDropDown.value].height, true);
        //GameSettings.theGameConfig.resolutionIndex = resolutionDropDown.value;
    }

    public void SetMusicVolume()
    {
        GameSettings.musicVolume = musicSource.volume = musicVolumeSlider.value ;
        defaultSliderValue = musicVolumeSlider.value;
    }


}
