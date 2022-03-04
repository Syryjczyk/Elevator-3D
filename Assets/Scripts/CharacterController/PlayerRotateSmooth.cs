using UnityEngine;

public class PlayerRotateSmooth : PlayerRotate
{
    [Header("PlayerRotateSmoothProperties")]
    [SerializeField] private float _smoothTime;
    [SerializeField] private Transform _horizontalRotationHelper;

    private float _vertivalOld;
    private float _verticalAngularVelocity;
    private float _horizontalAngularVelocity;

    private void Start() => _horizontalRotationHelper.localRotation = transform.localRotation;


    public override void Rotate()
    {
        _vertivalOld = verticalRotation;
        base.Rotate();
    }

    protected override void RotateHorizontal()
    {
        _horizontalRotationHelper.Rotate(Vector3.up * GetHorizontalValue(), Space.Self);
        transform.localRotation =
            Quaternion.Euler(
                0f,
                Mathf.SmoothDampAngle(transform.localEulerAngles.y,
                                      _horizontalRotationHelper.localEulerAngles.y,
                                      ref _horizontalAngularVelocity,
                                      _smoothTime),
                0f);
    }
    protected override void RotateVertical()
    {
        verticalRotation = Mathf.SmoothDampAngle(_vertivalOld, verticalRotation, ref _verticalAngularVelocity, _smoothTime);
        base.RotateVertical();
    }
}
