using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script to have the 'floarboards' in one particular hallway squeak when walked on
//This Peice of the assignment was made by Sorin West, following the help of Chris' Turorials on youtube

public class soundTrigger : MonoBehaviour
{
    AudioSource source;
    Collider trigger;
    public GameObject Player;

    void Awake(){
        source = GetComponent<AudioSource>();
        trigger = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject == Player){
            source.Play();
        }
    }

/*   void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Player){
            source.Stop();
        }
    }
*/

}
