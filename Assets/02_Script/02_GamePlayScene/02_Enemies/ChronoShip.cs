using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChronoShip : EnemiesSC
{
    [SerializeField] float chronoTime;
    [SerializeField] int hideTime;
    [SerializeField] private Vector2 randPos;
    [SerializeField] private bool isHide;
    private void Start()
    {
        chronoTime = 1f;
        GetComponent<Rigidbody2D>();
        MoveChrono();
    }
    private void Update()
    {    }

    private void MoveChrono()
    {
        hideTime++;
        randPos.x = Random.Range(-5, 5);
        randPos.y = Random.Range(-20, 20);
        transform.position = randPos;
        Invoke("MoveChrono", chronoTime);
        if(chronoTime == hideTime % 2)
        {
            HideShip(true);
        }
        else { HideShip(false);}
    }

    private void HideShip(bool show)
    {
        isHide = show;
        gameObject.GetComponent<Image>().enabled = show;
    }
}
