using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using Unity.VisualScripting;

public class Shoot : MonoBehaviour
{

    public PrimaryButton watcher;
    public GameObject score_object;
    void Start()
    {
        watcher.primaryButtonPress.AddListener(Shooting);

        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.characteristics));
        }
    }

    public void Shooting(bool pressed){
        if(pressed){
            RaycastHit hit;
            if(Physics.Raycast(this.transform.position,this.transform.TransformDirection(Vector3.forward),out hit)){
                if(hit.collider.gameObject.tag=="Enemy"){
                    score_object.GetComponent<Score>().score += 300;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
