using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] bool isAlive = true;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up * 1000);
        }
    }

    private void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }

        rigidBody.AddForce(Vector3.right * 600 * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;

    }





}
