using UnityEngine;

public class ConSpawnTimer : MonoBehaviour
{
    private float timeSpawn = 2f;
    private float timeBeforeSpawn = 0f;

    public bool TimeGo { set; private get; }
    public bool SpawnNow { set; private get; }

    private void Update()
    {
        if (TimeGo && !SpawnNow)
        {
            timeBeforeSpawn -= Time.deltaTime;

            if (timeBeforeSpawn <= 0)
            {
                SpawnNow = true;
                TimeForSpawn();
            }
        }
    }

    private void TimeForSpawn()
    {
        timeBeforeSpawn = timeSpawn;
        ManagerSpawner.Instance.TimeForSpawn();
    }
}
