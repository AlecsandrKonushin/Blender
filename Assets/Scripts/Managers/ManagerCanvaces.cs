using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManagerCanvaces : Singleton<ManagerCanvaces>
{
    [SerializeField] private RecipePanel recipePanel;
    [SerializeField] private ResultPanel resultPanel;
    [SerializeField] private EndLevelPanel endLevelPanel;

    [SerializeField] private Text levelText;

    private const string strLevel = "Уровень ";
    private float timeShowLevelText = 2f;
    private float timeHideResultPanel = .5f;

    /// <summary>
    /// Показать рецепт
    /// </summary>
    /// <param name="recipe"></param>
    public void ShowRecipe(DataNeedFruit dataFruit)
    {
        recipePanel.ShowRecipe(dataFruit);
    }

    /// <summary>
    /// Сокрытие отображаемого рецепта, показ победы
    /// </summary>
    public void ShowWinLevel()
    {
        resultPanel.ShowWinPanel();
    }

    public void ShowLoseLevel()
    {
        resultPanel.ShowLosePanel();
    }

    public void ClickNextLevel()
    {
        StartCoroutine(CoWaitHideResultPanel(true));
    }

    public void ClickRestartLevel()
    {
        StartCoroutine(CoWaitHideResultPanel(false));
    }

    private IEnumerator CoWaitHideResultPanel(bool nextLevel)
    {
        resultPanel.HidePanel();
        yield return new WaitForSeconds(timeHideResultPanel);

        if (nextLevel)
            ManagerMain.Instance.LevelNext();
        else
            ManagerMain.Instance.LevelRestart();
    }

    public void ShowEndLevelPanel()
    {
        endLevelPanel.ShowPanel();
    }

    public void ShowLevelText(int numberText)
    {
        levelText.text = strLevel + numberText;
        StartCoroutine(CoShowLevelText());
    }

    private IEnumerator CoShowLevelText()
    {
        levelText.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeShowLevelText);
        levelText.gameObject.SetActive(false);
    }
}
