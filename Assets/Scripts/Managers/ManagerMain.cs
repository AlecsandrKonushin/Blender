using UnityEngine;

public class ManagerMain : Singleton<ManagerMain>
{
    private void Start()
    {
        ManagerLevel.Instance.NextLevel();
        ManagerStates.Instance.ChangeStateGame(TypeStateGame.Game);
    }

    /// <summary>
    /// Рецепт собран, отключение spawn, подгрузка нового уровня
    /// </summary>
    public void LevelWin()
    {
        ManagerStates.Instance.ChangeStateGame(TypeStateGame.LoadingLevel);
    }

    /// <summary>
    /// Запуск следующего уровня
    /// </summary>
    public void LevelNext()
    {
        ManagerLevel.Instance.NextLevel();
        ManagerStates.Instance.ChangeStateGame(TypeStateGame.Game);
    }

    public void LevelLose()
    {
        ManagerStates.Instance.ChangeStateGame(TypeStateGame.LoadingLevel);
        ManagerCanvaces.Instance.ShowLoseLevel();
    }

    public void LevelRestart()
    {
        ManagerObjects.Instance.DestroyAllObjects();
        ManagerLevel.Instance.NextLevel();
        ManagerStates.Instance.ChangeStateGame(TypeStateGame.Game);
    }

    /// <summary>
    /// Все уровни пройдены
    /// </summary>
    public void EndLevels()
    {
        ManagerStates.Instance.ChangeStateGame(TypeStateGame.LoadingLevel);

        ManagerCanvaces.Instance.ShowEndLevelPanel();
    }
}
