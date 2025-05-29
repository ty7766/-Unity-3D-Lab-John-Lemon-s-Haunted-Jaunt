using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1.0f;                        //페이드 인 시간
    public float displayImageDuration = 1.0f;                //지연 시간

    public GameObject player;                                //플레이어
    public CanvasGroup exitBackgroundImageCanvasGroup;      //Clear Image
    public CanvasGroup caughtBackgroundImageCanvasGroup;    //Game Over Image
   

    bool m_IsPlayerAtExit;      //플레이어가 Exit에 도달하였는지
    bool m_IsPlayerCaught;      //플레이어가 잡혔는지

    float m_Timer;              //페이드 시간 기록

    //UI 보여주기
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

    //플레이어의 게임 클리어 및 게임 오버 이미지 보여주기
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
