using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSript : Singleton<PlayerSript>
{
    private Rigidbody2D Player;
    private string curPlayer;
    private Vector3 MousePos;
    public float _hpCur; //current HP which increase or decrease in gameplay

    [SerializeField] Bullet bullet;
    [SerializeField] GameplayController gpCtrl;

    [SerializeField] float maxHP = 100f; //Max HP, even plus any HP pack, max HP will equal this
    [SerializeField] float firerate = 0.5f; //Declare delay time for player shoot another bullet

    //void Awake() => Player = GetComponent<Rigidbody2D>();
    void Start()
    {
        MousePos = transform.position;
        gpCtrl.gpHP = _hpCur = maxHP;
        StartCoroutine(OnAttack());
    }

    // Update is called once per frame
    void Update() => OnMove();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Kamikaze")
        {
            _hpCur -= Mathf.Floor(_hpCur / 2);
        }else if(collision.tag == "Enemy" || collision.tag == "Ebullet")
        {
            print("hpcur before cal: " + _hpCur);
            _hpCur -= 1;
            print("hpcur after cal: " + _hpCur);
            //gpCtrl.OnDownHPUIs(_hpCur);
            if (_hpCur <= 0)
            {
                OnDead();
            }
        }
    }
    private void OnMove()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get current position of mouse on screen
        MousePos = new Vector3(MousePos.x, MousePos.y, 0f);
        Vector3 temp = Vector3.Lerp(transform.position, MousePos, 100 * Time.deltaTime);
        transform.position = temp;
    }
    private IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(firerate);
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(OnAttack());
    }
    private void OnDead()
    {
        gpCtrl.ShowOptionPanel(true);
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void getCurPlayerName()
    {
        curPlayer = gameObject.name;
        print(curPlayer);
    }
}
