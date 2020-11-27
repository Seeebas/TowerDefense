using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalRandomPOS : MonoBehaviour
{
    public GameObject portalOut;
    public GameObject portalIn;
    /*public pq vai ser preciso a pos para saber onde instanciar o enemy que entra no portal*/
    public static Vector3 portalPos { get; private set; }
    private float xOut;
    private float xIn;
     private Text messageText;//variavel para mostrar message
    private Animator anim;//para fazer animacao do text

    void Awake()
    {
        messageText = GameObject.Find("Message").GetComponent<Text>();
        anim = messageText.GetComponent<Animator>();
    }
    void Start()
    {
        
        //inicia após 60 segundo, e vai repetir de 60 em 60 segundos.
        InvokeRepeating("newPortalInOut", 50.0f, 50.0f);
        
    }
    private void newPortalInOut()
    {
        anim.SetInteger("textAnim", 0);
        StartCoroutine(Message.WaitAnim("Novo Portal"));
        //PortalIN
        xIn = Random.Range(-15, 14);
        portalPos = new Vector3(xIn, 0, 8f);
        Instantiate(portalIn, portalPos, Quaternion.identity);
        //PortalOut
        xOut = Random.Range(3, 14);
        portalPos = new Vector3(xOut, 0, -18.7f);
        Instantiate(portalOut, portalPos, Quaternion.identity);
    }
}
