using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    public PlayerMovement player;

    [SerializeField] bool manualElevatorStering;
    private int number;

    //  References
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        // Alternative way to steer the elevator
        ElevatorMovingSwitch();
        if (manualElevatorStering)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                CallToFloor(1);
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                CallToFloor(2);
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                CallToFloor(3);
            }
        }
        // Default way to steer the elevator
        else
        {
            CallToFloor(number);
        }
    }

    private void ElevatorMovingSwitch()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !manualElevatorStering)
        {
            manualElevatorStering = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && manualElevatorStering)
        {
            manualElevatorStering = false;
        }
    }
    public void ChangeNumberTo1()
    {
        number = 1;
    }
    public void ChangeNumberTo2()
    {
        number = 2;
    }
    public void ChangeNumberTo3()
    {
        number = 3;
    }


    public void CallToFloor(int number)
    {
        animator.SetInteger("Number", number);
    }
}
