using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuSystem : MonoBehaviour
{
    private bool juegoPausado = false;
    private bool menuCargado = false;
    private bool enTransicion = false;

    public static MenuSystem Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !enTransicion)
        {
            if (juegoPausado)
                Continuar();
            else
                Pausar();
        }
    }

    public void Pausar()
    {
        if (menuCargado || enTransicion) return;

        enTransicion = true;

        Time.timeScale = 0f;
        juegoPausado = true;

        SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive).completed += (asyncOperation) =>
        {
            menuCargado = true;
            enTransicion = false;

            ConfigurarBotonesPausa();
        };
    }

    private void ConfigurarBotonesPausa()
    {
        StartCoroutine(ConfigurarBotonesCoroutine());
    }

    private IEnumerator ConfigurarBotonesCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        Canvas[] todosLosCanvas = FindObjectsByType<Canvas>(FindObjectsSortMode.None);

        if (todosLosCanvas.Length == 0)
        {
            Debug.LogWarning("No se encontró ningún Canvas en la escena PauseMenu.");
            yield break;
        }

        foreach (Canvas canvas in todosLosCanvas)
        {
            Button[] botones = canvas.GetComponentsInChildren<Button>(true);

            foreach (Button boton in botones)
            {
                if (boton.name.Contains("Continuar"))
                {
                    boton.onClick.RemoveAllListeners();

                    boton.onClick.AddListener(() =>
                    {
                        Continuar();
                    });
                }
                else if (boton.name.Contains("Salir"))
                {
                    boton.onClick.RemoveAllListeners();

                    boton.onClick.AddListener(() =>
                    {
                        Salir();
                    });
                }
                else if (boton.name.Contains("Ayuda"))
                {
                    boton.onClick.RemoveAllListeners();

                    boton.onClick.AddListener(() =>
                    {
                        MostrarAyuda();
                    });
                }
            }

        }
    }

    public void Continuar()
    {
        if (!menuCargado || enTransicion) return;

        enTransicion = true;

        Time.timeScale = 1f;
        juegoPausado = false;

        SceneManager.UnloadSceneAsync("PauseMenu").completed += (asyncOperation) =>
        {
            menuCargado = false;
            enTransicion = false;
        };
    }

    public void MostrarAyuda()
    {
        SceneManager.LoadScene("Help");
    }

    public void Salir()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.ResetGame();
    }
}