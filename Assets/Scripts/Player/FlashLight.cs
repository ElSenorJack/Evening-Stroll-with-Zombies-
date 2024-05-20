using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour   
{
    [SerializeField] float lightDim = .1f;
    [SerializeField] float angleDim = 1f;
    [SerializeField] float minimunAngle = 10f;
    //[SerializeField]
    Light myLight;
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }
    public void RestoreLightIntensity(float addIntensity)
    {
        myLight.intensity += addIntensity;
    }
    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDim*Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimunAngle) { return; }
        else 
        { 
            myLight.spotAngle -= angleDim * Time.deltaTime;
            myLight.innerSpotAngle -= angleDim * Time.deltaTime;
        }
    }
}
