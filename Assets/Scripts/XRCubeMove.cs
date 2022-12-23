using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCubeMove : MonoBehaviour
{
    GameObject hitObjet;
    Vector3 clickPoint;

    public XRRayInteractor Interactor;

    void Update()
    {
        CheckInputFromXR();
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

    public void CheckInputFromXR()
    {
        if (Interactor == null)
            return;

        RaycastHit hit;

        if (Interactor.TryGetCurrent3DRaycastHit(out hit))
        {
            clickPoint = new Vector3(hit.point.x, 0, hit.point.z);
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

        transform.position = Vector3.Lerp(transform.position, clickPoint, 0.01f);

    }
}
