﻿using UnityEngine;

public class ManagerTime : Singleton<ManagerTime>
{
    // сделать textTime, отображать на нём время в секундах
    // обработка, когда время вышло

    [SerializeField] private ConTimerLevel conTimerLevel;

    private bool needTimer = false;

    /// <summary>
    /// Установка и запуск времени для следующего уровня
    /// </summary>
    public void StartNextLevel(float time)
    {
        if (time > 0)
        {
            conTimerLevel.gameObject.SetActive(true);
            conTimerLevel.SetTime(time);
            needTimer = true;
        }else
        {
            needTimer = false;
        }
    }

    /// <summary>
    /// Время уровня вышло
    /// </summary>
    public void TimeEnd()
    {
        conTimerLevel.gameObject.SetActive(false);
    }

    /// <summary>
    /// Запуск времени после паузы
    /// </summary>
    public void TimerGo()
    {
        if (needTimer)
        {
            conTimerLevel.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// пауза - остановка времени
    /// </summary>
    public void TimerStop()
    {
        conTimerLevel.gameObject.SetActive(false);
    }
}