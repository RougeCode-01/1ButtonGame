using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Placer : MonoBehaviour
{
    [SerializeField] private GameObject Collectableprefab;
    [SerializeField] private Transform circleCenter;
    [SerializeField] private float numofCollectable;
    [SerializeField] private float Radius;
    void Start()
    {
        PlaceCollectable();
    }


    void PlaceCollectable()
    {
        float anglestep = 360/numofCollectable;// angle between each collectable
        for (int i = 0; i < numofCollectable; i++)
        {
            float angle = anglestep * i;// Calculate current angle for the collectable  
            Vector3 position = CalculatePosition(angle);// Calculates position on the circle 
            Instantiate(Collectableprefab, position, Quaternion.identity);
            Debug.Log("create Collectables");
        }
    }
    
    private Vector3 CalculatePosition(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;// Converts degree to radian
        float x = circleCenter.position.x + Radius * Mathf.Cos(radian);// clculates x cordinates    
        float y = circleCenter.position.y + Radius * Mathf.Sin(radian);// Calculates y cordinates
        return new Vector3(x, y, circleCenter.position.z);
    }
}
