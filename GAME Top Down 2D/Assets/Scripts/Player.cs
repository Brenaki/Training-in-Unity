using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rollSpeed;

    private Rigidbody2D rig;
    private PlayerItens playerItens;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;
    private Vector2 _direction;
    private int handlingObj;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool IsCutting 
    {
        get => _isCutting; 
        set => _isCutting = value; 
    }
    public bool IsDigging 
    {
        get => _isDigging; 
        set => _isDigging = value; 
    }
    public bool isWatering
    {
        get => _isWatering;
        set => _isWatering = value;
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItens = GetComponent<PlayerItens>();
        initialSpeed = speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            handlingObj = 1;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            handlingObj = 2;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            handlingObj = 3;

        }


        OnInput();
        OnRun();
        OnRoll();
        OnCut();
        OnDig();
        OnWatering();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRoll()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = rollSpeed;
            _isRolling = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = initialSpeed;
            _isRolling = false;

        }
    }

    void OnCut()
    {

        if (handlingObj == 1)
        {

            if (Input.GetMouseButtonDown(0))
            {
                speed = 0f;
                IsCutting = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                speed = initialSpeed;
                IsCutting = false;
            }

        }

    }

    void OnDig()
    {

        if(handlingObj == 2)
        {

            if (Input.GetMouseButtonDown(0))
            {
                speed = 0f;
                IsDigging = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                speed = initialSpeed;
                IsDigging = false;
            }

        }

    }

    void OnWatering()
    {

        if (handlingObj == 3)
        {

            if (Input.GetMouseButtonDown(0) && playerItens.CurrentWater > 0)
            {
                speed = 0f;
                isWatering = true;
            }
            if (Input.GetMouseButtonUp(0) || playerItens.CurrentWater < 0)
            {
                speed = initialSpeed;
                isWatering = false;
            }

            if (isWatering)
            {
                playerItens.CurrentWater -= 0.01f;
            }
        }

    }

    #endregion
}
