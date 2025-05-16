using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        Destroy(GameManager.instance.gameObject);
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Single);
        SceneManager.LoadSceneAsync("Map", LoadSceneMode.Additive);
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
