using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemyship : MonoBehaviour
{

    public GameObject Enemybullet;
    public GameObject Explosion;
    public float speed = 4f;
    // Use this for initialization
    void Start()
    {
        Instantiate(Enemybullet, transform.position, Quaternion.identity);
        StartCoroutine(Creatbullet());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Destroy(collision.gameObject);
            Destroy(Instantiate(Explosion, transform.position, this.transform.rotation), 2);

                    }
        if (collision.tag == "Edge")
        {
            Destroy(this.gameObject);
        }
    }
    public void Move()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
        if (temp.y > 6) Destroy(this.gameObject);
    }
    IEnumerator Creatbullet()
    {
        yield return new WaitForSeconds(2);
        Vector2 temp = transform.position;
        temp.x = transform.localScale.x;
        Instantiate(Enemybullet, temp, transform.rotation);
        StartCoroutine(Creatbullet());
    }
}
