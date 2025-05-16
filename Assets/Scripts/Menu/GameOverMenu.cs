using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Single);
        SceneManager.LoadSceneAsync("Map", LoadSceneMode.Additive);

        GameManager.instance.ResetGame();
        GameManager.instance.IniciarJuego();
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.ResetGame();
    }
}
