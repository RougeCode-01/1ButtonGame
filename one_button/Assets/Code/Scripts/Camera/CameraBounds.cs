using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraBounds : MonoBehaviour
{
    private BoxCollider2D _collider;//Reference of Camera collider component
    private Camera _camera;//Reference of Camera component

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();//Get the collider component
        _camera = GetComponent<Camera>();//Get the Camera component
    }

    private void Update()
    {
        //Set the size of the collider using the camera's size
        _collider.size = new Vector2((float)(_camera.orthographicSize * 4), _camera.orthographicSize * 2);
    }
}

