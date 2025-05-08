using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI pilas;
    public TextMeshProUGUI time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pilas.text = gameManager.PilasTotales.ToString() + " / " + gameManager.PilasRestantes.ToString();

        time.text = gameManager.TiempoRestante.ToString("F0") + " s";
    }
}
