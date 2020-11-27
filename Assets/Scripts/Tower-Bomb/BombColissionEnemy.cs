using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombColissionEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            EnemyRespawn.listaEnemysSpawn.Remove(col.gameObject);//remov enemy da lista
             Destroy(this.gameObject);
        }
    }
}
