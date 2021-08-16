using UnityEngine;

public class ConChoosePositionForSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] pointsSpawn;

    private int prevNumberPoints = 0;

    public Vector3 GetPosition()
    {
        int rnd = Random.Range(0, pointsSpawn.Length);

        while (rnd == prevNumberPoints)
        {
            rnd = Random.Range(0, pointsSpawn.Length);
        }

        prevNumberPoints = rnd;
        return pointsSpawn[rnd].transform.position;
    }
}
