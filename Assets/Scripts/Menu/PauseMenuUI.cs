using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public void ContinuarJuego()
    {
        // Llama al MenuSystem en la escena MainLevel
        MenuSystem menu = FindObjectOfType<MenuSystem>();
        if (menu != null)
        {
            menu.Continuar();
        }
    }

    public void VolverAlMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
