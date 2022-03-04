using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerMove), typeof(PlayerRotate))]
public class Player : MonoBehaviour
{
    [SerializeField] Camera _camera;
    public ElevatorMove _elevator;

    private PlayerMove _move;
    private PlayerRotate _rotate;
    private PlayerRotate _rotateSmooth;
    private PlayerRotate _currentRotate;

    private void Awake()
    {
        _move = GetComponent<PlayerMove>();
        _rotate = GetComponents<PlayerRotate>()[0];
        _rotateSmooth = GetComponents<PlayerRotate>()[1];
        _currentRotate = _rotateSmooth;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _move.Move();
        _move.Gravity();
        _currentRotate.Rotate();
        HitTheButtons();
       
    }
    private void HitTheButtons()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.GetComponent<FirstFloor>())
                {
                    _elevator.SendMessage("ChangeNumberTo1", SendMessageOptions.DontRequireReceiver);
                }
                else if (hit.collider.gameObject.GetComponent<SecondFloor>())
                {
                    _elevator.SendMessage("ChangeNumberTo2", SendMessageOptions.DontRequireReceiver);
                }
                else if (hit.collider.gameObject.GetComponent<ThirdFloor>())
                {
                    _elevator.SendMessage("ChangeNumberTo3", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
