using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeWeapon : MonoBehaviour
{
    public InputActionProperty leftHandPositionAction;
    public InputActionProperty leftHandRotationAction;
    public InputActionProperty leftHandTriggerAction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 handPosition = leftHandPositionAction.action.ReadValue<Vector3>();
        Quaternion handRotation = leftHandRotationAction.action.ReadValue<Quaternion>();

        transform.position = handPosition;
        transform.rotation = handRotation;

         float triggerValue = leftHandTriggerAction.action.ReadValue<float>();
         Debug.Log($"Trigger Value: {triggerValue}");

        if (triggerValue > 0.5f)
        {
            Debug.Log("トリガーが押されました");
        }
    }
}
