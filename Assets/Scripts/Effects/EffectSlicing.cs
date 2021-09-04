using System.Collections;
using UnityEngine;

public class EffectSlicing : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleObject;
    [SerializeField] private ParticleSystem particleObject2;
    [SerializeField] private Color green;
    [SerializeField] private Color yellow;
    [SerializeField] private Color orange;
    [SerializeField] private Color red;

    [SerializeField] private float timeEffect;

    private ParticleSystem.MainModule particle;
    private ParticleSystem.MainModule particle2;

    private GameObject effect;

    private void Awake()
    {
        particle = particleObject.main;
        particle2 = particleObject2.main;
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
        else if (fruit.GetTypeColor == TypeColor.Orange)
        {
            color = orange;
        }

        else if (fruit.GetTypeColor == TypeColor.Red)
        {
            color = red;
        }

        if (particleObject.gameObject.activeSelf)
        {
            particle2.startColor = color;
            StartCoroutine(CoShowEffect(particleObject2.gameObject));
        }
        else
        {            
            particle.startColor = color;
            StartCoroutine(CoShowEffect(particleObject.gameObject));
        }

    }

    private IEnumerator CoShowEffect(GameObject effect)
    {
        effect.SetActive(true);
        yield return new WaitForSeconds(timeEffect);
        effect.SetActive(false);
    }
}
