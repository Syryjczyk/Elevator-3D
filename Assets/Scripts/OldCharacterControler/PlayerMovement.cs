using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float GRAVITY = -9.81f;

    [Header("Variables")]
    [SerializeField] float speed = 5f;
    [SerializeField] float groundDistance = 0.4f;

    [Header("References")]
    public ElevatorMove elevator;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Camera camera;

    private bool isGrounded;

    private Vector3 direction;
    private Vector3 velocity;

    private void Update()
    {
        // Reset velocity.y each time Player hits the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Set moving axis
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");

        // moving exeute
        direction = transform.right * xAxis + transform.forward * zAxis;
        controller.Move(direction * speed * Time.deltaTime);

        // gravity
        velocity.y += GRAVITY * 5 * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Elevator Buttons 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.GetComponent<FirstFloor>())
                {
                    elevator.SendMessage("ChangeNumberTo1", SendMessageOptions.DontRequireReceiver);
                }
                else if (hit.collider.gameObject.GetComponent<SecondFloor>())
                {
                    elevator.SendMessage("ChangeNumberTo2", SendMessageOptions.DontRequireReceiver);
                }
                else if (hit.collider.gameObject.GetComponent<ThirdFloor>())
                {
                    elevator.SendMessage("ChangeNumberTo3", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        Quit();
    }

    private void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
