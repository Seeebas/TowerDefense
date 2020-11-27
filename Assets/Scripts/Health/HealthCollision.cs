using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
    Esta class é para quando o Enemy bate na vida
 */
public class HealthCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        float value=1;
        if (col.gameObject.tag == "Life")
        {
            if (BulletFolow.enemyHealth!=null && BulletFolow.enemyHealth.fillAmount < 1)
            {
                value-= BulletFolow.enemyHealth.fillAmount;
                BulletFolow.enemyHealth.fillAmount+=value;
                Debug.Log("Enemy Bateu Na VIDA");
                Destroy(col.gameObject);
            }else{
                return;
            }

        }
    }
}
