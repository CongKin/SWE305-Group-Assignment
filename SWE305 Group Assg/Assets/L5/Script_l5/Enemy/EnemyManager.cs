using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemiesLeftText;
    //List<Enemy> enemies = new List<Enemy>();
    public static EnemyManager inst;
    Dictionary<int,EnemyController> Enemies;

    private void Awake()
    {
        //enemies = GameObject.FindObjectOfType<Enemy>().ToList();
        inst = this;
        Enemies = new Dictionary<int, EnemyController>();
        
    }

    void Update()
    {
        UpdateEnemiesLeftText();
    }

    void HandleEnemyDefeated(Enemy enemy)
    {

    }

    void UpdateEnemiesLeftText()
    {
        enemiesLeftText.text = $"Enemies left: {(inst.Enemies.Count)}";
        Debug.Log("Enemy count updated");
    }

    public static void Register(int id, EnemyController enemy) {
        if (inst.Enemies.ContainsKey(id)) {
            Debug.Log("Duplicate registration attempted... " + id.ToString());
            return;
        }
 
        inst.Enemies.Add(id, enemy);
        Debug.Log(inst.Enemies.Count);
    }
}
