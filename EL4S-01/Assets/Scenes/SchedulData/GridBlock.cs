using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBlock : MonoBehaviour
{
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnMouseUp()
    {
        GameObject[] gridBlocks = GameObject.FindGameObjectsWithTag("Grid");
        float minDistance = Mathf.Infinity;
        Vector3 closestPosition = originalPosition;

        foreach (GameObject gridBlock in gridBlocks)
        {
            float distance = Vector3.Distance(transform.position, gridBlock.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestPosition = gridBlock.transform.position;
            }
        }

        closestPosition += Vector3.up; // yÀ•W‚¾‚¯+1‚ÉˆÚ“®
        transform.position = closestPosition;
    }
}
