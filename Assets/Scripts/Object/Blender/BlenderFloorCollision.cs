using UnityEngine;

public class BlenderFloorCollision : MonoBehaviour
{
    [SerializeField] private EffectSlicing effectSlicing;

    private void OnCollisionEnter(Collision collision)
    {
        if (!CheckPositionCollision())
            return;

        string tag = collision.gameObject.tag;

        collision.gameObject.GetComponent<FallingObject>().TouchFloorBlender();

        if (tag == DataTags.Fruit.ToString())
        {
            if (collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
            {
                effectSlicing.ShowSliceFruit(fruit);

                ManagerLevel.Instance.CheckFruit(fruit);
                ManagerObjects.Instance.DestroyFruit(fruit);
            }
            else
            {
                Debug.LogError("Не найден компонент Fruit на объекте " + collision.gameObject.name);
            }
        }
        else if (tag == DataTags.Damager.ToString())
        {
            if (collision.gameObject.TryGetComponent<Damager>(out Damager damager))
            {
                ManagerLevel.Instance.CheckDamager(damager);
                ManagerObjects.Instance.DestroyDamager(damager);
            }
            else
            {
                Debug.LogError("Не найден компонент Damager на объекте " + collision.gameObject.name);
            }
        }
    }

    private bool CheckPositionCollision()
    {
        return true;
    }
}
