using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Classe que apaga o portal */
public class Portal : MonoBehaviour {
	private GameObject enemy;
	private GameObject portalOUTObjec;
	private GameObject newEnemy;

	void Start () {
		portalOUTObjec=GameObject.FindGameObjectWithTag("PortalOUT");
	}
	
    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag=="Enemy")
        {
			enemy = GameObject.FindGameObjectWithTag("Enemy");
			newEnemy = enemy;
			Destroy (this.gameObject);
			enemy=Instantiate (newEnemy, PortalRandomPOS.portalPos,Quaternion.identity) as GameObject;
			EnemyRespawn.listaEnemysSpawn.Add (enemy);
			Destroy (portalOUTObjec.gameObject);
        }
    }

}
