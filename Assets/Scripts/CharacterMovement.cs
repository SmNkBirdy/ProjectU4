using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public Vector3 _horizontalSpeed = new Vector3(0,0,0);
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float drag = 2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Vector2 _inputAxis;
    private CharacterController controller;

    [Header("Gravity")]
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] public float _verticalSpeed = 0;

    [Header("GroundCheck")]
    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private float _groundRaycastLenght = 0.6f;
    public LayerMask _groundLayer;

    [Header("Dimensions")]
    private GameObject _gameManager;
    private Vector3 _dimensionForward;
    private Vector3 _dimensionRight;
    private bool _xDimensionAllowed;
    private bool _yDimensionAllowed;
    private bool _zDimensionAllowed;

    [Header("Mood")]
    private PlayerMood pm;
    private PlayerSight ps;

    private void Start()
    {
        Debug.Log((new Vector3(5646,1546,1534).normalized * 5).magnitude);
        controller = gameObject.GetComponent<CharacterController>();
        updateDimensions();
        ps = gameObject.GetComponent<PlayerSight>();
    }

    void Update()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _groundRaycastLenght, _groundLayer);
        moveCharacter();
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
    }

    public void updateDimensions()
    {
        _gameManager = GameObject.Find("GameManager");
        DimensionsManager _DM = _gameManager.GetComponent<DimensionsManager>();
        _dimensionForward = _DM.getForward();
        _dimensionRight = _DM.getRight();
        _xDimensionAllowed = _DM.xDimension;
        _yDimensionAllowed = _DM.yDimestion;
        _zDimensionAllowed = _DM.zDimestion;
    }

    private void moveCharacter()
    {
        //horizontal movement
        _inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 _direction = _dimensionForward * _inputAxis.y * (_zDimensionAllowed ? 1 : 0) + _dimensionRight * _inputAxis.x * (_xDimensionAllowed ? 1 : 0);
        /*
        if (_horizontalSpeed.magnitude <= speed)
        {
            if (_isGrounded)
            {
                _horizontalSpeed += _direction.normalized * acceleration * Time.deltaTime;
            }
            else
            {
                _horizontalSpeed += _direction.normalized * acceleration * Time.deltaTime / 5;
            }
        }
        else
        {
            _horizontalSpeed = _horizontalSpeed.normalized * speed;
        }
        
        controller.Move(_horizontalSpeed * Time.deltaTime);

        if (_horizontalSpeed.magnitude >= 0)
        {
            if (_horizontalSpeed.magnitude != 0)
            {
                if (_isGrounded)
                {
                    _horizontalSpeed += -_horizontalSpeed.normalized * drag * Time.deltaTime;
                }
                else
                {
                    _horizontalSpeed += -_horizontalSpeed.normalized * drag * Time.deltaTime / 5;
                }
            }
        }
        else
        {
            _horizontalSpeed = new Vector3(0,0,0);
        }
        */

        ps.lookAt(transform.position + _direction);
        controller.Move(_direction * speed * Time.deltaTime);

        //gravity
        if (!_isGrounded)
        {
            _verticalSpeed -= gravity * Time.deltaTime;
        }
        else
        {
            if (_verticalSpeed < 0) 
            {
                _verticalSpeed = 0;
            }
        }

        //vertical movement
        controller.Move(new Vector3(0, _verticalSpeed, 0) * Time.deltaTime * (_yDimensionAllowed ? 1 : 0));
    }

    private void jump()
    {
        if (_isGrounded)
        {
            _verticalSpeed += jumpForce;
        }
    }
    //debug raycast lenght
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundRaycastLenght);
    }
}
