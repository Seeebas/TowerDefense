using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
/**
	Esta class é para quando o enemy toca no CrystalEnd ou seja
	consegui sair do mapa 
 */
public class EnemyController : MonoBehaviour {
	private NavMeshAgent navAgente;
	public Transform endLine;
	private GameObject enemyDestroy;
	void Awake(){
		navAgente = GetComponent<NavMeshAgent> ();
	} 
	void Update () {
		navAgente.destination = endLine.position;
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag=="CrystalEnd") {
			Debug.Log("Toca Crystal");
			navAgente.isStopped=true;
			EnemyRespawn.enemyTotalRun++;
			ShowTextGame.enemyRunText.text =""+ EnemyRespawn.enemyTotalRun;
			Destroy (this.gameObject);
			EnemyRespawn.listaEnemysSpawn.Remove (this.gameObject);
		}
	}
}
