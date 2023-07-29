using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1 : MonoBehaviour
{
    public GameObject Enemybullet;
    public GameObject Target;
    public float speed = 6f;
    public float hitpoint = 1000f;
    //private float damage = 10;
    //public Thepath path;
    private Transform _TargetPoint;
    void Start()
    {
        //Target = GameObject.Find("Player");
        //if (path == null)
        //    return;
        //_TargetPoint = path.getPointAt(0);
    }
    void Update()
    {

        if (Lv1Controller.cointAmount >= 10)
        {
        //    transform.position = Vector2.MoveTowards(transform.position, _TargetPoint.position,
        //speed * Time.deltaTime);
        //    float Distance = Vector2.Distance(transform.position, _TargetPoint.position);
        //    if (Distance <= 0.1f)
        //        _TargetPoint = path.getNextPoint();
        //    //StartCoroutine(CreatBossBullet());
        //    if (BossHealthBar.health == 0)
        //    {
        //        Destroy(this.gameObject);
        //        SceneManager.LoadScene("Level2");
        //    }
        }
        FacetoPlayer();
    }
    public void FacetoPlayer()
    {
        Vector2 Direction = Target.GetComponent<Transform>().position - transform.position;
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation =
        Quaternion.Slerp(transform.rotation, rotation, 2f * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            BossHealthBar.health -= 10f;
            Destroy(collision.gameObject);

        }
        if (collision.tag == "Edge")
        {
            Destroy(this.gameObject);
        }
    }
    //IEnumerator CreatBossBullet()
    //{
    //    yield return new WaitForSeconds(4);
    //    Vector2 temp = transform.position;
    //    temp.x += transform.localScale.x;
    //    temp.y += transform.localScale.y;
    //    Instantiate(Enemybullet, temp, transform.rotation);
    //    StartCoroutine(CreatBossBullet());
    //}
}
