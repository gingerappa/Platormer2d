using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 3f;
    public float dirx = 1f;
    
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(transform.right * dirx * speed * Time.deltaTime);

    }
}
