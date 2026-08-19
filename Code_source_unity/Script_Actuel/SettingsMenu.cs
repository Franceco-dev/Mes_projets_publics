using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
//beaucoup de bibliothèque ici ^-^ 
public class SettingsMenu : MonoBehaviour //ici j'ai regardé un gros tutoriel de 1h c'était l'une des parties les plus technique beacuoup de méthode, de fonctions technique bref...
{
    public AudioMixer audioMixer; // c'est une classe ^-^

    public TMP_Dropdown resolutionDropdown;
    
    Resolution[] resolutions; // c'est un array qui pemet de mette plusieur information dedans
    public void Start() 
    {
        resolutions = Screen.resolutions; // on trouve toute les possiblités de reslution de l'écran du joueur
        if (resolutionDropdown != null)
        {
            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0; // retenir la resolution actuelle du moniteur

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height;
                options.Add(option);

                if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)// option qui correspond à la reslution du joueur

                {
                    currentResolutionIndex = i; // résolution actuelle est égale à la valeur de notre écran 
                } 
            }
            resolutionDropdown.AddOptions(options); 
            resolutionDropdown.value = currentResolutionIndex; // valeur active est égale à la résolution du joueur 
            resolutionDropdown.RefreshShownValue();

            Screen.fullScreen = true; // etat du pleine écran à vrai
        }
        
    }
    public void SettVolume(float volume) // une methode pour le volume on donne l'information de départ à savoir la valeu du volume
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetfullScreen(bool isFullScreen) // méthode qui permet de entrer en full screen grâce à une variable de type bool d'après ce que j'ai compris
    {
        Screen.fullScreen = isFullScreen; // on applique le choix du joueur vrai ou faux si il veut en pleine écran
    }

    public void SetResolution(int resolutionIndex) //on peut changer la resolution du jeu grâce à cette méthode
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); // on applique la nouvelle largeur et hauteur grâce à note choix
    }
}
