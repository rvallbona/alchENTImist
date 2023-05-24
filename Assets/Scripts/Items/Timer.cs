using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] int min, seg;
    TextMeshProUGUI time;

    private float restante;
    private bool running;

    private void Awake()
    {
        restante = (min * 60) + seg;
        running = true;
    }
    void Start()
    {
        time = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
        if (running)
        {
            restante -= Time.deltaTime;
            if (restante < 1)
            {
                running = false;
                //Cambiar pedido i mostrar que no se ha podido completar el pedido i resetear a 3 mins el temporizador
                Debug.Log("No has podido completar el pedido");
                ResetTimer();
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            time.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
    void ResetTimer()
    {
        restante = min * 60;
        running = true;
    }
}
