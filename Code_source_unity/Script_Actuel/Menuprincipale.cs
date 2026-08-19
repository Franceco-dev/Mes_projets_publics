using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuprincipale : MonoBehaviour
{
    public string levelToload; // variable de type plusieur caractère

    public GameObject settingsWindow;
    public void StartGame() // methode pour commencer le jeu
    {
        SceneManager.LoadScene(levelToload); // on charge la scene pour commencer le jeu
    }

    public void SettingButton() // méthode pour interagir avec settingsWindows
    {
        settingsWindow.SetActive(true); //si on clique sur les options on met à true les paramètres
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame() // methode qui permet de quitter le jeu 
    {
        Application.Quit(); // on quitte l'application tout simplement ^-^
    }
}
