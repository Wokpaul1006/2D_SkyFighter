using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingShip : MonoBehaviour
{
    [SerializeField] EBullet Ebullet;
    [SerializeField] float movespeed;
    [SerializeField] float tempXDiagonal, tempYDiagonal;
    [SerializeField] private bool isHitLeft, isHitRight;
    private void Start()
    {
        isHitLeft = isHitRight = false;
        movespeed = 2f;
        GetComponent<Rigidbody2D>();
        StartCoroutine(OnAttack());
    }
    private void Update()
    {
        if ( isHitRight == false && isHitLeft == false)
        {
            int randMoveDirection = Random.Range(0, 1);
            if (randMoveDirection == 0) { MoveDiagonalLeft(); }
            else { MoveDiagonalRight(); }
        }
        else if (isHitLeft) {
            MoveDiagonalRight();
        }
        else if (isHitRight) {
            MoveDiagonalLeft(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bullet")
        {
            GameplayController.Instance.gpExp += 1;
            OnDead();
        }
        else if (collision.tag == "BotEdge")
        {
            OnDead();
        }
        else if(collision.tag == "LEdge")
        {
            isHitLeft = true;
            isHitRight = false;
        }else if(collision.tag == "REdge")
        {
            isHitRight = true;
            isHitLeft = false;
        }
    }
    private void OnDead() => Destroy(gameObject);

    private void MoveDiagonalLeft()
    {
        SelfRotate();
        tempXDiagonal = Time.deltaTime * movespeed * 0.5f;
        tempYDiagonal = Time.deltaTime * movespeed * 0.5f;
        transform.position -= new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }

    private void MoveDiagonalRight()
    {
        SelfRotate();
        tempXDiagonal = Time.deltaTime * -movespeed * 0.55f;
        tempYDiagonal = Time.deltaTime * movespeed * 0.5f;
        transform.position -= new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }

    private void SelfRotate()
    {
        transform.Rotate(0, 0, Time.deltaTime * movespeed *100);
    }
    private IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(0.25f);
        //Linear shot
        Instantiate(Ebullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity); //Down
        Ebullet.DetectSpawner("Bouncer", "down");
        Instantiate(Ebullet, new Vector3(transform.position.x, transform.position.y - 0.25f, 0), Quaternion.identity); //Up
        Ebullet.DetectSpawner("Bouncer", "up");
        Instantiate(Ebullet, new Vector3(transform.position.x + 0.25f, transform.position.y, 0), Quaternion.Euler(0, 0, -1.6f)); //Left
        Ebullet.DetectSpawner("Bouncer", "left");
        Instantiate(Ebullet, new Vector3(transform.position.x - 0.25f, transform.position.y, 0), Quaternion.Euler(0, 0, -1.6f)); //Right
        Ebullet.DetectSpawner("Bouncer", "right");

        ////Diagonal shot
        //Instantiate(Ebullet, new Vector3(transform.position.x, transform.position.y - 0.25f, 0), Quaternion.identity); //Down - Left
        //Ebullet.DetectSpawner("Bouncer", "downleft");
        Instantiate(Ebullet, new Vector3(transform.position.x + 0.25f, transform.position.y, 0), Quaternion.identity); //Down - Right
        Ebullet.DetectSpawner("Bouncer", "upleft");
        Instantiate(Ebullet, new Vector3(transform.position.x, transform.position.y - 0.25f, 0), Quaternion.identity); //Up - Left
        Ebullet.DetectSpawner("Bouncer", "downright");
        Instantiate(Ebullet, new Vector3(transform.position.x + 0.25f, transform.position.y, 0), Quaternion.identity); //Up - Right
        Ebullet.DetectSpawner("Bouncer", "upright");
        StartCoroutine(OnAttack());
    }
}
