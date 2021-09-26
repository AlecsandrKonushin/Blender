using UnityEngine;

public class TutorDanger : MonoBehaviour
{
    private string textDanderTree = "Дерево опасно";
    private string textDanderIce = "Лёд замораживает";

    public void StartTutor(BubbleType bubbleType)
    {
        if (bubbleType == BubbleType.Tree)
        {
            BubbleTutor.Instance.ShowTutor(bubbleType, textDanderTree);
        }
        else if (bubbleType == BubbleType.Ice)
        {
            BubbleTutor.Instance.ShowTutor(bubbleType, textDanderIce);
        }
    }
}

public enum BubbleType
{
    Tree,
    Ice
}
