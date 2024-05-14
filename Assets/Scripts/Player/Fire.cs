using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
//using YG;


public class Fire : MonoBehaviour
{
    public GameObject[] bulletPrefab = new GameObject[3];
    public GameObject bombPrefab;

    public GameObject bombWavePrefab;
    //public ParticleSystem PS_expBombWave;

    public GameObject energyPrefab;
    //public Transform shotPoint;
    bool shootBool = true;
    bool _contin;
    static float _bulletForce;
    public GameObject[] shootPoints = new GameObject[2];
    public GameObject flashFire;
    public GameObject shootBomb;
    //public GameObject shootEnergy;
    static int _countBomb = 5;
    static int _countBombWave = 0;
    static int _countEnergy = 0;
    static float _updBullet;
    static float _maxUP;
    BulletAnimation ba; //создаю ссылку
    float nextSpawnTime;
    public static int changeWeapon = 1;

    static int _energy;
    public float tempEnergy;
    public float energyForce = 10;

    float maxEnergy = 30;

    public GameObject ps_Right;
    public GameObject ps_Left;
    public GameObject ps_Flash;




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
    
    public static int countBombWave
    {
        get { return _countBombWave; }
        set { _countBombWave = value; }
    }

    public static int countEnergy
    {
        get { return _countEnergy; }
        set { _countEnergy = value; }
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

    public static int energy
    {
        get { return _energy; }
        set { _energy = value; }
    }


    private void Start()
    {
        updBullet = 0;
        bulletForce = PlayerPrefs.GetFloat("speedBullet");
        maxUP = PlayerPrefs.GetFloat("maxUP");

        /*bulletForce = YandexGame.savesData.speedBullet;
        maxUP = YandexGame.savesData.maxUP;

        YandexGame.LoadProgress();*/

        ba = FindAnyObjectByType<BulletAnimation>();
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
                    if (changeWeapon == 2)
                    {
                        AccumulationEnergy();
                        ShootBomb();
                    }
                    if (changeWeapon == 3)
                    {
                        ShootBombWave();
                        ShootBomb();
                    }
                    break;
                case 1:
                    if (changeWeapon == 1)
                    {
                        ShootLevel(1);
                        ShootBomb();
                    }
                    if (changeWeapon == 2)
                    {
                        AccumulationEnergy();
                        ShootBomb();
                    }
                    if (changeWeapon == 3)
                    {
                        ShootBombWave();
                        ShootBomb();
                    }
                    break;
                case 2:
                    if (changeWeapon == 1)
                    {
                        ShootLevel(2);
                        ShootBomb();
                    }
                    if (changeWeapon == 2)
                    {
                        AccumulationEnergy();
                        ShootBomb();
                    }
                    if (changeWeapon == 3)
                    {
                        ShootBombWave();
                        ShootBomb();
                    }
                    break;
                default:
                if (changeWeapon == 1)
                {
                    ShootLevel(2);
                    ShootBomb();
                }
                if (changeWeapon == 2)
                {
                    AccumulationEnergy();
                    ShootBomb();
                }
                if (changeWeapon == 3)
                {
                    ShootBombWave();
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
             //{
             //if (Mouse.current.leftButton.isPressed)
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

    //накапливаем энергию
    void AccumulationEnergy()
    {

        if (Input.GetMouseButtonDown(0))
        //if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (countEnergy > 0)
            {
                AudioManager.instance.Play("AcumEnergy");
            }
        }

        //удерживаем левую кнопку, копим энегрию
        if (Input.GetMouseButton(0))
        //if (Mouse.current.leftButton.isPressed)
        {
            if (countEnergy > 0)
            {
                // Увеличиваем значение энергии во время удержания клавиши
                tempEnergy += Time.deltaTime * 3;

                tempEnergy = Mathf.Clamp(tempEnergy, 0, maxEnergy);

                ps_Right.SetActive(true);
                ps_Left.SetActive(true);
            }
        }

        //отпускаем кнопку и стреляем
        if (Input.GetMouseButtonUp(0))
        //if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            energy = (int)tempEnergy;

            ps_Right.SetActive(false);
            ps_Left.SetActive(false);
            if (countEnergy > 0)
            {
                AudioManager.instance.Stop("AcumEnergy");
                AudioManager.instance.Play("EnergyShoot");
                GameObject PSF = Instantiate(ps_Flash, transform.position, Quaternion.identity);
                Destroy(PSF, 0.1f);
            }
            //Debug.Log(energy);
            //здесь выстрел
            EnergyShoot();

            tempEnergy = 0;


        }
    }

    //стреляем энергией
    void EnergyShoot()
    {
        if (countEnergy > 0)
        {
            countEnergy--;
            GameObject bullet1 = Instantiate(energyPrefab, shootPoints[0].transform.position, transform.rotation);
            GameObject bullet2 = Instantiate(energyPrefab, shootPoints[1].transform.position, transform.rotation);
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb1.AddForce(shootPoints[0].transform.up * energyForce, ForceMode2D.Impulse);
            rb2.AddForce(shootPoints[1].transform.up * energyForce, ForceMode2D.Impulse);
            Destroy(bullet1, 3f);
            Destroy(bullet2, 3f);
            //GameObject flashF1 = Instantiate(flashFire, shootPoints[0].transform.position, transform.rotation);
            //GameObject flashF2 = Instantiate(flashFire, shootPoints[1].transform.position, transform.rotation);
            //Destroy(flashF1, 0.1f);
            //Destroy(flashF2, 0.1f);
        }


    }

    void ShootBomb()
    {
        if (Input.GetMouseButtonDown(1))
        //{
        //if (Mouse.current.rightButton.wasPressedThisFrame)
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

            //YandexGame.savesData.countBomb = countBomb;
            //YandexGame.SaveProgress();
        }
    }

    void ShootBombWave()
    {
        if (Time.time > nextSpawnTime)
        {
            if (Input.GetMouseButtonDown(0))
            //if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (countBombWave > 0)
                {
                    countBombWave--;
                    GameObject bombWave1 = Instantiate(bombWavePrefab, shootPoints[0].transform.position, transform.rotation);
                    GameObject bombWave2 = Instantiate(bombWavePrefab, shootPoints[1].transform.position, transform.rotation);
                    Rigidbody2D rb1 = bombWave1.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb2 = bombWave2.GetComponent<Rigidbody2D>();
                    rb1.AddForce(shootPoints[0].transform.up * 20, ForceMode2D.Impulse);
                    rb2.AddForce(shootPoints[1].transform.up * 20, ForceMode2D.Impulse);
                    AudioManager.instance.Play("PlayerFire");
                    //StartCoroutine(TimeExpBombWave(bombWave1));
                    //Destroy(bombWave1, 4f);
                }
            }
        }
    }

    /*IEnumerator TimeExpBombWave(GameObject bw1)
    {
        yield return new WaitForSeconds(4f);
        //Destroy(bw1);
        PS_expBombWave.transform.position = bw1.transform.position;
        PS_expBombWave.Play();

    }*/
}
