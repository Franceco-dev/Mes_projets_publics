using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

// Beaucoup de bibliothèques ici ^-^.
public class SettingsMenu : MonoBehaviour // Ici j'ai regardé un gros tutoriel de 1h. C'était l'une des parties les plus techniques : beaucoup de méthodes et de fonctions techniques, bref...
{
    public AudioMixer audioMixer; // C'est une classe ^-^.

    public TMP_Dropdown resolutionDropdown;
    
    Resolution[] resolutions; // C'est un array qui permet de mettre plusieurs informations dedans.
    public void Start() 
    {
        resolutions = Screen.resolutions; // On trouve toutes les possibilités de résolution de l'écran du joueur.
        if (resolutionDropdown != null)
        {
            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0; // Retenir la résolution actuelle du moniteur.

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height;
                options.Add(option);

                if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)// Option qui correspond à la résolution du joueur.
                {
                    currentResolutionIndex = i; // La résolution actuelle est égale à la valeur de notre écran. 
                } 
            }
            resolutionDropdown.AddOptions(options); 
            resolutionDropdown.value = currentResolutionIndex; // La valeur active est égale à la résolution du joueur. 
            resolutionDropdown.RefreshShownValue();

            Screen.fullScreen = true; // État du plein écran à vrai.
        }
        
    }
    public void SettVolume(float volume) // Une méthode pour le volume : on donne l'information de départ, à savoir la valeur du volume.
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetfullScreen(bool isFullScreen) // Méthode qui permet d'entrer en plein écran grâce à une variable de type bool d'après ce que j'ai compris.
    {
        Screen.fullScreen = isFullScreen; // On applique le choix du joueur (vrai ou faux) s'il veut du plein écran.
    }

    public void SetResolution(int resolutionIndex) // On peut changer la résolution du jeu grâce à cette méthode.
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); // On applique la nouvelle largeur et hauteur grâce à notre choix.
    }
}
