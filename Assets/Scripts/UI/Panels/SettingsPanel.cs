﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : Singleton<SettingsPanel>
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject inMenuButton;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    private const string textEndLevels = "Пройдено: ";
    private float timeHide = .35f;

    private void Start()
    {
        musicSlider.onValueChanged.AddListener(delegate { ChangeMusicVolume(); });
        soundSlider.onValueChanged.AddListener(delegate { ChangeSoundVolume(); });
    }

    public void ShowPanel()
    {
        if (ManagerScenes.Instance.GetIsGameScene)
        {
            ManagerStates.Instance.ChangeStateGame(TypeStateGame.Pause);
            inMenuButton.SetActive(false);
        }
        else
        {
            inMenuButton.SetActive(true);
        }

        panel.SetActive(true);
    }

    public void HidePanel()
    {
        StartCoroutine(CoHidePanel());
    }

    private IEnumerator CoHidePanel()
    {
        panel.GetComponent<Animator>().SetTrigger("Hide");
        yield return new WaitForSeconds(timeHide);
        panel.SetActive(false);

        if (ManagerScenes.Instance.GetIsGameScene)
        {
            ManagerStates.Instance.ChangeStateGame(TypeStateGame.Game);
        }
    }

    private void ChangeMusicVolume()
    {
        ManagerAudio.Instance.ChangeMusicVolume(musicSlider.value);
    }

    private void ChangeSoundVolume()
    {
        ManagerAudio.Instance.ChangeSoundVolume(soundSlider.value);
    }
}
