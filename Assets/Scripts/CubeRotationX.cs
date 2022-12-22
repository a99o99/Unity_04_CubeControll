using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotationX : MonoBehaviour
{
    public float rotateSpeed = 10f;

    void Update()
    {
        RotationX();
    }

    public void RotationX()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f, -Input.GetAxis("Mouse X") * rotateSpeed, 0f);
        }
    }
}
