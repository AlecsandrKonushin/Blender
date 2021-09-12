public class ManagerMain : Singleton<ManagerMain>
{
    private TypeLoseLevel typeLoseLevel;
    public TypeLoseLevel GetTypeLoseLevel { get => typeLoseLevel; }

    private void Start()
    {
#if !UNITY_EDITOR
        ManagerLevel.Instance.SetCurrentNumberLevel = ManagerSaveLoad.Instance.LoadLevel();
#endif
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

    public void LevelLose(TypeLoseLevel typeLoseLevel)
    {
        this.typeLoseLevel = typeLoseLevel;
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
