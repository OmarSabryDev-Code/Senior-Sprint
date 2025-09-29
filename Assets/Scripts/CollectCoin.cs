using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
            coinFX.Play(); // Play the coin collection sound
            MasterInfo.coinCount++; // Increment the coin count in the MasterInfo class
            this.gameObject.SetActive(false); // Deactivate the coin object
            // Optionally, you can add logic here to update the player's score or inventory
    }
}
