using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotationFull : MonoBehaviour
{
    public float rotateSpeed = 10f;

    void Update()
    {
        RotationFull();
    }

    public void RotationFull()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f, -Input.GetAxis("Mouse X") * rotateSpeed, 0f);
            transform.Rotate(-Input.GetAxis("Mouse Y") * rotateSpeed, 0f, 0f);
        }
    }
}
