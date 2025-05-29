using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1.0f;                        //���̵� �� �ð�
    public float displayImageDuration = 1.0f;                //���� �ð�

    public GameObject player;                                //�÷��̾�
    public CanvasGroup exitBackgroundImageCanvasGroup;      //Clear Image
    public CanvasGroup caughtBackgroundImageCanvasGroup;    //Game Over Image
   

    bool m_IsPlayerAtExit;      //�÷��̾ Exit�� �����Ͽ�����
    bool m_IsPlayerCaught;      //�÷��̾ ��������

    float m_Timer;              //���̵� �ð� ���

    //UI �����ֱ�
    private void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    //�÷��̾��� ���� Ŭ���� �� ���� ���� �̹��� �����ֱ�
    void EndLevel(CanvasGroup imageCanvasGroup)
    {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;    //Fade In

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }
}
