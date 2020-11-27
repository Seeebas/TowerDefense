using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyRespawn : MonoBehaviour
{
    public static List<GameObject> listaEnemysSpawn { get; set; }
    public List<GameObject> listEnemysToSawn;
    private GameObject enemy;
    //
    private ArrayList listWave;
    //nr atual de wave
    private int indexListWave;
    //scripts
    private WaveSystem waveSysScript;
    private bool nextWave;
    public static int enemyTotalRun { get; set; }
    public static int enemyTotalKill { get; set; }
    public static int waveNumberAtual { get; set; }
    private int totalEnemySpawn;
    private Text messageText;
    private Animator anim;
    void Awake()
    {
        messageText = GameObject.Find("Message").GetComponent<Text>();
        anim = messageText.GetComponent<Animator>();
        //
        listaEnemysSpawn = new List<GameObject>();
        //--ter Acesso ao Script 
        waveSysScript = new WaveSystem();
        //--
        listWave = waveSysScript.getListaWaveEnemy();
        ShowTextGame.palyerMoneyText.text = ShowTextGame.playerMoney + " $";
        enemyTotalRun = 0;
        enemyTotalKill = 0;
        indexListWave = 0;
        nextWave = false;
        totalEnemySpawn = 0;
        waveNumberAtual = 1;
    }

    void Start()
    {
        ShowTextGame.waveEnemysTotalText.text = "" + totalEnemySpawn + "/" + listWave[indexListWave];//text do 0/20 enemy 
        ShowTextGame.waveNumberText.text = "" + waveNumberAtual;
        InvokeRepeating("enemyStart", 1.0f, 3.0f);
    }

    void endWave()
    {
        indexListWave++;
        totalEnemySpawn = 0;
        newWave(indexListWave, totalEnemySpawn);
    }
    /*
        Metodo que vai incializar um novo enemy
    */
    void enemyStart()
    {
        int whatEnemy = addNewEnemy(indexListWave);
        if (totalEnemySpawn < (int)listWave[indexListWave])
        {
            totalEnemySpawn++;
            ShowTextGame.waveEnemysTotalText.text = "" + totalEnemySpawn + " / " + listWave[indexListWave];
            enemy = Instantiate(listEnemysToSawn[whatEnemy], transform.position, transform.rotation) as GameObject;
            listaEnemysSpawn.Add(enemy);
        }
        if (listaEnemysSpawn.Count == 0)
        {
            endWave();
        }
    }

    void newWave(int indexList, int waveN)
    {
        ShowTextGame.waveEnemysTotalText.text = "" + 0 + "/" + listWave[indexList];//text do 0/20 enemy 
        ShowTextGame.waveNumberText.text = "" + (indexList + 1);
        anim.SetInteger("textAnim", 0);
        StartCoroutine(Message.WaitAnim("WAVE: " + (indexList + 1)));
        InvokeRepeating("enemyStart", 3.0f, 6.0f);
    }
    /*
        Este metodo serve para fazer random do respawn dos enemis
        isto é, se a wave for menor que 3 sai sempre 
        o enemy 1 ou seja pos 0, se wave for >3 e < 6 sai enemy 1 e 2 ou seja 
        pos 0 e pos 1 ultimo caso maior 1 6 sai os 3 pos 0,1 e 2
     */
    int addNewEnemy(int indexWave)
    {
        int total = 0;
        // total = Random.Range(0, 3);
        if (indexWave <= 3)
        {
            total = 0;
        }
        if (indexWave > 3 && indexWave <= 6)
        {
            total = Random.Range(0, 2);
        }
        if (indexWave >= 6)
        {
            total = Random.Range(0, 3);
        }

        return total;
    }
}
