using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1.0f;                        //���̵� �� �ð�
    public float displayImageDuration = 1.0f;                //���� �ð�

    public GameObject player;                                //�÷��̾�
    public CanvasGroup exitBackgroundImageCanvasGroup;      //Clear Image
   

    bool m_IsPlayerAtExit;      //�÷��̾ Exit�� �����Ͽ�����
    float m_Timer;              //���̵� �ð� ���

    private void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    //UI Fade In
    void EndLevel()
    {
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }
}
