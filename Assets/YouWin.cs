using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    public GameObject Enemy;
    public Vector2 EnemyLocation;
    private Transform Player;
    private Transform Camera;
    // Start is called before the first frame update
    public YouWin()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    void Start()
    {

    }
    public void Level()
    {
        Camera.position = new Vector3(0f, 13.5f, -10f);
        Player.position = new Vector3(-3.5f, 11.5f, 0f);
        Instantiate(Enemy, EnemyLocation, Quaternion.identity);
    }
   
}
