using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    //Vector2 moveLimit = new Vector2(-0.22f, 0.2f);
    //Vector3 mousePos;


    //void Update()
    //{
    //    LookMouse();
    //}

    //void Move()
    //{
    //    transform.localPosition = ClampPosition(transform.localPosition);
    //}

    //public Vector3 ClampPosition(Vector3 position)
    //{
    //    return new Vector3
    //        (
    //            Mathf.Clamp(position.x, -moveLimit.x, moveLimit.x),
    //            -7f,
    //            0
    //        );
    //}
    
    Camera cam;
    Vector2 moveLimit = new Vector2(-0.22f, 0.2f);

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }


    private void Update()
    {
        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
    }
}
