using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemiesLeftText;
    //Enemy enemy;
    //List<Enemy> enemies = new List<Enemy>();
    public static EnemyManager inst;
    Dictionary<int,EnemyController> enemies;
    private bool myFunctionCalled = false;

    /*private void OnEnable()
    {
        Enemy.OnEnemyKilled += HandleEnemyDefeated;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyKilled -= HandleEnemyDefeated;
    }*/

    private void Awake()
    {
        //List <Enemy> enemiesObjects = GameObject.FindObjectOfType<Enemy>();
        //enemies = enemiesObjects.Where(enemy => enemy.gameObject).ToList();

        //enemies = GameObject.FindObjectOfType<Enemy>().ToList();

        //Enemy enemiesObjects = FindObjectOfType<Enemy>();
        /*foreach(Enemy e in enemiesObjects){
            enemies.Add(e.gameObject0);
        }*/

        //enemies.AddRange(GameObject.FindObjectOfType<Enemy>());
        //enemies = FindObjectOfType<Enemy>().Select(enemy => enemy.gameObject).ToList();

        inst = this;
        enemies = new Dictionary<int, EnemyController>();
        //UpdateEnemiesLeftText();
    }

    void Update()
    {
        if(myFunctionCalled == false)
        {
            myFunctionCalled = true;
            Debug.Log("Update");
            UpdateEnemiesLeftText();
        }
        
    }

    public static void HandleEnemyDefeated(int id, EnemyController enemy)
    {
        /*if (enemies.Remove(enemy))
        {
            UpdateEnemiesLeftText();
        }*/
        inst.enemies.Remove(id, out enemy);
        Debug.Log("Enemy Defeated Successfully" + inst.enemies.Count);
        inst.UpdateEnemiesLeftText();
    }

    void UpdateEnemiesLeftText()
    {
        enemiesLeftText.text = $"Enemies left: {(inst.enemies.Count)}";
        Debug.Log("Enemy count updated");
    }

    public static void Register(int id, EnemyController enemy) {
        if (inst.enemies.ContainsKey(id)) {
            Debug.Log("Duplicate registration attempted... " + id.ToString());
            return;
        }
 
        inst.enemies.Add(id, enemy);
        Debug.Log(inst.enemies.Count);
    }

    public static int getEnemyCount ()
    {
        int c =0;
        if (inst.enemies.Count>0)
        {
            c = inst.enemies.Count;
        }
        
        return c;
    }
}
