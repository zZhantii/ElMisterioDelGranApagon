using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform personaje;
    private float tamañoPantalla;
    private float alturaPantalla;
    void Start()
    {
        tamañoPantalla = Camera.main.orthographicSize;
        alturaPantalla = tamañoPantalla * 2;
    }

    void Update()
    {

    }

    void calcularPosicion()
    {
        int pantallaPersonaje = (int)(personaje.position.y / alturaPantalla);
        float alturaCamara = (pantallaPersonaje * alturaPantalla) + tamañoPantalla;

        transform.position = new Vector3(transform.position.x, alturaCamara, transform.position.z);
    }
}