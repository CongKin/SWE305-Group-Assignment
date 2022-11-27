using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int keys = 0;

    private void Start()
    {
        UIManager.Instance.UpdateKey(keys);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            
            Destroy(collision.gameObject);
            keys++;
            UIManager.Instance.UpdateKey(keys);
        }
    }

    public int getKeyCount()
    {
        return keys;
    }
}