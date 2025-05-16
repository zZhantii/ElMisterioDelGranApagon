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

    private bool partidaIniciada = false;
    public bool PartidaIniciada => partidaIniciada;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("🆕 GameManager asignado y persiste");
        }
        else
        {
            Debug.Log("Duplicado GameManager destruido");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("GameManager Start ejecutado");
        tiempoRestante = tiempoLimite;
        partidaIniciada = false;
        juegoTerminado = false;
    }


    void Update()
    {
        Debug.Log($"Update - partidaIniciada: {partidaIniciada}, juegoTerminado: {juegoTerminado}, tiempoRestante: {tiempoRestante}");

        if (!partidaIniciada || juegoTerminado)
            return;

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

    public void ResetGame()
    {
        Debug.Log("ResetGame llamado");
        tiempoRestante = tiempoLimite;
        pilasTotales = 0;
        pilasRestantes = 4;
        juegoTerminado = false;
        // NO toques partidaIniciada aquí
    }

    public void IniciarJuego()
    {
        Debug.Log("IniciarJuego llamado");
        partidaIniciada = true;
    }


    void TerminarJuego()
    {
        Debug.Log("TerminarJuego llamado");
        juegoTerminado = true;
        partidaIniciada = false;
        // Mostrar menú GameOver (activo el canvas o escena)
        SceneManager.LoadScene("GameOver");
    }

}