using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePlacer : MonoBehaviour
{
    [SerializeField] private GameObject collectablePrefab; // The collectable prefab to instantiate
    [SerializeField] private Transform[] circleCenters; // Array of transforms representing the centers of the circles
    [SerializeField] private float[] radii; // Array of radii for each circle
    [SerializeField] private int[] collectablesPerCircle; // Array of the number of collectables per circle

    private void Start()
    {
        PlaceCollectables();
    }

    private void PlaceCollectables()
    {
        for (int i = 0; i < circleCenters.Length; i++)
        {
            float angleStep = 360f / collectablesPerCircle[i];
            for (int j = 0; j < collectablesPerCircle[i]; j++)
            {
                float angle = j * angleStep; // Calculate the current angle for this collectable
                Vector3 position = CalculatePositionOnCircle(circleCenters[i].position, radii[i], angle); // Calculate the position on the circle at this angle
                Instantiate(collectablePrefab, position, Quaternion.identity); // Instantiate the collectable at this position
            }
        }
    }

    private Vector3 CalculatePositionOnCircle(Vector3 center, float radius, float angle)
    {
        float radians = angle * Mathf.Deg2Rad; // Convert the angle from degrees to radians
        float x = center.x + radius * Mathf.Cos(radians); // Calculate the x-coordinate
        float y = center.y + radius * Mathf.Sin(radians); // Calculate the y-coordinate
        return new Vector3(x, y, center.z); // Return the position as a Vector3
    }
}