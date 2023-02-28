using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    public float Threshold = 0.1f;
    [SerializeField]
    public float DeadZone = 0.025f;

    private bool IsPressed;
    private Vector3 StartPos;
    private ConfigurableJoint Joint;

    public UnityEvent onPressed, onReleased;

    public int Cooldown = 0;


    void Start()
    {
        StartPos = transform.localPosition;
        Joint = GetComponent<ConfigurableJoint>();

    }

    void Update()
    {
        Cooldown -= 1;
        if (!IsPressed && GetValue() + Threshold >= 1)
        {
            Pressed();
        }
        if (IsPressed && GetValue() - Threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(StartPos, transform.localPosition) / Joint.linearLimit.limit;
        if (Mathf.Abs(value) < DeadZone)
        {
            value = 0;
        }
        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        IsPressed = true;
        if (Cooldown <= 0)
        {
            onPressed.Invoke();
            Cooldown = 60;
        }
        //Debug.Log("Is Pressed");
    }

    private void Released()
    {
        IsPressed = false;
        onReleased.Invoke();
        //Debug.Log("Is Released");
    }


}
