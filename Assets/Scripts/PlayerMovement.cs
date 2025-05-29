using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;     //ĳ���� ȸ�� �ӵ�

    Vector3 m_Movement;                                 //�̵�
    Quaternion m_Rotation = Quaternion.identity;        //ȸ�� ����
    Animator m_Animator;                                //ĳ���� �ִϸ�����
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;                          //�߼Ҹ� ȿ����


    //----------- �ʱ�ȭ ------------
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
        m_Movement.Normalize();     //�밢�� �̵� ����ȭ ����

        //�÷��̾� �Է� ����
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        //isWalking �� true�̸� Walking Animation Start
        m_Animator.SetBool("IsWalking", isWalking);

        //isWalking�� true�̸� �߼Ҹ� ȿ����, �ƴϸ� ����
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

        //ĳ���� ȸ�� (turnSpeed��ŭ ȸ�� �ӵ� ����)
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);

        //desireForward �������� ȸ��
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    //----------------- �̵� & ȸ�� ���� ���� ----------------
    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);   //��Ʈ������� ���� �����Ӵ� �̵���
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
