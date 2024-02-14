using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInputReciever : InputReciever
{
    private Vector3 clickPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Cast a visual ray for debugging
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 4f);

            if (Physics.Raycast(ray, out hit))
            {
                clickPosition = hit.point;
                Debug.Log("Hit point is " + hit.point);
                OnInputRecieved();
            }
        }
    }

    public override void OnInputRecieved()
    {
        foreach (var handler in inputHandlers)
        {
            handler.ProcessInput(clickPosition, null, null);
        }
    }
}
