using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualShot : EnemiesSC
{
    [SerializeField] EBullet Ebullet;
    [SerializeField] float movespeed;
    private void Start()
    {
        movespeed = 5f;
        GetComponent<Rigidbody2D>(); 
        StartCoroutine(OnAttack());
    }
    private void Update()
    {
        MoveLinear();
    }
    private void MoveLinear() => transform.position += Vector3.down * Time.deltaTime * movespeed;

    private IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(Ebullet, new Vector3(transform.position.x - 0.15f, transform.position.y,0), Quaternion.identity);
        Ebullet.DetectSpawner("Dual", "down");
        Instantiate(Ebullet, new Vector3(transform.position.x + 0.15f, transform.position.y,0), Quaternion.identity);
        Ebullet.DetectSpawner("Dual", "down");
        StartCoroutine(OnAttack());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
