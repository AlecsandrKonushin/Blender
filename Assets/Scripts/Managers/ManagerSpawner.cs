using UnityEngine;

public class ManagerSpawner : Singleton<ManagerSpawner>
{
    [SerializeField] private ConChoosePositionForSpawn conChoosePosition;
    [SerializeField] private ConChooseFruitForSpawn conChooseFruit;
    [SerializeField] private ConSpawnTimer conSpawnTimer;
    [SerializeField] private ConSpawn conSpawn;

    /// <summary>
    /// Установить Objects, которые будет спауниться на уровне
    /// </summary>
    /// <param name="dataRecipe"></param>
    public void SetDataSpawn(DataSpawnObjects dataSpawn)
    {
        conChooseFruit.SetDataSpawn(dataSpawn);
    }

    /// <summary>
    /// Счётчик времени до спауна включается/отключается
    /// </summary>
    public void SetCanSpawn(bool value)
    {
        conSpawnTimer.TimeGo = value;
    }

    /// <summary>
    /// Пришло время для spawn
    /// </summary>
    public void TimeForSpawn()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        GameObject newObj = conChooseFruit.GetObjectForSpawn();
        Vector3 position = conChoosePosition.GetPosition();
        conSpawn.SpawnObject(newObj, position);

        conSpawnTimer.SpawnNow = false;
    }
}
