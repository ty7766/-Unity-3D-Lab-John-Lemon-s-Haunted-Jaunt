using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1.0f;                        //페이드 인 시간
    public float displayImageDuration = 1.0f;                //지연 시간

    public GameObject player;                                //플레이어
    public CanvasGroup exitBackgroundImageCanvasGroup;      //Clear Image
   

    bool m_IsPlayerAtExit;      //플레이어가 Exit에 도달하였는지
    float m_Timer;              //페이드 시간 기록

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
