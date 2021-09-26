using UnityEngine;
using UnityEngine.UI;

public class BubbleTutor : Singleton<BubbleTutor>
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject ice;
    [SerializeField] private Text textTutor;

    public void ShowTutor(BubbleType bubbleType, string text)
    {
        if (bubbleType == BubbleType.Tree)
        {
            tree.SetActive(true);
        }
        else if (bubbleType == BubbleType.Ice)
        {
            ice.SetActive(true);
        }

        textTutor.text = text;
        background.SetActive(true);
    }
}
