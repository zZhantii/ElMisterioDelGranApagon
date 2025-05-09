using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{

    public int PilasTotales { get { return pilasTotales; } }
    private int pilasRestantes = 3;
    public int PilasRestantes { get { return pilasRestantes; } }
    private int pilasTotales;

    float tiempoLimite = 20f;
    float tiempoRestante;
    public float TiempoRestante { get { return tiempoRestante; } }
    private bool juegoTerminado = false;

    public Light2D luzDelJugador;

    void Start()
    {
        tiempoRestante = tiempoLimite;

        if (luzDelJugador == null)
        {
            luzDelJugador = FindObjectOfType<Light2D>();
            Debug.Log("Se ha encontrado la luz del jugador: " + luzDelJugador);

            if (luzDelJugador == null)
            {
                Debug.Log("No se encontró ninguna Light2D en la escena.");
            }
        }
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
        aumentarBrillo();
    }

    void TerminarJuego()
    {
        juegoTerminado = true;
        Debug.Log("Juego terminado. Tiempo agotado.");
    }

    void aumentarBrillo()
    {
        if (luzDelJugador != null)
        {
            luzDelJugador.pointLightOuterAngle += 5f;

            luzDelJugador.pointLightOuterRadius += 1f;

            Debug.Log("Aumentando luz: ángulo " + luzDelJugador.pointLightOuterAngle + ", radio " + luzDelJugador.pointLightOuterRadius);
        }
        else
        {
            Debug.Log("No se ha asignado la luz del jugador.");
        }
    }

}