using UnityEngine;

public class ManagerCanvaces : Singleton<ManagerCanvaces>
{
    [SerializeField] private RecipePanel recipePanel;
    [SerializeField] private ResultPanel resultPanel;

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
        resultPanel.HidePanel();
        ManagerMain.Instance.LevelNext();
    }

    public void ClickRestartLevel()
    {
        resultPanel.HidePanel();
        ManagerMain.Instance.LevelRestart();
    }
}
