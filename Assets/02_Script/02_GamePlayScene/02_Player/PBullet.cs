using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : Bullet
{
    [SerializeField] GameplayController gm;
    private float movespeed = 5f;
    private void Start()
    {
        gm = GameObject.Find("GameplayController").GetComponent<GameplayController>();
    }
    private void Update() => MoveLinear();
    private void MoveLinear() => transform.position += Vector3.up * Time.deltaTime * movespeed;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            OnDisapearEdge();
        }
        else if (collision.gameObject.tag == "Foe")
        {
            OnDisapearFoe();
            gm.enemiesKilled++;
        }
    }
}
