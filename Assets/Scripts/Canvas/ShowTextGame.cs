using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Esta class serve para chamar sempre os Text enemRun kill wave etc do canvas  */
public class ShowTextGame : MonoBehaviour
{
	public static Text enemyRunText{ get; set; }
	public static Text enemyKillText{ get; set; }
	public static  Text waveNumberText{ get; set; }
	public static  Text waveEnemysTotalText{ get; set; }
	public static  Text palyerMoneyText{ get; set; }
	public static  Text messageText{ get; set; }
	//var 
	public static int playerMoney{ get; set;}
	public static int tower1Money{ get;private set;}
	public static int tower2Money{ get;private set;}
	public static int tower3Money{ get;private set;}
	public static int bombMoney{ get;private set;}
	void Awake ()
	{
		//TEXT
		playerMoney=800;
		tower1Money = 100;
		tower2Money = 200;
		tower3Money = 350;
		bombMoney = 400;
		palyerMoneyText = GameObject.Find ("MoneyText").GetComponent<Text> ();
		enemyRunText = GameObject.Find ("EnemyRunText").GetComponent<Text> ();
		enemyKillText=GameObject.Find ("EnemyKillText").GetComponent<Text> ();
		waveNumberText = GameObject.Find ("WaveTextNumber").GetComponent<Text> ();
		waveEnemysTotalText = GameObject.Find ("WaveEnemyTotal").GetComponent<Text> ();
		messageText = GameObject.Find ("Message").GetComponent<Text>();
	}
}

