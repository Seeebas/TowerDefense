using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	no wave 1-6 sai sempre o enemy 1 
	do wave 7-9 sai enemy 1 e enemy 2 onde ira sempre haver mais enemys 1
	do wave 10-x vao sair os 3 enemys, mais enemys 1 do que os dois restantes e mais enemys 2 do que
	o enemy 3
 */
public class WaveSystem : MonoBehaviour
{

    private int waveNumber;
    private int enemyWaveTotal;
    private ArrayList listaWaveEnemys;

    public  WaveSystem()
    {
        listaWaveEnemys = new ArrayList();
    }

    /*Este metodo vai criar 100 Waves, onde em cada wave
	o total de enemys é de * 3 ou seja, 
	ex: wave 1 -sai i*3 ou seja 3 enemys
	ex:wave 2 -sai  i*3 ou seja 6 enemys
	 */
    public ArrayList getListaWaveEnemy()
    {
        for (int i = 0; i < 100; i++)
        {
            listaWaveEnemys.Add((i + 1) * 3);
        }
        return this.listaWaveEnemys;
    }
}
