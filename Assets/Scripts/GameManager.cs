using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int PilasTotales { get { return pilasTotales; } }
    private int pilasRestantes = 4;
    public int PilasRestantes { get { return pilasRestantes; } }
    private int pilasTotales;

    float tiempoLimite = 5f;
    float tiempoRestante;
    public float TiempoRestante { get { return tiempoRestante; } }
    private bool juegoTerminado = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        tiempoRestante = tiempoLimite;
    }

    void Update()
    {
        if (juegoTerminado)
        {
            return;
        }

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            TerminarJuego();
        }
    }

    public void sumarPilas(int pilasSumar)
    {
        pilasTotales += pilasSumar;
    }

    void TerminarJuego()
    {
        juegoTerminado = true;
        // SceneManager.LoadScene("GameOver");
    }
}