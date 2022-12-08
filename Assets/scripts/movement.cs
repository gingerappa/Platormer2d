using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public GameObject bullet;

    private float facingDirX = 1f;

    void Update()
    {
        float dirx = Input.GetAxisRaw("Horizontal");
        transform.Translate(transform.right * dirx * speed * Time.deltaTime);
        if(dirx != 0)
        {
            facingDirX = dirx;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject Bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Bullet.GetComponent<bullet>().dirx = facingDirX;
        }
    }
}
