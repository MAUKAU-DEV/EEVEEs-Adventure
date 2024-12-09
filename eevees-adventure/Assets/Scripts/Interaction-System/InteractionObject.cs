using UnityEngine;
using UnityEngine.Events;

public abstract class InteractionObject : MonoBehaviour
{
    public string _tagCheck = "Player";
    public UnityEvent _actionEvent;

    public abstract void TriggerAction();
}
