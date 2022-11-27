using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int keys = 0;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        UIManager.Instance.UpdateKey(keys);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            collectionSoundEffect.Play();
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