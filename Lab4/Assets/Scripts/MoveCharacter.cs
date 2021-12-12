using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private bool groundedPlayer;
    private float speed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && velocity.y < 0)
        {
            velocity.y = 0f;
        }


        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * speed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Combo") && controller.isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * 3 * -3.0f * gravityValue);
        }
    }
}
