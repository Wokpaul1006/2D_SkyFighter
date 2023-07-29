using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public GameObject Target;
    //public Thepath path;
    public float speed = 6f;
    private Transform _TargetPoint;
    // Use this for initialization
    void Start ()
    {
        //Target = GameObject.Find("Player");
        //if (path == null)
        //    return;
        //_TargetPoint = path.getPointAt(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //transform.position = Vector2.MoveTowards(transform.position, _TargetPoint.position,
        //speed * Time.deltaTime);
        //float Distance = Vector2.Distance(transform.position, _TargetPoint.position);
        //if (Distance <= 0.1f)
        //    _TargetPoint = path.getNextPoint();
    }
}
