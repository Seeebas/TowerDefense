using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Classe que movimenta as nuvens  no menu do jogo */
public class NuvensMove : MonoBehaviour
{
    private Vector3 userDirection = Vector3.right;

    public void Update()
    {
        moveNuvem();
    }

    private void moveNuvem()
    {
        //NuvensRespawn.speed
        transform.Translate(userDirection * 2.5f * Time.deltaTime);
    }
}
