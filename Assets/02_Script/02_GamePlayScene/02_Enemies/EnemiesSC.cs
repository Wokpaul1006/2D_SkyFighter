using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSC : MonoBehaviour
{
    void Start() { }
    private void Update() { }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PBullet")
        {
            OnDeadPlusPoint();
        }else if (collision.gameObject.tag == "Edge")
        {
            OnDestroyThis();
        }
    }

    void OnDeadPlusPoint()
    {
        Destroy(gameObject);
        //Put code plus point here
    }
    void OnDestroyThis()
    {
        Destroy(gameObject);
    }
}
