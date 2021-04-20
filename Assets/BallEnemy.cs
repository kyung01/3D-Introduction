using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      

        
    }
    private void FixedUpdate()
    {
        Vector3 dir = PlayerController.Instance.transform.position - rb.transform.position;
        dir.Normalize();
        rb.AddForce(dir * speed * Time.fixedDeltaTime);


    }
}
