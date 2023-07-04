using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoShip : MonoBehaviour
{
    [SerializeField] float chronoTime;
    [SerializeField] private Vector2 randPos;
    [SerializeField] private bool isHide;
    private void Start()
    {
        //HideShip(false);
        chronoTime = 1f;
        GetComponent<Rigidbody2D>();
        MoveChrono();
    }
    private void Update()
    {
        //MoveLinear();
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
    //private void MoveLinear() => transform.position += Vector3.down * Time.deltaTime * chronoTime;
    private void OnDead() => Destroy(gameObject);
    //private IEnumerator MoveChrono()
    //{
    //    yield return new WaitForSeconds(chronoTime); //chronoTime = 2f;
    //    if (isHide == false)
    //    {
    //        HideShip(true);
    //        randPos.x = Random.Range(0, 5);
    //        randPos.y = Random.Range(0, 20);
    //        transform.position = randPos;
    //        //Invoke("MoveChrono", 1f);
    //    }
    //    else if(isHide == true)
    //    {
    //        HideShip(false);
    //    }
    //    StartCoroutine(MoveChrono());

    //}

    private void MoveChrono()
    {
        randPos.x = Random.Range(-5, 5);
        randPos.y = Random.Range(-20, 20);
        transform.position = randPos;
        Invoke("MoveChrono", chronoTime);
    }

    private void HideShip(bool show)
    {
        isHide = show;
        gameObject.GetComponent<Renderer>().enabled = show;
    }
}
