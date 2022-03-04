using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;

    private const float GRAVITY = -9.81f;
    private bool _isGrounded;

    private CharacterController _player;
    private Vector3 _moveDirection;
    private Vector3 _velocity;

    private void Awake() => _player = GetComponent<CharacterController>();

    public void Move() 
    {
        _moveDirection = ((transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"))) * _speed; ;

        _player.Move(_moveDirection * Time.deltaTime);
    }

    public void Gravity()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        _velocity.y += GRAVITY * 5 * Time.deltaTime;
        _player.Move(_velocity * Time.deltaTime);
    }
}
