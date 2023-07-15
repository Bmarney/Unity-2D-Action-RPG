using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseUtilities : MonoBehaviour
{
    private Camera cam;


    private void Awake()
    {
        cam = Camera.main;
    }


    public Vector2 GetMouseDirection(Vector2 origin)
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(mouseScreenPos);
        return mouseWorldPos - origin;
    }

}
