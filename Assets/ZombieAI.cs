using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float ZomSpeed;
    private Transform currentPatrolPoint;
    private int currentPatrolIndex;
    private bool goingRight;
    // Start is called before the first frame update
    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
        goingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * ZomSpeed);
        if (Vector3.Distance(transform.position, patrolPoints[1].position) < .5f)
        {
            
            transform.localRotation = new Quaternion(0f, 180f, 0f,0f );
        }
        if (Vector3.Distance(transform.position, patrolPoints[0].position) < .5f)
        {
            transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        
       
        //Reached point check
        
        if (goingRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * ZomSpeed);
        }
        

    }
}
