using UnityEngine;

public class ConTimerLevel : MonoBehaviour
{
    private bool goTime = false;
    private float lastTime;

    public void SetTime(float time)
    {
        lastTime = time;
        goTime = true;
    }

    private void Update()
    {
        if (goTime)
        {
            lastTime -= Time.deltaTime;            
        }
    }
}
