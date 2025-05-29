using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [Header("UI")]
    public float fadeDuration = 1.0f;                        //페이드 인 시간
    public float displayImageDuration = 1.0f;                //지연 시간

    [Header("Audio")]
    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    [Header("연결 오브젝트")]
    public GameObject player;                                //플레이어
    public CanvasGroup exitBackgroundImageCanvasGroup;      //Clear Image
    public CanvasGroup caughtBackgroundImageCanvasGroup;    //Game Over Image
   
    bool m_IsPlayerAtExit;      //플레이어가 Exit에 도달하였는지
    bool m_IsPlayerCaught;      //플레이어가 잡혔는지
    float m_Timer;              //페이드 시간 기록
    bool m_HasAudioPlayed;      //한번만 플레이 되도록 처리 목적

    //UI 보여주기
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

    //플레이어의 게임 클리어 및 게임 오버 이미지 보여주기
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        //Audio가 플레이되지 않았으면 재생
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
                SceneManager.LoadScene(0);      //Over : 재시작(이번 씬 불러오기)
            }
            else
            {
                Application.Quit();             //Clear : 게임 종료
            }
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }
}
