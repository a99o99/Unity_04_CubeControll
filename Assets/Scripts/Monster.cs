using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    private float speed = 0.5f;
    private float speedFactor = 0.2f;

    private Transform target;


    private void  Start()
    {
        float randSpeedFactor = Random.Range(1 - speedFactor, 1 + speedFactor);
        speed *= randSpeedFactor;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target == null)
            return;
        Vector3 movePosition = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.position = movePosition;

        Vector3 lookPos = target.position - transform.position;
        Quaternion LookRotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Lerp(transform.rotation, LookRotation, 2 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Bullet>())
        {
            Debug.Log("총에 맞았습니다.");
            transform.position = GetGeneractePosition();
            Destroy(collision.gameObject);
        }
    }

    private Vector3 GetGeneractePosition()
    {
        Vector3 curPos = Vector3.zero;

        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            int randX = Random.Range(0, 2);

            float posX = randX == 0 ? 9.5f : -9.5f;
            float posZ = Random.Range(-7.5f, 7.5f);
            curPos = new Vector3(posX, 0, posZ);
        }
        else
        {
            int randZ = Random.Range(0, 2);

            float posZ = randZ == 0 ? 7.5f : -7.5f;
            float posX = Random.Range(-9.5f, 9.5f);
            curPos = new Vector3(posX, 0, posZ);
        }
        return curPos;
    }
}
