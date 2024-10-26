using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Candle candle_SCRIPT;
    [SerializeField] Hand hand_SCRIPT;
    float mouseSensitivity = 100f; // чувствительность выши
    float speedPlayer = 15.0f; // скорость игрока
    float xRotation = 0f;
    Rigidbody rigPlayer;
    Transform transPlayer;
    Transform transCamera;

    // Start is called before the first frame update
    void Start()
    {
        InItPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }

    private void FixedUpdate()
    {
        ControlFixed();
    }

    void ControlFixed()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigPlayer.AddForce(transform.forward * speedPlayer);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigPlayer.AddForce(transform.forward * -speedPlayer);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigPlayer.AddForce(transform.right * -speedPlayer);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigPlayer.AddForce(-transform.right * -speedPlayer);
        }
        
    }

    void Control()
    {
        // ѕолучаем ввод мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // ѕоворот камеры по оси X (вверх-вниз)
        // ќграничиваем поворот камеры, чтобы она не могла повернутьс€ слишком далеко
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // ѕоворот игрока по оси Y (влево-вправо)
        transPlayer.Rotate(Vector3.up * mouseX);

        transCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // поворот камеры

        if (Input.GetKeyDown(KeyCode.E))
        {
            candle_SCRIPT.CandleCoveredSwitch();
            hand_SCRIPT.HandCoverSwitch();
        }
    }

    void InItPlayer()
    {
        rigPlayer = GetComponent<Rigidbody>();
        transPlayer = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked; // —крываем и блокируем курсор мыши
        transCamera = transform.GetChild(0);
    }
}
