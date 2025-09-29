using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;
    [SerializeField] int zPos = 50; //z position for the segments
    [SerializeField] bool createSegments = false; //flag to control segment creation
    [SerializeField] int segmentNumber;
    void Update()
    {
        if (createSegments == false) // check if segments should be created
        {
            createSegments = true; //reset the flag to prevent multiple calls
            StartCoroutine(SegmentGeneration()); //start the coroutine to generate segments
        }
        

    }
    IEnumerator SegmentGeneration()
    {
        // This coroutine can be used to generate segments over time
        while (true)
        {
            // Logic for generating segments goes here
            segmentNumber = Random.Range(0, 3); //randomly select a segment
            Instantiate(segment[segmentNumber], new Vector3(0, 0, zPos), Quaternion.identity); //instantiate the segment at the specified position
            zPos += 50; //increment the z position for the next segment
            yield return new WaitForSeconds(3); //wait for 1 second before generating the next segment
            createSegments = false; //reset the flag

        }
    }




}
