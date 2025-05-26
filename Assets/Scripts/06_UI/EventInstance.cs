using UnityEngine;
using UnityEngine.UI;

public class EventInstance : MonoBehaviour
{
    [SerializeField] private EventData eventData;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(InvokeEvent);
    }

    public void InvokeEvent()
    {
        eventData.InvokeEvent();
    }
}
