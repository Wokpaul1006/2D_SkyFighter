using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : Bullet
{
    [SerializeField] float moveSpd;
    [SerializeField] float tempXDiagonal, tempYDiagonal;
    [SerializeField] private string spawnName, direction;
    private void Start()
    {
        GetComponent<Rigidbody2D>();
        moveSpd = 10f;
    }
    // Update is called once per frame
    void Update()
    {
        if(spawnName == "Bouncer")
        {
            if(direction == "up") { OnMoveUp(); }
            else if (direction == "down") { OnMoveDown(); }
            else if (direction == "left") { OnMoveLeft(); }
            else if (direction == "right") { OnMoveRight(); }
            else if (direction == "downleft") { OnMoveDownLeft(); }
            else if (direction == "upleft") { OnMoveUpLeft(); }
            else if (direction == "downright") { OnMoveDownRight(); }
            else if (direction == "upright") { OnMoveUpRight(); }
        }
        else if(spawnName == "Linear" || spawnName == "Dual")
        {
            OnMoveDown();
        }
        else if(spawnName == "Cone")
        {
            if(direction == "down") { OnMoveDown(); }
            else if(direction == "downright") { OnMoveDownRight(); }
            else if(direction == "downleft") { OnMoveDownLeft (); }
        }
    }

    private void OnMoveDown() => transform.position += Vector3.down * Time.deltaTime * moveSpd;
    private void OnMoveUp() => transform.position += Vector3.up * Time.deltaTime * moveSpd;
    private void OnMoveLeft() => transform.position += Vector3.left * Time.deltaTime * moveSpd;
    private void OnMoveRight() => transform.position += Vector3.right * Time.deltaTime * moveSpd;

    private void OnMoveDownRight()
    {
        tempXDiagonal = Time.deltaTime * moveSpd * 0.5f;
        tempYDiagonal = -Time.deltaTime * moveSpd * 0.5f;
        transform.position += new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    private void OnMoveUpRight()
    {
        tempXDiagonal = Time.deltaTime * moveSpd * 0.5f;
        tempYDiagonal = Time.deltaTime * moveSpd * 0.5f;
        transform.position += new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    private void OnMoveUpLeft()
    {
        tempXDiagonal = -Time.deltaTime * moveSpd * 0.5f;
        tempYDiagonal = Time.deltaTime * moveSpd * 0.5f;
        transform.position += new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    private void OnMoveDownLeft()
    {
        tempXDiagonal = -Time.deltaTime * moveSpd * 0.5f;
        tempYDiagonal = -Time.deltaTime * moveSpd * 0.5f;
        transform.position += new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    public void DetectSpawner(string spawnerName, string shotDirect)
    {
        spawnName = spawnerName;
        direction = shotDirect;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            OnDisapearEdge();
        }
        else if (collision.gameObject.tag == "Player")
        {
            OnDisapearPlayer();
        }
    }
}
