using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//------------Ghost 오브젝트의 순회 알고리즘----------------
public class WayPointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] wayPoints;           //유령의 웨이 포인트 (순회지점)

    int m_CurrentWayPointIndex;             //현재 인덱스

    void Start()
    {
        navMeshAgent.SetDestination(wayPoints[0].position);     //목적지 설정
    }

    void Update()
    {
        //Ghost가 목적지에 도착했는지
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //다음 목적지로 이동
            m_CurrentWayPointIndex = (m_CurrentWayPointIndex + 1) % wayPoints.Length;
            navMeshAgent.SetDestination(wayPoints[m_CurrentWayPointIndex].position);
        }
    }
}