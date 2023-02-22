using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivityTimer : MonoBehaviour
{
    [SerializeField] private float time = 2f;
    [SerializeField] private UnityEvent onTime;
    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        { 
            onTime.Invoke();
        }
    }
}
