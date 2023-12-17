using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn;
    public Light light;
    public AudioSource source;
    public float battery; // a variable to store the battery level
    public float dischargeRate; // a variable to set how fast the battery drains

    void Start()
    {
        battery = 100f; // initialize the battery level to 100%
        dischargeRate = 0.5f; // set the discharge rate to 0.5% per second
    }

    void Update()
    {
        light.enabled = isOn; // enable or disable the light based on the isOn variable

        if (Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn; // toggle the isOn variable
            source.Play(); // play the sound effect
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
