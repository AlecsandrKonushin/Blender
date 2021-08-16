using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonMy : MonoBehaviour
{
    //[SerializeField] protected TypeUISound soundClick = TypeUISound.ButtonClick;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickByButton);
    }

    private void ClickByButton()
    {
        //ControllerAudio.Instance.PlayUISound(soundClick);

        OtherButtonAction();
    }

    protected virtual void OtherButtonAction()
    {

    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(ClickByButton);
    }
}
