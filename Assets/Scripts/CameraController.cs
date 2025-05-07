using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform personaje;
    private float tamañoPantalla;
    private float alturaPantalla;
    void Start()
    {
        tamañoPantalla = Camera.main.orthographicSize ;
        alturaPantalla = tamañoPantalla * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
