using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private Text textResult;
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject restartLevelButton;

    private const float timeHide = 0.5f;

    private const string winText = "Победа!";
    private const string loseText = "Проигрышь!";

    public void ShowWinPanel()
    {
        textResult.text = winText;
        nextLevelButton.SetActive(true);
        restartLevelButton.SetActive(false);

        background.SetActive(true);
    }

    public void ShowLosePanel()
    {
        textResult.text = loseText;
        nextLevelButton.SetActive(false);
        restartLevelButton.SetActive(true);

        background.SetActive(true);
    }

    public void HidePanel()
    {
        StartCoroutine(CoHidePanel());
    }

    private IEnumerator CoHidePanel()
    {
        background.GetComponent<Animator>().SetTrigger(TypeAnimationPanel.Hide.ToString());
        yield return new WaitForSeconds(timeHide);
        background.SetActive(false);
    }
}
