using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;     //캐릭터 회전 속도

    Vector3 m_Movement;                                 //이동
    Quaternion m_Rotation = Quaternion.identity;        //회전 생성
    Animator m_Animator;                                //캐릭터 애니메이터
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;                          //발소리 효과음


    //----------- 초기화 ------------
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();     //대각선 이동 가속화 방지

        //플레이어 입력 감지
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        //isWalking 이 true이면 Walking Animation Start
        m_Animator.SetBool("IsWalking", isWalking);

        //isWalking이 true이면 발소리 효과음, 아니면 정지
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        //캐릭터 회전 (turnSpeed만큼 회전 속도 제어)
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);

        //desireForward 방향으로 회전
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    //----------------- 이동 & 회전 개별 적용 ----------------
    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);   //루트모션으로 인한 프레임당 이동량
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
