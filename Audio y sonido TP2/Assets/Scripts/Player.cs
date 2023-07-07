using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    public Vector3 direction = new Vector3(0f, 0f, 1f);
    public float Speed = 6f;
    public float cameraAxisX = 0f;
    public float SpeedRotation = 200.0f, Sensitivity = 70f;
    public float x, y;

    Transform Cam;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cam = Camera.main.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float ymouse = Input.GetAxis("Mouse Y") * Time.deltaTime * Sensitivity;
    }

    private void FixedUpdate()
    {
        float MovementHorizontal = Input.GetAxis("Horizontal");
        float MovementVertical = Input.GetAxis("Vertical");
        Vector3 VectorMovement = new Vector3(MovementHorizontal, 0.0f, MovementVertical);
        rb.AddForce(VectorMovement * speed);
    }

    public void RotatePlayer()
    {
        float xmouse = Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity;
        float ymouse = Input.GetAxis("Mouse Y") * Time.deltaTime * Sensitivity;
        transform.Rotate(Vector3.up * xmouse);
        yRotation -= ymouse;
        yRotation = Mathf.Clamp(yRotation, -85f, 60f);
        Cam.localRotation = Quaternion.Euler(yRotation, 0, 0);
    }



}
