using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        GameManager.instance.ResetGame();
        // Debug.Log("Reiniciando juego...");
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Single);

        SceneManager.LoadScene("Map", LoadSceneMode.Additive);
        // Debug.Log("iniciando juego...");
        GameManager.instance.IniciarJuego2();
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.ResetGame();
    }
}
