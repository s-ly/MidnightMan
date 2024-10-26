using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Candle candle_SCRIPT;
    [SerializeField] Hand hand_SCRIPT;
    float mouseSensitivity = 100f; // ���������������� ����
    float speedPlayer = 15.0f; // �������� ������
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
        // �������� ���� ����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // ������� ������ �� ��� X (�����-����)
        // ������������ ������� ������, ����� ��� �� ����� ����������� ������� ������
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // ������� ������ �� ��� Y (�����-������)
        transPlayer.Rotate(Vector3.up * mouseX);

        transCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // ������� ������

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
        Cursor.lockState = CursorLockMode.Locked; // �������� � ��������� ������ ����
        transCamera = transform.GetChild(0);
    }
}
