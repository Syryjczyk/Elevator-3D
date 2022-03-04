using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [Header("PlayerRotateProperties")]
    [SerializeField] private Transform _cameraHolder;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationLimit;

    protected float verticalRotation;
    public virtual void Rotate() 
    {
        verticalRotation -= GetVerticalValue();
        verticalRotation = verticalRotation <= -_rotationLimit ? -_rotationLimit :
            verticalRotation >= _rotationLimit ? _rotationLimit :
            verticalRotation;
        RotateVertical();
        RotateHorizontal();
    }

    protected float GetVerticalValue() => Input.GetAxis("Mouse Y") * _speed * Time.deltaTime;
    protected float GetHorizontalValue() => Input.GetAxis("Mouse X") * _speed * Time.deltaTime;
    protected virtual void RotateVertical() => _cameraHolder.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    protected virtual void RotateHorizontal() => transform.Rotate(Vector3.up * GetHorizontalValue());
}
