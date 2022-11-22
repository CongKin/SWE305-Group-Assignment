using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void Start () {
        EnemyManager.Register(gameObject.GetInstanceID(), this);
        Debug.Log("Enemy registered");
    }
}
