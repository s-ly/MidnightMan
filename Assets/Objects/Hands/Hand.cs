using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    private Animator animator; // Ссылка на компонент Animator
    bool covering = false;

    // Start is called before the first frame update
    void Start()
    {
        // Получаем компонент Animator на этом объекте
        animator = GetComponent<Animator>();
    }

    void HandCover()
    {
        // Проверяем, существует ли компонент Animator
        if (animator != null)
        {
            // Вызываем триггер перехода
            animator.SetTrigger("startCover");
        }
    }
    void HandDown()
    {
        // Проверяем, существует ли компонент Animator
        if (animator != null)
        {
            // Вызываем триггер перехода
            animator.SetTrigger("endCover");
        }
    }

    public void HandCoverSwitch()
    {
        if (!covering)
        {
            covering = true;
            HandCover();
        }
        else
        {
            covering = false;
            HandDown();
        }
    }
}
