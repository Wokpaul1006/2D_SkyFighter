using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : EnemiesSC
{
    [SerializeField] float movespeed;
    [SerializeField] Vector3 curPlayerPos;
    private void Start()
    {
        movespeed = 2f;
        GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MoveLinear();
    }
    private void MoveLinear() => transform.position += Vector3.down * Time.deltaTime * movespeed;

    private void MoveToPlayerDirection()
    {
        curPlayerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position += curPlayerPos * Time.deltaTime * movespeed;
    }
}
