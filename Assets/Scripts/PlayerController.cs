using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 2f;
    [SerializeField] private float _gravity = -9.8f;

    private int _lineToMove = 1;
    private float _lineDistance = 3f;

    private CharacterController _controller;
    private Vector3 _direction;

    private void Start()
    {
        _controller= GetComponent<CharacterController>();
    }

    private void Update()
    {
        SwipeController.
        if (SwipeController.swipeRight && _lineToMove < 2)
            _lineToMove++;

        if (SwipeController.swipeLeft && _lineToMove > 0)
            _lineToMove--;

        if (SwipeController.swipeUp && _controller.isGrounded)
            Jump();

        Movement();
    }

    private void FixedUpdate()
    {
        _direction.z = _speed;
        _direction.y += _gravity * Time.fixedDeltaTime;
        _controller.Move(_direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        _direction.y = _jumpForce;
    }

    private void Movement()
    {
        Vector3 _targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(_lineToMove == 0)
            _targetPosition += Vector3.left * _lineDistance;

        else if (_lineToMove == 2)
            _targetPosition += Vector3.right * _lineDistance;

        transform.position = _targetPosition;
    }
}
