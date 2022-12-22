using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject target;
    public float xmove, ymove;
    public float rotateSpeed = 5000f;

    private void Start()
    {
        target = GameObject.Find("Cube");
    }

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            xmove = Input.GetAxis("Mouse X") * Time.deltaTime * 50f;
            ymove = Input.GetAxis("Mouse Y") * Time.deltaTime * 50f;

            Vector3 targetPosition = target.transform.position;

            transform.RotateAround(targetPosition, Vector3.right, -ymove);
            transform.RotateAround(targetPosition, Vector3.up, xmove);

            transform.LookAt(targetPosition);
        }
    }
}
