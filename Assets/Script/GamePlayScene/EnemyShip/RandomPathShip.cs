using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPathShip : MonoBehaviour
{
    [SerializeField] float movespeed, tempXDiagonal, tempYDiagonal;
    //[SerializeField] int randDecide, refreshRouteTime;
    //[SerializeField] bool isHitLEdge, isHitREdge, isHitBotEdge, isHitTopEdge, isFirstSpawn;
    private void Start()
    {
        //randDecide = 0;
        movespeed = 5f;
        //refreshRouteTime = 0;
        //SetAllFalse();
        //isFirstSpawn = true;
        GetComponent<Rigidbody2D>();
        StartCoroutine(RandMove());
    }
    private void Update()
    {
        //RandMove();
        //if(isFirstSpawn == true) 
        //{
        //    if(randDecide == 0) { RandomDecide(1, 3); }
        //    else
        //    {
        //        print(refreshRouteTime);
        //        if(refreshRouteTime == 1) { MoveLinearDown(); }
        //        else if(refreshRouteTime == 2) { MoveDiagonalDownLeft(); }
        //        else if( refreshRouteTime == 3) { MoveDiagonalDownRight(); }
        //        refreshRouteTime++;
        //        if(refreshRouteTime > 50 || isHitBotEdge == true || isHitLEdge == true || isHitREdge == true) { isFirstSpawn = false; randDecide = 0 ; refreshRouteTime = 0; print("STOPEDDDDDDDDDDDD"); }
        //    }
        //}
        //else
        //{
        //    if(randDecide != 0)
        //    {

        //    }
        //}
        ////if(isHitBotEdge == true)
        ////{
        ////    print("in up");
        ////    MoveLinearUp();
        ////}
        ////if (isHitLEdge == true) 
        ////{
        ////    RandomDecide(10, 15);
        ////    if (randDecide > 10 && randDecide <= 13 || isHitLEdge) MoveDiagonalDownRight();
        ////    else if (randDecide > 13 && randDecide <= 15 || isHitLEdge) MoveDiagonaUpRight();
        ////}
        ////else if (isHitREdge == true)
        ////{
        ////    RandomDecide(6, 10);
        ////    if (randDecide > 5 && randDecide <= 7) MoveDiagonalDownLeft();
        ////    else if (randDecide > 7 && randDecide <= 10) MoveDiagonalUpLeft();
        ////}
        ////else 
        ////{
        ////    MoveLinearDown();
        ////}
    }

    //private void SetAllFalse()
    //{
    //    isHitLEdge = false;
    //    isHitREdge = false;
    //    isHitBotEdge = false;
    //    isHitTopEdge = false;
    //    isFirstSpawn = false;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameplayController.Instance.gpExp += 1;
            OnDead();
        }
        //else if (collision.tag == "BotEdge")
        //{
        //    SetAllFalse();
        //    isHitBotEdge = true;
        //}else if(collision.tag == "LEdge") 
        //{
        //    SetAllFalse();
        //    isHitLEdge = true; 
        //}
        //else if(collision.tag == "REdge") 
        //{
        //    SetAllFalse();
        //    isHitREdge = true;
        //}
        //else if (collision.tag == "Spawner")
        //{
        //    SetAllFalse();
        //    isHitTopEdge = true;
        //}
    }

    private void OnDead() => Destroy(gameObject);
    
    private void RandomDecide(int range1, int range2)
    {
        //Logic: if 0 - 2, linear down, if 2 - 5 diagonal down right, if 5 - 7 linear up, if 7 - 10 diagonal up right, if 10 - 12 diagonal down left, if 12 - 15 diagonal up left
        //randDecide = Random.Range(range1, range2);
    }

    #region Move Manage Section
    private IEnumerator RandMove() 
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 temp = new Vector3();
        temp.x = Random.Range(-3, 3);
        temp.y = Random.Range(-6, 6);
        transform.position = temp ;
        StartCoroutine(RandMove());
    } 
    private void MoveLinearDown() => transform.position += Vector3.down * Time.deltaTime * movespeed;
    private void MoveLinearUp() { transform.position += Vector3.up * Time.deltaTime * movespeed; print(transform.position); }
    private void MoveDiagonalUpLeft()
    {
        tempXDiagonal = Time.deltaTime * movespeed * 0.5f;
        tempYDiagonal = Time.deltaTime * movespeed * 0.5f;
        transform.position -= new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    private void MoveDiagonalDownLeft()
    {
        tempXDiagonal = Time.deltaTime * movespeed * 0.5f;
        tempYDiagonal = Time.deltaTime * movespeed * 0.5f;
        transform.position -= new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    private void MoveDiagonalDownRight()
    {
        tempXDiagonal = Time.deltaTime * -movespeed * 0.55f;
        tempYDiagonal = Time.deltaTime * movespeed * 0.5f;
        transform.position -= new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    private void MoveDiagonaUpRight()
    {
        tempXDiagonal = Time.deltaTime * movespeed * 0.5f;
        tempYDiagonal = -Time.deltaTime * movespeed * 0.5f;
        transform.position -= new Vector3(tempXDiagonal, tempYDiagonal, 0);
    }
    #endregion
}
