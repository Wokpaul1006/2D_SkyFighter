using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearPerShot : MonoBehaviour
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
    }
    private void MoveLinear() => transform.position += Vector3.down * Time.deltaTime * movespeed;
    private void OnDead() => Destroy(gameObject);

    private IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(Ebullet, new Vector3(transform.position.x, transform.position.y - 0.5f, 0f), Quaternion.identity);
        Ebullet.DetectSpawner("Linear", "down");
        StartCoroutine(OnAttack());
    }
}
