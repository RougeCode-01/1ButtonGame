using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacer : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] circleCenters;
    [SerializeField] private float[] radii;
    [SerializeField] private float enemySpeed;
    [SerializeField] private int[] numberOfEnemies; // Array specifying the number of enemies per circle

    void Start()
    {
        PlaceEnemies();
    }
    private void PlaceEnemies()
    {
        for (int i = 0; i < circleCenters.Length; i++)
        {
            for (int j = 0; j < numberOfEnemies[i]; j++)
            {
                // Generate a random angle for the initial position
                float randomAngle = Random.Range(0f, 360f);

                // Calculate the initial position on the circle at the random angle
                Vector3 initialPosition = CalculatePositionOnCircle(circleCenters[i].position, radii[i], randomAngle);

                // Instantiate and configure the enemy
                GameObject enemy = Instantiate(enemyPrefab, initialPosition, Quaternion.identity);
                Enemy_movement enemyMovement = enemy.GetComponent<Enemy_movement>();
                enemyMovement.circleCenter = circleCenters[i];
                enemyMovement.radius = radii[i];
                enemyMovement.speed = enemySpeed; // Assign the speed to the enemy
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

