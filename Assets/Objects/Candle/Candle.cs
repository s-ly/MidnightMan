using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] Light LightCandle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CandleGoesOut()
    {
        LightCandle.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, имеет ли столкнувшийся объект тег "Water"
        if (other.CompareTag("Water"))
        {            
            CandleGoesOut();
        }
        // Проверяем, имеет ли столкнувшийся объект тег "Wind"
        if (other.CompareTag("Wind"))
        {
            //CandleGoesOut();
            StartCoroutine(TimerCoroutine());            
        }
    }
    IEnumerator TimerCoroutine()
    {
        // Обратный отсчет 5 секунд
        for (int i = 3; i > 0; i--)
        {
            Debug.Log("Countdown: " + i);
            yield return new WaitForSeconds(1);
        }

        // Вызываем метод после завершения обратного отсчета
        Debug.Log("TimerCoroutine : finished!");
        CandleGoesOut();
    }
}
