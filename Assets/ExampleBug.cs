using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleBug : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.right * Time.deltaTime * 300;
        rigidBody.AddForce(Vector2.right * 500 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.P))
        {
            rigidBody.AddForce(Vector2.left * 5000);

        }
    }
}
