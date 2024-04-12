using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Experimental.Rendering;
using Unity.VisualScripting;

public class WeaponAim : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] float defaultFOV = 45f;
    [SerializeField] float aimFOV = 30f;
    [SerializeField] float defaultSensitivity = 1f;
    [SerializeField] float aimSensitivity = 0.2f;

    StarterAssets.FirstPersonController fpsController;
    bool onAim = false;

    private void Start()
    {
        fpsController = GetComponent<StarterAssets.FirstPersonController>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (onAim == false)
            {
                ZoomIn();
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            ZoomOut();
        }
    }

    private void ZoomOut()
    {
        onAim = false;
        fpsCamera.m_Lens.FieldOfView = defaultFOV;
        fpsController.RotationSpeed = defaultSensitivity;
    }

    private void ZoomIn()
    {
        onAim = true;
        fpsCamera.m_Lens.FieldOfView = aimFOV;
        fpsController.RotationSpeed = aimSensitivity;
    }
}
