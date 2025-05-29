using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [Header("UI")]
    public float fadeDuration = 1.0f;                        //���̵� �� �ð�
    public float displayImageDuration = 1.0f;                //���� �ð�

    [Header("Audio")]
    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    [Header("���� ������Ʈ")]
    public GameObject player;                                //�÷��̾�
    public CanvasGroup exitBackgroundImageCanvasGroup;      //Clear Image
    public CanvasGroup caughtBackgroundImageCanvasGroup;    //Game Over Image
   
    bool m_IsPlayerAtExit;      //�÷��̾ Exit�� �����Ͽ�����
    bool m_IsPlayerCaught;      //�÷��̾ ��������
    float m_Timer;              //���̵� �ð� ���
    bool m_HasAudioPlayed;      //�ѹ��� �÷��� �ǵ��� ó�� ����

    //UI �����ֱ�
    private void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
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
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        //Audio�� �÷��̵��� �ʾ����� ���
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;    //Fade In

        if (m_Timer > fadeDuration +  displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);      //Over : �����(�̹� �� �ҷ�����)
            }
            else
            {
                Application.Quit();             //Clear : ���� ����
            }
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }
}
