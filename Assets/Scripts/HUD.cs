using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI pilas;
    public TextMeshProUGUI time;
    void Start()
    {

    }

    void Update()
    {
        pilas.text = GameManager.instance.PilasTotales.ToString() + " / " + GameManager.instance.PilasRestantes.ToString();

        time.text = GameManager.instance.TiempoRestante.ToString("F0") + " s";
    }
}