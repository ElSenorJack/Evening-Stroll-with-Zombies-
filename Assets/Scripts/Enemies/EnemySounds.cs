using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    //test #7
    public AudioSource randomGrowl;
    public AudioClip[] audioSources;
    [SerializeField] float growlInterval = 3;
    [SerializeField] AudioClip enemyChase;

    new AudioSource audio;
    EnemyHealth health;
    EnemyAI enemy;
    
    void Start() 
    {
        audio = GetComponent<AudioSource>();
        enemy = GetComponent<EnemyAI>();
        health = GetComponent<EnemyHealth>();
        CallAudio();        
    }

    void CallAudio() 
    { 
        Invoke ("RandomGrowls", growlInterval);
        //Invoke ("ChaseGrowls", growlInterval);
    }

    void RandomGrowls() 
    {
        randomGrowl.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomGrowl.Play();
        if (health.isDead == false) { CallAudio(); }
        else { randomGrowl.Stop(); }
    }

    //void ChaseGrowls()
    //{
     //   if (enemy.isProvoked == true)
       // { audio.PlayOneShot(enemyChase); }
    //}
}
