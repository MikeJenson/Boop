using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject target; //the enemy's target
    public float moveSpeed = 10; //move speed
    public float rotationSpeed = 5; //speed of turning
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //rotate to look at the player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);
        //move towards the player
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
}