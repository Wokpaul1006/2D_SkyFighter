using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    [SerializeField] float movespeed;
    [SerializeField] Vector3 curPlayerPos;
    private void Start()
    {
        movespeed = 9f;
        GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MoveLinear();
        //MoveToPlayerDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player" || collision.tag == "bullet")
        {
            print(collision.tag);
            GameplayController.Instance.gpExp += 1;
            OnDead(collision.tag);
        }else if(collision.tag == "BotEdge") { print(collision.tag);  OnDead(collision.tag); }
    }
    private void MoveLinear() => transform.position += Vector3.down * Time.deltaTime * movespeed;
    private void OnDead(string a)
    {
        Destroy(gameObject);
        //put code of explosie aimation here
    }
    //private void MoveToPlayerDirection()
    //{
    //    curPlayerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    transform.position += curPlayerPos * Time.deltaTime * movespeed;
    //}
}
