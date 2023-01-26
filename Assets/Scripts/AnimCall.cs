using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCall : MonoBehaviour
{
    [SerializeField]
    public GameObject CallObj;

    public void CallFunctionFromOther()
    {
        CallObj.GetComponent<EnemyAI>().Attack();
    }

}
