using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
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
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;    //Fade In

        if (doRestart)
        {
            SceneManager.LoadScene(0);      //Over : �����(�̹� �� �ҷ�����)
        }
        else
        {
            Application.Quit();             //Clear : ���� ����
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }
}
