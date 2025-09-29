# Learn For Game 1

using System.Collections;                -|
using System.Collections.Generic;         | //Imports
using UnityEngine;                       -|

public class SegmentGenerator : MonoBehaviour //Class For generating Segments
{
    public GameObject[] segment; //General Array for all segments making it infinite
    [SerializeField] int zPos = 50; //z position for the segments
    [SerializeField] bool createSegments = false; //flag to control segment creation
    [SerializeField] int segmentNumber;
    void Update() //Like a For Loop
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
            yield return new WaitForSeconds(3f); //wait for 1 second before generating the next segment
            createSegments = false; //reset the flag

        }
    }



The Process Goes on Like This:
    1. Goes into Void Update() and then Into the For IF Condition, checking if there is a segment that should be created.
    2. If False, it Changes creatSegments into true, to start creating the new segment.
    3. Then Calls the StartCouroutine, going to IEnumerator perorming the body.
    4. Then Changing the createSegments to False Once Again, which leads to Executing the If condition inside the Update once Again Making it a For loop.