using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunRoot; 
    public Transform bullet;
    public ParticleSystem particleBase;

    public float delay = 0.5f;
    public float damage = 2;

    private bool canShot = true;

    public void Shot()
    {
        if (canShot == false)
            return;

        Debug.Log("Shot");
        canShot = false;

        particleBase.transform.position = gunRoot.position;
        particleBase.Play();

        var bulletObject = Instantiate(bullet, gunRoot.position, gunRoot.rotation);
        bulletObject.gameObject.SetActive(true);

        Invoke("CheckDelay", delay);
    }

    void CheckDelay()
    {
        canShot = true;
    }
}
