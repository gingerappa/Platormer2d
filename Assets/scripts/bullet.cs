using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 3f;
    public float dirx = 1f;
    public GameObject origin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            collision.gameObject.GetComponent<movement>().health -= 1;
            origin.GetComponent<movement>().score += 1;
            origin.GetComponent<movement>().scoreText.GetComponent<Text>().text = origin.GetComponent<movement>().score.ToString();
        }
        finally
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(transform.right * dirx * speed * Time.deltaTime);

    }
}
