using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent OnTriggered;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggered?.Invoke();
    }
}
