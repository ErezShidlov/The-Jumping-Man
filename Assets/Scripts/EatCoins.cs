using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCoins : MonoBehaviour
{
    public static int coinsAmount;
    public AudioSource audioSource;
    public AudioClip eatCoins;
    void Start()
    {

    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinsAmount++;
            audioSource.PlayOneShot(eatCoins);
        }
    }
}
