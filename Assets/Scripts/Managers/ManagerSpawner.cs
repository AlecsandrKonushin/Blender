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
    public void SetDataSpawn(DataLevel dataLevel)
    {
        conSpawnTimer.SetTimeSpawn(dataLevel.TimeSpawn);
        conChooseFruit.SetDataSpawn(dataLevel.DataSpawnObjects);
        CreateObjectsInAllLines();
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

    public void CreateObjectsInAllLines()
    {
        for (int i = 0; i < 4; i++)
        {
            CreateObject(i);
        }
    }

    private void CreateObject(int numberLine = -1)
    {
        GameObject newObj = conChooseFruit.GetObjectForSpawn();
        Vector3 position = conChoosePosition.GetPosition(numberLine);
        conSpawn.SpawnObject(newObj, position);

        conSpawnTimer.SpawnNow = false;
    }
}
