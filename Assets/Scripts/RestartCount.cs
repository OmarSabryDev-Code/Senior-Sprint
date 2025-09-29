using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Debug.Log("Reset script ran");
        MasterInfo.coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
