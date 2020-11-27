using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Classe usada para venda de um Torre */
public class InfoTowerCanvas : MonoBehaviour
{
    public GameObject canvasInfoTower;
    private bool isON;
    private GameObject canvasInfoTowerRefece;
    private Text sellText;
    private Text upgradeText;
    private GameObject canvasGO;
    private GameObject buttonPanelGO;
    private GameObject upgradeGO;
    private GameObject sellGO;

    //valores para venda e upgrade das torres
    public static int sellValue { get; set; }
    public static int upgradeValue { get; set; }
    void Awake()
    {
        isON = false;
    }
    void OnMouseOver()
    {
        if (isON)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                isON = true;
                //vai buscar o Text sell e Text upgrade
                canvasGO = canvasInfoTower.transform.GetChild(0).gameObject;
                buttonPanelGO = canvasGO.transform.GetChild(0).gameObject;
                upgradeGO = buttonPanelGO.transform.GetChild(0).gameObject;//Upgrade
                upgradeText = upgradeGO.transform.GetChild(1).gameObject.GetComponent<Text>();//Upgrade
                sellGO = buttonPanelGO.transform.GetChild(1).gameObject;//Sell
                sellText = sellGO.transform.GetChild(1).gameObject.GetComponent<Text>();//Sell
                //
                whatTower();
                sellText.text = sellValue + "$";
                upgradeText.text = upgradeValue + "$";
                canvasInfoTowerRefece = Instantiate(canvasInfoTower, this.transform.position, Quaternion.identity);
            }
        }
    }

    /**
		Metodo que vai ver qual a torre add, e faz update ao textValues
	 */
    void whatTower()
    {
        if (this.gameObject.name == "Tower1(Clone)")
        {
            sellValue = 50;
            upgradeValue = 550;
            HolderTower.towerSelected = this.gameObject.transform;
        }
        if (this.gameObject.name == "TowerMissil(Clone)")
        {
            sellValue = 75;
            upgradeValue = 850;
            HolderTower.towerSelected = this.gameObject.transform;
        }
        if (this.gameObject.name == "TowerLaser(Clone)")
        {
            sellValue = 125;
            upgradeValue = 1100;
            HolderTower.towerSelected = this.gameObject.transform;
        }
    }
    void sellTower()
    {
        Destroy(this.gameObject);         
    }
    void upgradeTower()
    {

    }
    private IEnumerator wait2Seconds()
    {
        yield return new WaitForSeconds(2f);
        Destroy(canvasInfoTowerRefece);
        isON = false;
    }
    void OnMouseExit()
    {
        StartCoroutine(wait2Seconds());
    }
}
