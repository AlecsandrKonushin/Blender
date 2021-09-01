using System.Collections;
using UnityEngine;

public class EffectSlicing : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleObject;
    [SerializeField] private Color green;
    [SerializeField] private Color yellow;

    [SerializeField] private float timeEffect;

    private ParticleSystem.MainModule particle;

    private void Awake()
    {
        particle = particleObject.main;
    }

    public void ShowSliceFruit(Fruit fruit)
    {
        Color color = green;

        if (fruit.GetTypeColor == TypeColor.Green)
        {
            color = green;
        }
        else if (fruit.GetTypeColor == TypeColor.Yellow)
        {
            color = yellow;
        }

        particle.startColor = color;
        StartCoroutine(CoShowEffect());
    }

    private IEnumerator CoShowEffect()
    {
        particleObject.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeEffect);
        particleObject.gameObject.SetActive(false);
    }
}
