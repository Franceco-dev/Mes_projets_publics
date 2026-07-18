using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour 
{
    public AudioMixer audioMixer; // c'est une classe 3K ^-^

    public TMP_Dropdown resolutionDropdown;
    
    Resolution[] resolutions; // c'est un array Toby serais content
    public void Start()
    {
        resolutions = Screen.resolutions;
        if (resolutionDropdown != null)
        {
            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height;
                options.Add(option);

                if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)// si la resolution de l'écran est égale à la longueur et largeur de l'écran on l'active

                {
                    currentResolutionIndex = i; // résolution actuelle est égale à la valeur de notre écran 
                } 
            }
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex; // valeur active est égale à la résolution du joueur 
            resolutionDropdown.RefreshShownValue();

            Screen.fullScreen = true;
        }
        
    }
    public void SettVolume(float volume) // c'est une méthode parmis les millier dans la poo
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetfullScreen(bool isFullScreen) // méthode qui permet de entrer en full screen grâce à une variable de type bool d'après ce que j'ai compris
    {
        Screen.fullScreen = isFullScreen; // on compare si full screen est true ou false
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
