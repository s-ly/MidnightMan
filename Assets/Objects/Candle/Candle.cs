using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] Light LightCandle;
    [SerializeField] ParticleSystem particleSystem;
    Coroutine timerCoroutine; // Ссылка на корутину
    int CandleTimer = 5;
    public bool candleCovered = false;
    float intensityHi = 160;
    float intensityMiddle = 15;

    // Start is called before the first frame update
    void Start()
    {
        LightCandle.intensity = intensityHi;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CandleGoesOut()
    {
        LightCandle.enabled = false;
        particleSystem.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, имеет ли столкнувшийся объект тег "Water"
        if (other.CompareTag("Water") && !candleCovered)
        {
            CandleGoesOut();
        }
        // Проверяем, имеет ли столкнувшийся объект тег "Wind"
        if (other.CompareTag("Wind") && !candleCovered)
        {
            //CandleGoesOut();
            timerCoroutine = StartCoroutine(TimerCoroutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {

        // Проверяем, имеет ли столкнувшийся объект тег "Wind"
        if (other.CompareTag("Wind"))
        {
            StopTimerCoroutine();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Проверяем, имеет ли столкнувшийся объект тег "Wind"
        if (other.CompareTag("Wind") && !candleCovered)
        {
            if (timerCoroutine == null)
            {
              timerCoroutine = StartCoroutine(TimerCoroutine());
            }
            //timerCoroutine = null;
            //timerCoroutine = StartCoroutine(TimerCoroutine());
        }

        // Проверяем, имеет ли столкнувшийся объект тег "Water"
        if (other.CompareTag("Water") && !candleCovered)
        {
            CandleGoesOut();
        }
    }

    IEnumerator TimerCoroutine()
    {
        int timerStart = CandleTimer;
        // Обратный отсчет 5 секунд
        for (int i = timerStart; i > 0; i--)
        {
            Debug.Log("Countdown: " + i);
            yield return new WaitForSeconds(1);
        }

        // Вызываем метод после завершения обратного отсчета
        Debug.Log("TimerCoroutine : finished!");
        CandleGoesOut();
    }

    void StopTimerCoroutine()
    {
        // Проверяем, запущена ли корутина, и останавливаем ее
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            Debug.Log("Countdown stopped!");
            timerCoroutine = null;
        }
    }

    public void CandleCoveredSwitch()
    {
        candleCovered = !candleCovered;
        Debug.Log("candleCovered switch = " + candleCovered);


        
        if (candleCovered)
        {            
            LightCandle.intensity = intensityMiddle;
            StopTimerCoroutine();
        }
        else
        {
            LightCandle.intensity = intensityHi;
        }
    }
}


// Устанавливаем начальную интенсивность света
// SetLightIntensity(currentIntensity);