using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolderTower : MonoBehaviour
{

    public Transform[] tower;//array das 3 torres
    public Transform pos;//pos onde a torre vai ficar
    private Renderer rend;//para poder mudar a cor do holder
    public Material matSelct, matDiselect;// os materials para a troca
    public static Transform towerSelected{ get;set;}//qual a torre selecionada
    private bool towerOn;
    private Text messageText;//variavel para mostrar message
    private Animator anim;//para fazer animacao do text

    void Awake()
    {
        messageText = GameObject.Find("Message").GetComponent<Text>();
        anim = messageText.GetComponent<Animator>();
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
        towerOn = false;
    }
    void OnMouseOver()
    {
        rend.sharedMaterial = matSelct;
        if (ShopGame.shopBuy > 2 && Input.GetMouseButtonDown(0))//esta a tentar por bomba no lugar das torres
        {//ja comprou mas nao o usou
            anim.SetInteger("textAnim", 0);
            StartCoroutine(Message.WaitAnim("Posição inválida"));
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {//se carrega rato
                if (ShopGame.towerBuy != false)
                {//se pode comprar
                    if (towerOn == false)//se ainda nao tem torre colocado
                    {
                        towerSelected = GameObject.Instantiate(tower[ShopGame.shopBuy], pos.position, pos.rotation) as Transform;
                        ShopGame.buyUsed = false;//ja usou o que comprou pode comprar mais
                        ShopGame.towerBuy = false;
                        towerOn = true;
                    }
                    else
                    {
                        anim.SetInteger("textAnim", 0);
                        StartCoroutine(Message.WaitAnim("Sem Espaço"));
                    }
                }
            }
        }
    }

    public void sellTower()
    {
        GameObject info = GameObject.Find("TowerInfoPanel(Clone)");
        //vamos agora add ao texto canvas o $ ganho da venda
        ShowTextGame.playerMoney += InfoTowerCanvas.sellValue;
        ShowTextGame.palyerMoneyText.text = ShowTextGame.playerMoney + "$";
        //vai dizer que nao tem nenhum tower colocado
        //vai apagar
        this.towerOn = false;
     
        Destroy(towerSelected.gameObject);
        Destroy(info.gameObject);
    }


    public void upgradeTower()
    {
        //InfoTowerCanvas.upgradeValueValue
    }
    void OnMouseExit()
    {
        rend.sharedMaterial = matDiselect;
    }

}
