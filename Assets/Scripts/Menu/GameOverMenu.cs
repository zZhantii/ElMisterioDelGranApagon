using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{
    public void ReiniciarJuego()
{
    GameManager.instance.ResetGame();
    SceneManager.LoadScene("MainLevel", LoadSceneMode.Single);

    SceneManager.LoadScene("Map", LoadSceneMode.Additive);

    GameManager.instance.IniciarJuego();
}



    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.ResetGame();
    }
}
