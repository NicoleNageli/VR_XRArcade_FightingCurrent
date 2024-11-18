using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segmentVariations; 
    public Transform player;     
    public GameObject startingSegment;   
    private List<GameObject> activeSegments = new List<GameObject>();

    private int zPos = 40; // Starting zPos right after startsegment
    private int segmentLength = 40; // Length of each segment

    void Start()
    {
        // Add the starting segment to the list and prevent it from being deleted
        activeSegments.Add(startingSegment);
    }

    void Update()
    {
        // Generate segments as the player moves forward
        if (player.position.z > zPos - (segmentLength * 3)) // Start generating when player is 3 segments away
        {
            GenerateSegment();
        }

        CleanupSegments(); // Remove segments behind the player
    }

    void GenerateSegment()
    {
        // Choose a random segment variation
        int randomIndex = Random.Range(0, segmentVariations.Length);
        GameObject newSegment = Instantiate(segmentVariations[randomIndex], new Vector3(0, 0, zPos), Quaternion.Euler(0, 90, 0)); 

        // Add the new segment to the active segments list
        activeSegments.Add(newSegment);

        // Move the zPos forward for the next segment
        zPos += segmentLength;
    }

    void CleanupSegments()
    {
        // Remove segments that are far behind the player
        for (int i = 0; i < activeSegments.Count; i++)
        {
            if (activeSegments[i].transform.position.z < player.position.z - (segmentLength * 3)) //delete the segments that are 3 segments behind the player
            {
                Destroy(activeSegments[i]);
                activeSegments.RemoveAt(i);
                i--; 
            }
        }
    }
}
