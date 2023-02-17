using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTriggers : MonoBehaviour
{
    [SerializeField]
    public bool IsRanged;


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger enter");
        if (other.gameObject.tag == "Enemy" && other.transform.root.GetComponent<EnemyAI>() != null)
        {
            //Debug.Log("enemy trigger");
            if ((IsRanged == true) && (other.transform.root.GetComponent<EnemyAI>().IsRangedAttack == true))
            {
                //Debug.Log("isranged enter");
                other.transform.root.GetComponent<EnemyAI>().AttackStart();
            }
            if ((IsRanged == false) && (other.transform.root.GetComponent<EnemyAI>().IsRangedAttack == false))
            {
                other.transform.root.GetComponent<EnemyAI>().AttackStart();
            }
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<EnemyAI>().IsRangedAttack == false)
            {
                other.gameObject.GetComponent<EnemyAI>().AttackStop();
            }
        }
    }*/
}
