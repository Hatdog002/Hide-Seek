using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour
{
    public bool[] bases;
    
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Triggered by Player");
        if (other.gameObject.CompareTag("Player"))
        {
            if (bases[0])
            {
                if(GameManager.instance.timer <= 0)
                {
                    GameManager.instance.Base1Count++;
                }
               
            }

            if (bases[1])
            {
                if (GameManager.instance.timer <= 0)
                {
                    GameManager.instance.Base2Count++;
                }
            }

            if (bases[2])
            {
                if (GameManager.instance.timer <= 0)
                {
                    GameManager.instance.Base3Count++;
                }
            }
        }
    }
}
