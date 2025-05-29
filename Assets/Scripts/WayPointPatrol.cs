using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//------------Ghost ������Ʈ�� ��ȸ �˰���----------------
public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] wayPoints;           //������ ���� ����Ʈ (��ȸ����)

    int m_CurrentWayPointIndex;             //���� �ε���

    void Start()
    {
        navMeshAgent.SetDestination(wayPoints[0].position);     //������ ����
    }

    void Update()
    {
        //Ghost�� �������� �����ߴ���
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //���� �������� �̵�
            m_CurrentWayPointIndex = (m_CurrentWayPointIndex + 1) % wayPoints.Length;
            navMeshAgent.SetDestination(wayPoints[m_CurrentWayPointIndex].position);
        }
    }
}