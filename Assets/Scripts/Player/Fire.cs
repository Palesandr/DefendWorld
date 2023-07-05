using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fire : MonoBehaviour
{
    public GameObject[] bulletPrefab = new GameObject[3];
    public GameObject bombPrefab;
    //public Transform shotPoint;
    bool shootBool = true;
    static float _bulletForce;
    public GameObject[] shootPoints = new GameObject[2];
    public GameObject flashFire;
    public GameObject shootBomb;
    static int _countBomb = 5;
    static float _updBullet;
    static float _maxUP;
    BulletAnimation ba; //создаю ссылку
    float nextSpawnTime;
    public static int changeWeapon = 1;


    public static float bulletForce
    {
        get { return _bulletForce; }
        set { _bulletForce = value; }
    }

    public static int countBomb
    {
        get { return _countBomb; }
        set { _countBomb = value; }
    }

    public static float updBullet
    {
        get { return _updBullet; }
        set { _updBullet = value; }
    }

    public static float maxUP
    {
        get { return _maxUP; }
        set { _maxUP = value; }
    }


    private void Start()
    {
        bulletForce = PlayerPrefs.GetFloat("speedBullet");
        maxUP = PlayerPrefs.GetFloat("maxUP");

        ba = GameObject.FindAnyObjectByType<BulletAnimation>();
    }

    void Update()
    {
        //Debug.Log(bbm.levelUp);
        switch (ba.levelUp)
        {
            case 0:
                if (changeWeapon == 1)
                {
                    ShootLevel(0);
                    ShootBomb();
                }
                /*if (changeWeapon == 2)
                {
                    ShootBomb();
                }*/
                break;
            case 1:
                if (changeWeapon == 1)
                {
                    ShootLevel(1);
                    ShootBomb();
                }
                /*if (changeWeapon == 2)
                {
                    ShootBomb();
                }*/
                break;
            case 2:
                if (changeWeapon == 1)
                {
                    ShootLevel(2);
                    ShootBomb();
                }
                /*if (changeWeapon == 2)
                {
                    ShootBomb();
                }*/
                break;
            default:
                if (changeWeapon == 1)
                {
                    ShootLevel(2);
                    ShootBomb();
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BonusBullet bonusBullet = collision.GetComponent<BonusBullet>();

        if (gameObject != null)
        {
            if (bonusBullet != null)
            {
                ba.LevelUp();
                updBullet = ba.xp;

                if (ba.xp % 2 == 0)
                {
                    bulletForce += 1f;
                }
            }
        }


    }
    
    void ShootLevel(int _prefab)
    {
        if (Time.time > nextSpawnTime)
        {
            //if (Input.GetMouseButtonDown(0))
            if (Input.GetMouseButton(0))
            {
                if (shootBool)
                {
                    GameObject bullet = Instantiate(bulletPrefab[_prefab], shootPoints[0].transform.position, transform.rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(shootPoints[0].transform.up * bulletForce, ForceMode2D.Impulse);
                    GameObject flashF = Instantiate(flashFire, shootPoints[0].transform.position, transform.rotation);
                    Destroy(flashF, 0.1f);
                    shootBool = false;
                    AudioManager.instance.Play("PlayerFire");
                }
                else
                {
                    GameObject bullet = Instantiate(bulletPrefab[_prefab], shootPoints[1].transform.position, transform.rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(shootPoints[1].transform.up * bulletForce, ForceMode2D.Impulse);
                    GameObject flashF = Instantiate(flashFire, shootPoints[1].transform.position, transform.rotation);
                    Destroy(flashF, 0.1f);
                    shootBool = true;
                    AudioManager.instance.Play("PlayerFire");
                }
            }
            nextSpawnTime = Time.time + 0.13f;
        }
    }

    void ShootBomb()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (countBomb > 0)
            {
                countBomb--;
                GameObject bomb = Instantiate(bombPrefab, shootBomb.transform.position, transform.rotation);
                Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();
                rb.AddForce(-shootBomb.transform.up * 2, ForceMode2D.Impulse);
                AudioManager.instance.Play("PlayerBomb");
            }
            PlayerPrefs.SetInt("countBomb", countBomb);
            PlayerPrefs.Save();
        }

    }

}
