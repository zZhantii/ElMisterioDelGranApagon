using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int PilasTotales { get { return pilasTotales; } }
    private int pilasTotales ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sumarPilas(int pilasSumar)
    {
        pilasTotales += pilasSumar;
        Debug.Log("Pilas totales: " + pilasTotales);
    }
}
