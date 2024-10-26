using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    private Animator animator; // ������ �� ��������� Animator
    bool covering = false;

    // Start is called before the first frame update
    void Start()
    {
        // �������� ��������� Animator �� ���� �������
        animator = GetComponent<Animator>();
    }

    void HandCover()
    {
        // ���������, ���������� �� ��������� Animator
        if (animator != null)
        {
            // �������� ������� ��������
            animator.SetTrigger("startCover");
        }
    }
    void HandDown()
    {
        // ���������, ���������� �� ��������� Animator
        if (animator != null)
        {
            // �������� ������� ��������
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
