using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

public class PlayerSript : MonoBehaviour
{
    private Vector3 MousePos;
    public int hpCur = 0; //current HP which increase or decrease in gameplay
    public int ammoCur = 0; //current ammo in amobox;
    public int apCur = 0;

    [SerializeField] PBullet bullet;
    private int maxHP = 100; //Max HP, even plus any HP pack, max HP will equal this
    private int maxAmmo = 30;
    private int maxAP = 100;

    private float reloadAmmoTime;
    private bool isReload;
    void Start()
    {
        MousePos = transform.position;
        hpCur = maxHP;
        ammoCur = maxAmmo;
        apCur = maxAP;
        reloadAmmoTime = 0.25f;

        isReload = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            OnMoveByMouse();
            if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
            {
                OnAttackNormal();
            }
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            OnMoveByTouchScreen();
            if (Input.touchCount > 0)
            {
                OnAttackNormal();
            }
        }

        if (ammoCur == 0)
        {
            ReloadAmmo();
        }
    }
    private void OnMoveByTouchScreen()
    {
        if(Input.touchCount > 1)
        {
            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get current position of mouse on screen
            MousePos = new Vector3(MousePos.x, MousePos.y, 0f);
            Vector3 temp = Vector3.Lerp(transform.position, MousePos, 100 * Time.deltaTime);
            transform.position = temp;
        }
    }
    private void OnMoveByMouse()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get current position of mouse on screen
        MousePos = new Vector3(MousePos.x, MousePos.y, 0f);
        Vector3 temp = Vector3.Lerp(transform.position, MousePos, 100 * Time.deltaTime);
        transform.position = temp;
    }
    private void OnAttackNormal()
    {
        if(isReload == false) 
        {
            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
            ammoCur--;
        }

    }
    public void ReloadAmmo()
    {
        if (ammoCur == maxAmmo)
        {
            isReload = true;
        }else if (ammoCur == 0)
        {
            isReload = false;
            do
            {
                ammoCur++;
            }while(ammoCur < maxAmmo);
        }
    }
}
