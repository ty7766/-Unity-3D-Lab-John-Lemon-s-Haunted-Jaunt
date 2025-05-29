using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;        //플레이어의 위치
    public GameEnding gameEnding;   //게임 오버

    bool m_IsPlayerInRange;         //플레이어가 범위안에 있는지

    private void Update()
    {
        //플레이어가 범위 안에 있으면 Gameover
        if (m_IsPlayerInRange)
        {
            //플레이어의 중심 위치
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

    //플레이어 - 가고일 간 상호작용
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
