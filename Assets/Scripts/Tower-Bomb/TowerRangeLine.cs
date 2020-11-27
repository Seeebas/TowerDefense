using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerRangeLine : MonoBehaviour
{
    public float rangeTower;
    public Transform towerHeadRotation;
    [Header("Atributos Bulltet")]
    public Transform bulletStart;
    public GameObject bullet;
    Transform target;
    private GameObject enemyRef;
    [Header("Atributos Laser")]
    public LineRenderer laser;
    public bool laserON;

    private float fireRate = 1f;
    private float fireCount = 0;
    public static bool isDead { get; set; }

    private NavMeshAgent navMesh;

    void Start()
    {
        isDead = false;
        InvokeRepeating("enemyInRange", 0f, 0.5f);
    }

    void enemyInRange()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortesDistance = Mathf.Infinity;//para saber a menor destancia
        GameObject nearEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearEnemy = enemy;
            }
        }
        if (nearEnemy != null && shortesDistance <= rangeTower)
        {
            target = nearEnemy.transform;
            enemyRef = nearEnemy;
            navMesh = enemyRef.GetComponent<NavMeshAgent>();
        }
        else//ja nao esta no range
        {
            if (target != null)
            {
                navMesh = target.gameObject.GetComponent<NavMeshAgent>();
                if(target.gameObject.name=="Enemy1(Clone)"){
                    navMesh.speed = 6;
                }else if(target.gameObject.name=="Enemy2(Clone)"){
                    navMesh.speed = 4;
                }else{
                    navMesh.speed = 3f;
                }
            }
            target = null;
        }
    }
    void Update()
    {
        if (target == null)
        {
            if (laserON)
            {
                laser.enabled = false;
            }
            return;
        }
        // look to target
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotaion = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotaion.eulerAngles;
        towerHeadRotation.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        //
        if (laserON)
        {
            showLaser();
        }
        else
        {
            if (fireCount <= 0f)
            {
                bulletShoot();
                fireCount = 1f / fireRate;
            }
            fireCount -= Time.deltaTime;
        }

    }
    void bulletShoot()
    {
        GameObject _bullet = Instantiate(bullet, bulletStart.position, bulletStart.rotation) as GameObject;
        BulletFolow _bulletScrip = _bullet.GetComponent<BulletFolow>();
        _bulletScrip.targetLook(target);//recebe a referencia do enemy a qual a torre esta a seguir
        _bulletScrip.enemyRef(enemyRef);
    }
    void showLaser()
    {
        if (!laser.enabled)
        {
            laser.enabled = true;
        }
        navMesh.speed = 2;
        laser.SetPosition(0, bulletStart.position);
        laser.SetPosition(1, target.position);
    }

}
