using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsFlicker : MonoBehaviour
{
    float interval = 1;
    float timer;
    Light[] lights;
    private void Start()
    {
        lights = GetComponentsInChildren<Light>();
    }
    public void Update()
    {
        timer += Time.deltaTime;
        foreach (Light light in lights)
        {
            if (timer > interval)
            {
                light.enabled = !light.enabled;
                interval = Random.Range(0f, 1f);
                timer = 0;
            }
        }
    }
}
