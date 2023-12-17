using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn;
    public Light light;
    public AudioSource source;
    public float battery; 
    public float dischargeRate; 

    void Start()
    {
        battery = 100f; 
        dischargeRate = 1f; 
    }

    void Update()
    {
        light.enabled = isOn; 

        if (Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn; 
            source.Play(); 
        }

        if (isOn && battery > 0) // if the flashlight is on and the battery is not empty
        {
            battery -= dischargeRate * Time.deltaTime; // reduce the battery level by the discharge rate multiplied by the time elapsed since the last frame
            light.intensity = battery / 100f; // adjust the light intensity based on the battery level
        }

        if (battery <= 0) // if the battery is empty
        {
            isOn = false; // turn off the flashlight
            battery = 0; // set the battery level to zero
        }
    }
}
