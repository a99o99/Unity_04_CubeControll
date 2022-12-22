using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveAndRot : MonoBehaviour
{
    GameObject hitObjet;
    Vector3 clickPoint;

    void Update()
    {
        //MoveCube();
    }

    public void MoveCube()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData))
            {
                hitObjet = hitData.transform.gameObject;
                clickPoint = new Vector3(hitData.point.x, 0, hitData.point.z);
                transform.LookAt(new Vector3(hitData.point.x, transform.position.y, hitData.point.z));
            }
        }
        transform.position = Vector3.Lerp(transform.position, clickPoint, 0.01f);
    }
}
