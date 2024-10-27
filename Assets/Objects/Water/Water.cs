using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float scrollSpeedX = 0.5f; // Скорость смещения по оси X
    public float scrollSpeedY = 0.5f; // Скорость смещения по оси Y
    Renderer rendererComponent; // Ссылка на компонент Renderer
    Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        // Получаем компонент Renderer на этом объекте
        rendererComponent = GetComponent<Renderer>();
        materials = rendererComponent.materials;

        // Проверяем, существует ли компонент Renderer
        if (rendererComponent == null)
        {
            Debug.LogError("There is no 'Renderer' attached to the " + gameObject.name + " game object.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Вычисляем смещение UV
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;
        // Применяем смещение UV к материалу
        if (rendererComponent != null)
        {
            //rendererComponent.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));

            Vector2 offset = new Vector2(offsetX, offsetY);
            materials[0].SetTextureOffset("_BaseColorMap", offset);
            rendererComponent.materials = materials;
        }
    }
}
