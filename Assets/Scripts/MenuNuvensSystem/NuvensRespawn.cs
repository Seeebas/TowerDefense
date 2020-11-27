using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Classe para fazer instance as nuvens, no menu do jogos */
public class NuvensRespawn : MonoBehaviour {

	public static float speed{ get; set; }
	public List<GameObject> listNuvens;
	void Start () {
		InvokeRepeating("instanciateNuvem",0f,25f);
	}
	// Update is called once per frame
	void Update () {
		
	}
	private void instanciateNuvem(){
		Instantiate(listNuvens[whichNuvem()].gameObject,new Vector3(-295,getPosYNuvem(),0),Quaternion.identity);
	}
	private int whichNuvem(){
		speed=whichSpeed();
		return Random.Range(0,6);
	}
	private float whichSpeed(){
		return Random.Range(1.5f,3.5f);
	}
    /*Metodo que vai retornar a pos Y , dependedo da nuvem */
    private float getPosYNuvem()
    {
        float y = Random.Range(90f, 132.0f);
        return y;
    }
}
