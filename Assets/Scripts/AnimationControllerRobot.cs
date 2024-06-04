using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationControllerRobot : MonoBehaviour
{
    PlayerInputKeys _playerinput;
    CharacterController _charactercontroller;

    Animator _animator;

    Vector2 _currentMoveInput;
    Vector3 _currentMovement;
    Vector3 _currentrunMove;

    bool _isMovementPressed;
    bool _isRunPressed;
    float _runMultiplierMove = 8.0f;
    float _walkMultiplier = 3.0f; 
    int _isWalkingHash;
    int _isRunningHash;
    

    private void Awake()
    {
        _playerinput = new PlayerInputKeys();
        _charactercontroller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _isWalkingHash = Animator.StringToHash("isWalking");
        _isRunningHash = Animator.StringToHash("isRunning");

        _playerinput.RobotController.Move.started += onMovementInput;
        _playerinput.RobotController.Move.canceled += onMovementInput;
        _playerinput.RobotController.Move.performed += onMovementInput;
        _playerinput.RobotController.Run.started += onRun;
        _playerinput.RobotController.Run.canceled += onRun;
    }


    void Update()
    {
        HandleGravity();
        HandleMovement();
    }

    void OnEnable()
    {
        _playerinput.RobotController.Enable();
    }

    void OnDisable()
    {
        _playerinput.RobotController.Disable();
    }

    void onRun(InputAction.CallbackContext context)
    {
        _isRunPressed = context.ReadValueAsButton();
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        _currentMoveInput = context.ReadValue<Vector2>();
        _isMovementPressed = _currentMoveInput.x != 0 || _currentMoveInput.y != 0;

        if (context.control.name == "d")
        {
            // O'nga burilish
            transform.Rotate(0, 20, 0);
        }
        else if (context.control.name == "a")
        {
            // Chapga burilish
            transform.Rotate(0, -20, 0);
        }

        _currentMovement = transform.forward * _currentMoveInput.y * _walkMultiplier;
        _currentrunMove = transform.forward * _currentMoveInput.y * _runMultiplierMove;
    }

    void HandleGravity()
    {
        if (_charactercontroller.isGrounded)
        {
            float groundGravity = -0.5f;
            _currentMovement.y = groundGravity;
            _currentrunMove.y = groundGravity;
        }
        else
        {
            float gravity = -9.8f;
            _currentMovement.y += gravity * Time.deltaTime;
            _currentrunMove.y += gravity * Time.deltaTime;
        }
    }

    void HandleMovement()
    {
        bool isWalking = _animator.GetBool(_isWalkingHash);
        bool isRunning = _animator.GetBool(_isRunningHash);

        if (_isMovementPressed && !isWalking)
        {
            _animator.SetBool(_isWalkingHash, true);
        }
        else if (!_isMovementPressed && isWalking)
        {
            _animator.SetBool(_isWalkingHash, false);
        }

        if (_isMovementPressed && _isRunPressed && !isRunning)
        {
            _animator.SetBool(_isRunningHash, true);
        }
        else if ((!_isMovementPressed || !_isRunPressed) && isRunning)
        {
            _animator.SetBool(_isRunningHash, false);
        }

        Vector3 movement = _isRunPressed ? _currentrunMove : _currentMovement;
        _charactercontroller.Move(movement * Time.deltaTime);
    }

}
