using UnityEngine;

public class movement : MonoBehaviour
{

    public CharacterController controller;
    public float jumpheight = 3f;
    public float speed = 12f;
    public float gravity = -9.8f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundmask;
    bool Isgrounded;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.height = 1f;
        }
        else
        {
            controller.height = 2f;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Isgrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

        if (Isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q) && Isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;


        controller.Move(velocity * Time.deltaTime);

    }
}
