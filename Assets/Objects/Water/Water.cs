using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float scrollSpeedX = 0.5f; // �������� �������� �� ��� X
    public float scrollSpeedY = 0.5f; // �������� �������� �� ��� Y
    Renderer rendererComponent; // ������ �� ��������� Renderer
    Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        // �������� ��������� Renderer �� ���� �������
        rendererComponent = GetComponent<Renderer>();
        materials = rendererComponent.materials;

        // ���������, ���������� �� ��������� Renderer
        if (rendererComponent == null)
        {
            Debug.LogError("There is no 'Renderer' attached to the " + gameObject.name + " game object.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ��������� �������� UV
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;
        // ��������� �������� UV � ���������
        if (rendererComponent != null)
        {
            //rendererComponent.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));

            Vector2 offset = new Vector2(offsetX, offsetY);
            materials[0].SetTextureOffset("_BaseColorMap", offset);
            rendererComponent.materials = materials;
        }
    }
}
