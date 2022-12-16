using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public float reloadSpeed;
    public GameObject scoreText;
    public int health;
    public int score;

    private float facingDirX = 1f;
    private float Diry = 0f;
    private float Dirx = 0f;
    private float reloadTime = 0f;
    private Vector3 spawnPos;
    private void Start()
    {
        spawnPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            Diry = 0f;
        }
    }
    void Update()
    {
        if (health <= 0)
        {
            transform.position = spawnPos;
            health = 1;
        }
        if (transform.position.y <= -11)
        {
            health -= 1;
        }
        if (name == "player 1")
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                Dirx = 1f;
                facingDirX = 1f;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                Dirx = 1f;
                facingDirX = -1f;
            }
            else
            {
                Dirx = 0;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Diry = 1f;
            }
            if (Input.GetKeyDown(KeyCode.E) && reloadTime <= 0)
            {
                GameObject Bullet = Instantiate(bullet, new Vector3(transform.position.x + (facingDirX * 2), transform.position.y, transform.position.z), Quaternion.identity);
                Bullet.GetComponent<bullet>().dirx = facingDirX;
                Bullet.GetComponent<bullet>().origin = gameObject;
                reloadTime = reloadSpeed;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                Dirx = 1f;
                facingDirX = 1f;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                Dirx = 1f;
                facingDirX = -1f;
            }
            else
            {
                Dirx = 0;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Diry = 1f;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6) && reloadTime <= 0)
            {
                GameObject Bullet = Instantiate(bullet, new Vector3(transform.position.x+(facingDirX*2), transform.position.y, transform.position.z), Quaternion.identity);
                Bullet.GetComponent<bullet>().dirx = facingDirX;
                Bullet.GetComponent<bullet>().origin = gameObject;
                reloadTime = reloadSpeed;
            }
        }
        reloadTime -= Time.deltaTime;
        transform.Translate(speed * Dirx * Time.deltaTime, speed * Diry * Time.deltaTime, 0);
    }
}

