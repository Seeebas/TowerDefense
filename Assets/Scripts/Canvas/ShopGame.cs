using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
    Esta Class é para o Canvas Show onde temos a loja com as torres e 
    bomba saber qual foi o objecto selecionado no OnClick do botao 
 */
public class ShopGame : MonoBehaviour
{

    public static int shopBuy { get; private set; }//vai de 0-3
    public static bool buyUsed { get; set; }//se ja usou a compra
    public static bool towerBuy { get; set; }//se comprou
    private Text messageText;
    private Animator anim;
    void Awake()
    {
        messageText = GameObject.Find("Message").GetComponent<Text>();
        anim = messageText.GetComponent<Animator>();
        buyUsed = false;
    }

    public ShopGame()
    {
    }

    public void buyTower1()
    {
        if (buyUsed)
        {//ja comprou mas nao o usou
            anim.SetInteger("textAnim", 0);
            StartCoroutine(Message.WaitAnim("Ainda nao usou a Torre"));
        }
        else
        {
            if (ShowTextGame.playerMoney >= ShowTextGame.tower1Money)
            {
                shopBuy = 0;
                towerBuy = true;
                buyUsed = true;
                ShowTextGame.playerMoney -= ShowTextGame.tower1Money;
                ShowTextGame.palyerMoneyText.text = ShowTextGame.playerMoney + "$";
            }
            else
            {
                anim.SetInteger("textAnim", 0);
                StartCoroutine(Message.WaitAnim("Não tem saldo suficiente"));
            }
        }
    }
    public void buyTower2()
    {
        if (buyUsed)
        {//ja comprou mas nao o usou
            anim.SetInteger("textAnim", 0);
            StartCoroutine(Message.WaitAnim("Ainda nao usou a Torre"));
        }
        else
        {
            if (ShowTextGame.playerMoney >= ShowTextGame.tower2Money)
            {
                shopBuy = 1;
                towerBuy = true;
                buyUsed = true;
                ShowTextGame.playerMoney -= ShowTextGame.tower2Money;
                ShowTextGame.palyerMoneyText.text = ShowTextGame.playerMoney + "$";
            }
            else
            {
                anim.SetInteger("textAnim", 0);
                StartCoroutine(Message.WaitAnim("Não tem saldo suficiente"));
             
            }
        }
    }
    public void buyTower3()
    {
        if (buyUsed)
        {//ja comprou mas nao o usou
            anim.SetInteger("textAnim", 0);
            StartCoroutine(Message.WaitAnim("Ainda nao usou a Torre"));
            
        }
        else
        {
            if (ShowTextGame.playerMoney >= ShowTextGame.tower3Money)
            {
                shopBuy = 2;
                towerBuy = true;
                buyUsed = true;
                ShowTextGame.playerMoney -= ShowTextGame.tower3Money;
                ShowTextGame.palyerMoneyText.text = ShowTextGame.playerMoney + "$";
            }
            else
            {
                anim.SetInteger("textAnim", 0);
                StartCoroutine(Message.WaitAnim("Não tem saldo suficiente"));
            
            }
        }

    }
    public void buyBomb()
    {
        if (buyUsed)
        {//ja comprou mas nao o usou
            anim.SetInteger("textAnim", 0);
            StartCoroutine(Message.WaitAnim("Ainda nao usou a Bomba"));
        
        }
        else
        {
            if (ShowTextGame.playerMoney >= ShowTextGame.bombMoney)
            {
                shopBuy = 3;
                towerBuy = true;
                buyUsed = true;
                ShowTextGame.playerMoney -= ShowTextGame.bombMoney;
                ShowTextGame.palyerMoneyText.text = ShowTextGame.playerMoney + "$";
            }
            else
            {
                anim.SetInteger("textAnim", 0);
                StartCoroutine(Message.WaitAnim("Não tem saldo suficiente"));
           
            }
        }
    }
}
