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
        // ���������, ����� �� ������������� ������ ��� "Water"
        if (other.CompareTag("Water"))
        {            
            CandleGoesOut();
        }
        // ���������, ����� �� ������������� ������ ��� "Wind"
        if (other.CompareTag("Wind"))
        {
            //CandleGoesOut();
            StartCoroutine(TimerCoroutine());            
        }
    }
    IEnumerator TimerCoroutine()
    {
        // �������� ������ 5 ������
        for (int i = 3; i > 0; i--)
        {
            Debug.Log("Countdown: " + i);
            yield return new WaitForSeconds(1);
        }

        // �������� ����� ����� ���������� ��������� �������
        Debug.Log("TimerCoroutine : finished!");
        CandleGoesOut();
    }
}
