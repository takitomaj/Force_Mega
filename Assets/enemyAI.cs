using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class enemyAI : MonoBehaviour
{
    public Transform target;

    public float Speed = 600f;
    public float nextWayPointDistance = 3f;

    Path path;
    int currentWayPoint=0;
    bool reachedEndOfpath = false;
    
    Seeker seeker;
    Rigidbody2D rb2d;

    Transform enemyTransform;

    public float RadioVision = 3f;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();
        enemyTransform = GetComponent<Transform>();
        InvokeRepeating("UpdatePath",0f,0.5f);
        
    }

    public void UpdatePath() 
    {
        if (seeker.IsDone())
        {
            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(rb2d.position, RadioVision);
            foreach (Collider2D colider in hitEnemys)
            {
                if (colider != null)
                {
                    if (colider.tag == "Player")
                    {

                        Transform objetivo = colider.gameObject.GetComponent<Transform>();
                        Vector2 vectortarget = new Vector2(objetivo.position.x, rb2d.position.y);

                        seeker.StartPath(rb2d.position, vectortarget, OnPathComplete);// target.position, OnPathComplete);
                    }
                }
            }
           
        }    
    }

    void OnPathComplete(Path p ) 
    {
        if (!p.error) 
        {
            path = p;
            currentWayPoint = 0;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) { return; }

        if (currentWayPoint>=path.vectorPath.Count) 
        {
            reachedEndOfpath = true;
            return;
        }
        else 
        { 
            reachedEndOfpath = false;
        }
        Vector2 direccion = ((Vector2)path.vectorPath[currentWayPoint] - rb2d.position).normalized;
        direccion.y = 0;
        Vector2 fuerza = direccion * Speed ;

        rb2d.AddForce(fuerza,ForceMode2D.Force);

        float distacia = Vector2.Distance(rb2d.position,path.vectorPath[currentWayPoint]);

        if(distacia < nextWayPointDistance) 
        {
            currentWayPoint++;
        }

        //dar vuelta
        if (fuerza.x>=0.01f) 
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
        else if(fuerza.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

    }

   /* private void OnDrawGizmosSelected()
    {
        if (rb2d == null)
            return;

        Gizmos.DrawWireSphere(rb2d.position, RadioVision);
    }*/
}
