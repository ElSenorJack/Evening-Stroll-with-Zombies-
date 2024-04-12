using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameoverCanvas;

    private void Start()
    {
        gameoverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        GetComponent<StarterAssets.FirstPersonController>().enabled = false;
        gameoverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponChanger>().enabled = false;  
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
