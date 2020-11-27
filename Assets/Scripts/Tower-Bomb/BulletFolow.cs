using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class BulletFolow : MonoBehaviour
{
    private Transform target;
    public float speed;
    public static Image enemyHealth { get; set; }
    private GameObject enemyObject;
    private GameObject imageObject;
    private Animator anim;
    private NavMeshAgent nav;
    private GameObject enemy;

    private bool isDead;

    void Awake()
    {
        isDead = false;
    }
    public void targetLook(Transform _target)
    {
        if (_target != null)
        {
            this.target = _target;
        }
        enemyObject = _target.transform.GetChild(2).gameObject;
        imageObject = enemyObject.transform.GetChild(0).GetChild(0).gameObject;
        enemyHealth = imageObject.GetComponent<Image>();
        anim = _target.GetComponent<Animator>();
        nav = _target.GetComponent<NavMeshAgent>();
    }
    /*Metodo para receber a referencia do enemy que esta focus no TowerRange */
    public void enemyRef(GameObject _enemy)
    {
        this.enemy = _enemy;
    }
    void Update()
    {
        if (this.target == null)
        {
            Destroy(this.gameObject);
        }
        if (!isDead && target!=null)
        {
            Vector3 dir = target.position - transform.position;
            float distance = speed * Time.deltaTime;
            transform.Translate(dir.normalized * distance, Space.World);
        }
    }

    private void hitEnemy()
    {
        if (enemyHealth.fillAmount <= 0)
        {
            //-------------------------------
            ShowTextGame.playerMoney += whatEnemy(enemy);//int do dinheiro
            ShowTextGame.palyerMoneyText.text = ShowTextGame.playerMoney + "$";//text do valor
            EnemyRespawn.listaEnemysSpawn.Remove(enemy.gameObject);
            //----
			EnemyRespawn.enemyTotalKill++;
			ShowTextGame.enemyKillText.text =""+ EnemyRespawn.enemyTotalKill;
            Destroy(enemy);
        }
    }
    private IEnumerator WaitToDestroyEnemy()
    {
        yield return new WaitForSeconds(0.04f);
        Destroy(enemy);
    }
    /**
        Metodo que retorna o um valor Money que o player vai ganhar
        consoante o enemy que morreu
     */
    int whatEnemy(GameObject obj)
    {
        int money = 0;
        Debug.Log(obj.gameObject.name);
        if (obj.gameObject.name == "Enemy1(Clone)")
        {
            money = 50;
        }
        if (obj.gameObject.name == "Enemy2(Clone)")
        {
            money = 70;
        }
        if (obj.gameObject.name == "Enemy3(Clone)")
        {
            money = 100;
        }
        return money;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            enemyHealth.fillAmount -= whatTower();
            hitEnemy();
            Destroy(this.gameObject);
        }
    }

    float whatTower()
    {
        float tower = 0f;
        if (this.tag == "Bullet")
        {
            tower = 0.04f;
        }
        if (this.tag == "Missil")
        {
            tower = 0.2f;
        }
        return tower;

    }
}
