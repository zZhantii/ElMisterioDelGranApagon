using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI pilas;
    public TextMeshProUGUI time;
    
    void Update()
    {
        if (GameManager.instance == null)
        {
            return;
        }

        pilas.text = GameManager.instance.PilasTotales + " / " + GameManager.instance.PilasRestantes;
        time.text = GameManager.instance.TiempoRestante.ToString("F0") + " s";
    }


}