using UnityEngine;
using UnityEngine.UI;

public class RandomText : MonoBehaviour
{
    [SerializeField] private Text RandomFinish;
    [SerializeField] private string[] RandomFin;

    public void GetRandom()
    {
        RandomFinish.text = RandomFin[Random.Range(0, RandomFin.Length)];
    }
}
