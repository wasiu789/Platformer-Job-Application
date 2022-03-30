using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minDistance;

    private Animator anim;
    private void Awake()
    {
        anim = anim.GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (Vector2.Distance(transform.position, target.position) > minDistance)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            

        }
    }
}
