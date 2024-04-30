using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsFlicker : MonoBehaviour
{
    Light light;
    MeshRenderer halo;
    float interval = 1;
    float timer;
    

    private void Start()
    {
        light = GetComponentInChildren<Light>();
        halo = GetComponentInChildren<MeshRenderer>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            light.enabled = !light.enabled;
            halo.enabled = !halo.enabled;
            interval = Random.Range(0f, 1f);
            timer = 0;
        }
    }
}
