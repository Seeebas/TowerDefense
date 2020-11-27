using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
    Esta class mete o health bar do enemy static
 */
public class HealthBar : MonoBehaviour
{
    void Update()
    {
        var rotation = Quaternion.LookRotation(Vector3.up, Vector3.forward);
        transform.rotation = rotation;
    }
}
