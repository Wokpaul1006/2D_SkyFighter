using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float movespeed = 5f;

    private void Update() => MoveLinear();
    private void OnTriggerEnter2D(Collider2D collision) { if (collision.tag == "Spawner") { Destroy(gameObject); } }
    private void MoveLinear() => transform.position += Vector3.up * Time.deltaTime * movespeed;
}
