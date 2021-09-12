using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : Singleton<TimerText>
{
    [SerializeField] private Text textTime;
    
    public void ShowTextTime(float value)
    {

    }

    public void HideTextTime()
    {
        StartCoroutine(CoHideTextLevel());
    }

    private IEnumerator CoHideTextLevel()
    {
        yield return new WaitForSeconds(.5f);
    }
}
