using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] GameObject head;

    [SerializeField] float jumpForce = 500;
    [SerializeField] float speed;
    [SerializeField] float speedRunning;
    [SerializeField] float smoothTime; //움직임을 부드럽게 만들어줄 변수다

    [SerializeField] float repellingForce;


    Vector3 smoothMoveVel = new Vector3(); //우리가 부드럽게 움직이는 속도에요
    


    [SerializeField] float mouseSensitivity = 0.1f;

    Rigidbody rigidBody;
    Vector3 moveAmount;
    float verticalLookRot = 0;

    float rotationX = 0;
    float rotationY = 0;

    public bool isGrounded = false;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void hello(int n)
    {

    }
    void Move()
    {
        bool cham = true;
        if (cham)
            hello(1);
        else hello(0);

        hello(cham ? 1 : 0);

        Vector3 moveDir = 
            new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, 
            moveDir * (
            Input.GetKey(KeyCode.LeftShift) ? speedRunning : speed
            ), ref smoothMoveVel, smoothTime);   
    }
    void Jump()
    {
        if (!isGrounded) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigidBody.AddForce(Vector3.up* jumpForce);
            isGrounded = false;
            //
        }
    }
    void Rotate()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);
        verticalLookRot += Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalLookRot = Mathf.Clamp(verticalLookRot, -90, 90);
        head.transform.localEulerAngles = new Vector3(-1 * verticalLookRot, 0, 0);
        //transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Jump();
        Rotate();
        attack();
    }

    void attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Physics.Raycast(this.head.transform.position, this.head.transform.forward, out hitInfo);
            if (hitInfo.collider == null) return;
            var otherRigidbody = hitInfo.collider.GetComponent<Rigidbody>();
            if(otherRigidbody== null)
            {
                return;
            }
            otherRigidbody.AddForce((otherRigidbody.transform.position - this.transform.position).normalized * repellingForce);
        }
       

    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

}
