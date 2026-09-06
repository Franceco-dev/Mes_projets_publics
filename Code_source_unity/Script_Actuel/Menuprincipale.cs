using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour // Corrigé : Principal (sans e)
{
    public string levelToLoad; // Corrigé : ToLoad (L majuscule). Variable de type chaîne de caractères

    public GameObject settingsWindow;
    
    public void StartGame() // Méthode pour commencer le jeu
    {
        SceneManager.LoadScene(levelToLoad); // On charge la scène pour commencer le jeu
    }

    public void SettingButton() // Méthode pour interagir avec settingsWindow
    {
        settingsWindow.SetActive(true); // Si on clique sur les options, on active la fenêtre
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame() // Méthode qui permet de quitter le jeu 
    {
        Application.Quit(); // On quitte l'application tout simplement ^-^
    }
}
