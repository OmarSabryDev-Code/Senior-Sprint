using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0; // Static variable to keep track of the coin count
    [SerializeField] GameObject coinDisplay; // Reference to the UI element that displays the coin count
    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "Coins: " + coinCount; // Update the UI with the current coin count
    }
}
