using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuprincipale : MonoBehaviour
{
    public string levelToload; // variable de type plusieur caractère

    public GameObject settingsWindow;
    public void StartGame()
    {
        SceneManager.LoadScene(levelToload);
    }

    public void SettingButton() // méthode parmis tant d'atre pour interagir avec settingsWindow
    {
        settingsWindow.SetActive(true); //si on clique sur les options on met à true les paramètre
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
