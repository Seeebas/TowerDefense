using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthRanomPOS : MonoBehaviour
{

    public GameObject health;
    private float xOut;
    private Vector3 healthPosInit;
    private float posX;
    private int whatPoss;    private Text messageText;//variavel para mostrar message
    private Animator anim;//para fazer animacao do text

    void Awake()
    {
        messageText = GameObject.Find("Message").GetComponent<Text>();
        anim = messageText.GetComponent<Animator>();
    }

    void Start()
    {
        InvokeRepeating("randomPos",  30.0f, 30.0f); 
    }
    /*
        Metodo que vai gerar um numero de 1 a 4, para saber em qual caminho vai ser
        instanciado um objecto VIDA
     */
    int whatPos()
    {
        return whatPoss = Random.Range(1, 4);
    }
    /* Metodo que vai iniciar uma vida consoate whatPos*/
    void randomPos()
    {
        anim.SetInteger("textAnim", 0);
        StartCoroutine(Message.WaitAnim("Nova Vida"));
        int ini = whatPos();
        switch (ini)
        {
            case 1:
                getRandomPos(-13f, 13f, 17.42f);
                break;
            case 2:
                getRandomPos(-13f, 13f, 8f);
                break;
            case 3:
                getRandomPos(-13.55f, -2f, -5.4f);
                break;
            case 4:
                getRandomPos(2.87f, 13.46f, -18.9f);
                break;
        }
    }
    /*
        Este metodo vai gerar possicoes random consoante o local 1,2,3 ou 4
     */
    void getRandomPos(float xMin, float xMax, float z)
    {
        posX = Random.Range(xMin, xMax);
        healthPosInit = new Vector3(posX, 2f, z);
        transform.position = healthPosInit;
        Instantiate(health, transform.position, Quaternion.identity);
        healthPosInit = new Vector3(0, 0, 0);
        transform.position = healthPosInit;
    }
}
