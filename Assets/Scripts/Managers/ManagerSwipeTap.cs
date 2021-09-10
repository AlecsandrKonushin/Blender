using UnityEngine;

public class ManagerSwipeTap : Singleton<ManagerSwipeTap>
{
    public delegate void SwipeEvent(bool rightSwipe);
    public delegate void TapEvent(int numberLine);

    public event SwipeEvent Swipe;
    public event TapEvent Tap;

    [SerializeField] private ConSwipeTap conSwipeTap;

    private int numberLineTap = 0;

    /// <summary>
    /// Произошёл свайп в сторону right = bool
    /// </summary>
    /// <param name="right"></param>
    public void DoSwipe(bool right)
    {
        if (right)
        {
            numberLineTap++;
        }
        else
        {
            numberLineTap--;
        }

        Swipe?.Invoke(right);
    }

    /// <summary>
    /// Произошёл tap по линии номер swipeByNumberLine
    /// </summary>
    /// <param name="swipeByNumberLine"></param>
    public void DoTap(int swipeByNumberLine)
    {
        if (numberLineTap != swipeByNumberLine)
        {
            numberLineTap = swipeByNumberLine;
            Tap?.Invoke(swipeByNumberLine);
        }
    }

    /// <summary>
    /// Если можно делать свайп, то включается объект который считывает свайп,
    /// если нет, то он отключается
    /// </summary>
    /// <param name="canSwipe"></param>
    public void ChangeCanSwipe(bool canSwipe)
    {
        if (canSwipe)
            OnConSwipe();
        else
            OffConSwipe();
    }

    private void OnConSwipe()
    {
        conSwipeTap.gameObject.SetActive(true);
    }

    private void OffConSwipe()
    {
        conSwipeTap.gameObject.SetActive(false);
    }
}
