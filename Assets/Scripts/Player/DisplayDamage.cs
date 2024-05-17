using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas hitCanvas;
    [SerializeField] float timeShow = 0.3f;
    void Start()
    {
        hitCanvas.enabled = false;
    }

    public void ShowDamage()
    {
        StartCoroutine(Splatter());
    }

    IEnumerator Splatter()
    { 
        hitCanvas.enabled=true;
        yield return new WaitForSeconds(timeShow);
        hitCanvas.enabled=false;
    }
}
