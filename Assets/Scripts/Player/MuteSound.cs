using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSound : MonoBehaviour
{
    AudioListener _listener;
    void Start()
    {
        _listener = GetComponent<AudioListener>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) { MuteAll(); }
    }

    void MuteAll()
    {
         { _listener.enabled = !_listener.enabled; }
    }
}
