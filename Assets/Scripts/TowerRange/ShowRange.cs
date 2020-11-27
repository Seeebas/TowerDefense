using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRange : MonoBehaviour
{

    public GameObject RangeImage;
    public Transform rangeImagePos;
    private GameObject created;
    void OnMouseOver()
    {
        if (created == null)
        {
			whatTower();
            created = GameObject.Instantiate(RangeImage, rangeImagePos.position, Quaternion.Euler(90, 0, 0)) as GameObject;   
        }

    }
    void whatTower()
    {
        if (this.name == "Tower1(Clone)")
        {
            RangeImage.transform.localScale = new Vector3(0.17f, 0.17f, 0);
        }
        else if (this.name == "TowerMissil(Clone)")
        {
            RangeImage.transform.localScale = new Vector3(0.14f, 0.14f, 0);
        }
        else if(this.name=="TowerLaser(Clone)")
        {
            RangeImage.transform.localScale = new Vector3(0.11f, 0.11f, 0);
        }
    }
    void OnMouseExit()
    {
        Destroy(created.gameObject);
    }
}
