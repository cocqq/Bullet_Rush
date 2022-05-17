using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController1 : MonoBehaviour
{
    public GameObject Enemy;
    public int zPos;
    public int xPos;
    public int enemyCount;
    public void Start() 
    {
        EnemyDrop();
    }
    public void EnemyDrop()
    {
        while(enemyCount < 30)
        {
            xPos = Random.Range(-1,1);
            zPos = Random.Range(1,25);
            Instantiate(Enemy, new Vector3(xPos,0.5f, zPos), Quaternion.identity);
            enemyCount += 1;
        }
    }
}
