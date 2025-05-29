using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;        //�÷��̾��� ��ġ
    public GameEnding gameEnding;   //���� ����

    bool m_IsPlayerInRange;         //�÷��̾ �����ȿ� �ִ���

    private void Update()
    {
        //�÷��̾ ���� �ȿ� ������ Gameover
        if (m_IsPlayerInRange)
        {
            //�÷��̾��� �߽� ��ġ
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    
                }
            }
        }
    }

    //�÷��̾� - ������ �� ��ȣ�ۿ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
}
