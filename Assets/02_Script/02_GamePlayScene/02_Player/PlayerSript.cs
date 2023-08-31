using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

public class PlayerSript : MonoBehaviour
{
    private Vector3 MousePos;
    public int dmgCur = 0;
    public int hpCur = 0; //current HP which increase or decrease in gameplay
    public int ammoCur = 0; //current ammo in amobox visible in gameplay;
    public int apCur = 0; //current AP visible in gameplay
    public float reloadAmmoSpdCur;
    public float reloadAPSpdCur;

    public int ammoMaxLoad;
    public int hpMaxLoad;
    public int apMaxLoad;

    [SerializeField] PBullet bullet;
    private int baseHP = 100; 
    private int baseAmmoLoadout = 30;
    private int baseDamage = 1;
    private float baseReloadAmmoTime = 0.25f;
    private float baseReloadAPTime = 0.5f; 
    private bool isReload;

    private int prefDamage; //Damage from PlayerPrefs
    private int prefHP; //Health from PlayerPrefs
    private int prefAmmo; //Ammo max load from PlayerPrefs
    private float prefRecharge; //Racharge max time from PlayerPrefs

    private int curCoin;
    private int prefTotalCoin;
    void Start()
    {
        GetPlayerforStart();
        SettingStartGame();
        CaculatingPlayerStat();
    }
    private void GetPlayerforStart()
    {
        prefDamage = PlayerPrefs.GetInt("CurUpgradeDmg");
        prefHP = PlayerPrefs.GetInt("CurUpgradeHP");
        prefAmmo = PlayerPrefs.GetInt("CurUpgradeMgz");
        prefRecharge = (float)PlayerPrefs.GetInt("CurUpgradeRegen");
        prefTotalCoin = PlayerPrefs.GetInt("Totalscore");
    }
    private void SettingStartGame()
    {
        MousePos = transform.position;

        isReload = false;
    }
    private void CaculatingPlayerStat()
    {
        dmgCur = baseDamage * prefDamage;
        hpCur = hpMaxLoad = baseHP * prefHP;
        ammoCur = ammoMaxLoad =  baseAmmoLoadout * prefAmmo;
        apCur = 100;
        curCoin = 0;

        reloadAmmoSpdCur = baseReloadAmmoTime * prefRecharge;
        reloadAPSpdCur = baseReloadAPTime * prefRecharge;
    }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Foe")
        {
            hpCur -= 25;
            curCoin++;
            print(curCoin);
            CaculatingCoin(curCoin);
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
        if (ammoCur == ammoMaxLoad)
        {
            isReload = true;
        }else if (ammoCur == 0)
        {
            isReload = false;
            do
            {
                ammoCur++;
            }while(ammoCur < ammoMaxLoad);
        }
    }
    public void CaculatingCoin(int ingameCoin)
    {
        prefTotalCoin += ingameCoin;
        PlayerPrefs.SetInt("Totalscore", prefTotalCoin);
    }
}
