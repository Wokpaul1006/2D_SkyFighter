using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : EnemiesSC
{
    [SerializeField] EBullet Ebullet;
    [SerializeField] float movespeed;
    private void Start()
    {
        movespeed = 4f;
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
        AttackLinear();
        //AttackDownLeft();
        //AttackDownRight();
        StartCoroutine(OnAttack());
    }

    private void AttackLinear()
    {
        Instantiate(Ebullet, new Vector3(transform.position.x, transform.position.y - 0.25f, 0), Quaternion.identity);
        Instantiate(Ebullet, new Vector3(transform.position.x + 0.25f, transform.position.y, 0), Quaternion.identity);
        Instantiate(Ebullet, new Vector3(transform.position.x - 0.25f, transform.position.y, 0), Quaternion.identity);
        Ebullet.DetectSpawner("Cone", "down");
    }

    private void AttackDownLeft()
    {
        Instantiate(Ebullet, new Vector3(transform.position.x + 0.25f, transform.position.y - 0.25f, 0), Quaternion.identity);
        Ebullet.DetectSpawner("Cone", "downleft");
    }

    private void AttackDownRight()
    {
        Instantiate(Ebullet, new Vector3(transform.position.x - 0.25f, transform.position.y - 0.25f, 0), Quaternion.identity);
        Ebullet.DetectSpawner("Cone", "downright");
    }
}
