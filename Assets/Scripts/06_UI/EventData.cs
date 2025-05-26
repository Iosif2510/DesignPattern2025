using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New EventData", menuName = "EventData")]
public class EventData : ScriptableObject
{
    [SerializeField] private string eventName;
    
    public string EventName => eventName;
    
    public UnityAction onEventInvoked;
    
    public void InvokeEvent()
    {
        onEventInvoked?.Invoke();
    }
}
