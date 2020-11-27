using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBomb : MonoBehaviour
{

    private Ray mousePos;
    public GameObject bomb;
    private Transform towerSelected;
    public Transform[] tower;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit result;
            if (Physics.Raycast(mousePos, out result))
            {
                if (ShopGame.towerBuy != false)
                {
                    if (ShopGame.shopBuy == 3)
                    {
                        towerSelected = tower[ShopGame.shopBuy * 0];
                        Instantiate(bomb, result.point, Quaternion.identity);
                        ShopGame.buyUsed = false;
                        ShopGame.towerBuy = false;
                        EnemyRespawn.enemyTotalKill++;
                        ShowTextGame.enemyKillText.text = "" + EnemyRespawn.enemyTotalKill;
                    }
                }
            }
        }
    }
}
