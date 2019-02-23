using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    
    public float speed;
    private Transform Zombie;
    private Vector2 target;
    private GameObject play;
    private static int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
       // shootDirection = shootDirection - transform.position;
        if (GameObject.FindGameObjectWithTag("Zombie") != null)
        {
            Zombie = GameObject.FindGameObjectWithTag("Zombie").transform;
        }
        target = shootDirection;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            Destroy(GameObject.FindGameObjectWithTag("ZombieHeart"));
            DestroyProjectile();
        }
        if (other.CompareTag("Grass"))
        {
            DestroyProjectile();
        }
        
    }
}
