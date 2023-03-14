using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//2D Platformer Movement
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _body;

    /*[SerializeField] private float _gravityScale;
    [SerializeField] private float _fastFallGravityMultiplier;
    [SerializeField] private float _maxFastFallSpeed;*/

    private Vector2 _moveInput = Vector2.zero;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _accelerationRate;
    [SerializeField] private float _deccelerationRate;
    [SerializeField] private float _velocityPower;
    [SerializeField] private float _frictionAmount;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheckerPoint;
    [SerializeField] private Vector2 _groundCheckerSize;
    [SerializeField] private float _jumpInputBufferTime;
    [SerializeField] private float _coyoteTime;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpCutMultiplier;
    [SerializeField] private bool _isJumping = false;
    private bool _isJumpFalling = false;
    private bool _isJumpCut = false;
    private float _lastGroundedTimer = 1f;
    private float _lastJumpInitiatedTimer = 0f;

    private void Start()
    {
        /*SetGravityScale(_gravityScale);*/
    }

    private void Update()
    {
        MovementTimerHandler();
    }

    private void FixedUpdate()
    {
        /*GroundCheckHandler();
        JumpHandler();*/
        GroundCheckHandler();
        MovementHandler();
        JumpHandler();
        FrictionHandler();
    }

    private void MovementTimerHandler()
    {
        _lastGroundedTimer -= Time.deltaTime;
        _lastJumpInitiatedTimer -= Time.deltaTime;
    }

    private void GroundCheckHandler()
    {
        if (!_isJumping)
        {
            if (Physics2D.OverlapBox(_groundCheckerPoint.position, _groundCheckerSize, 0f, _groundMask))
            {
                _lastGroundedTimer = _coyoteTime;
                _isJumpCut = false;
            }
        }
    }

    /*private void JumpHandler()
    {
        if (_isJumping && _body.velocity.y < 0)
        {
            _isJumping = false;
            _isJumpFalling = true;
        }

        if (_lastGroundedTimer > 0 && !_isJumping)
        {
            _isJumpCut = false;
            _isJumpFalling = false;
        }

        if (CanJump() && _lastJumpInitiatedTimer > 0)
        {
            _isJumping = true;
            _isJumpCut = false;
            _isJumpFalling = false;
            Jump();
        }
    }*/

    private void Jump()
    {
        _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _lastGroundedTimer = 0;
        _lastJumpInitiatedTimer = 0;
        _isJumping = true;


        /*_lastJumpInitiatedTimer = 0f;
        _lastGroundedTimer = 0f;

        float jumpForce = _jumpForce;
        if (_body.velocity.y < 0f)
        {
            jumpForce = _body.velocity.y;
        }

        _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);*/
    }

    /*private void SetGravityScale(float gravityScale)
    {
        _body.gravityScale = gravityScale;
    }

    private void MovementTimerHandler()
    {
        _lastGroundedTimer = Time.deltaTime;
        _lastJumpInitiatedTimer = Time.deltaTime;
    }*/

    /*public void JumpInputDownHandler()
    {
        _lastJumpInitiatedTimer = _jumpInputBufferTime;
    }

    public void JumpInputUpHandler()
    {
        if (CanJumpCut())
        {
            _isJumpCut = true;
        }
    }

    private bool CanJumpCut()
    {
        return _isJumping && _body.velocity.y > 0f;
    }

    private bool CanJump()
    {
        return _lastGroundedTimer > 0 && !_isJumping;
    }*/

    private void MovementHandler()
    {
        float targetSpeed = _moveInput.x * _moveSpeed;
        float speedDif = targetSpeed - _body.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _accelerationRate : _deccelerationRate;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, _velocityPower) * Mathf.Sign(speedDif);

        _body.AddForce(movement * Vector2.right);
    }

    private void JumpHandler()
    {
        if (_moveInput.y > 0f)
        {
            // This should only be done the first time Input initiated
            _lastJumpInitiatedTimer = _jumpInputBufferTime;
            if (_lastGroundedTimer > 0f && _lastJumpInitiatedTimer > 0f && !_isJumping)
            {
                Jump();
            }
        }
        else if (_moveInput.y <= 0f)
        {
            if (_body.velocity.y > 0 && _isJumping)
            {
                if (!_isJumpCut)
                {
                    _body.AddForce(Vector2.down * _body.velocity * _jumpCutMultiplier, ForceMode2D.Impulse);
                    _isJumpCut = true;
                }
            }
            if (_lastJumpInitiatedTimer > 0f)
            {
                _lastJumpInitiatedTimer = 0f;
            }
        }

        if (_body.velocity.y <= 0)
        {
            _isJumping = false;
        }
    }

    private void FrictionHandler()
    {
        if (_lastGroundedTimer > 0f && Mathf.Abs(_moveInput.x) < 0.01f)
        {
            float frictionAmount = Mathf.Min(Mathf.Abs(_body.velocity.x), Mathf.Abs(_frictionAmount));
            frictionAmount *= Mathf.Sign(_body.velocity.x);
            _body.AddForce(Vector2.right * -frictionAmount, ForceMode2D.Impulse);
        }
    }

    public void MoveInput(Vector2 moveInput)
    {
        _moveInput = moveInput;
    }

    private void JumpInput()
    {
        
    }

    /*private void Start()
    {
        StartCoroutine(KnockbackTest());
    }

    private void FixedUpdate()
    {
        MovementHandler();
        
    }

    public void MoveToDirection(float direiction)
    {
        _moveDirection = direiction;
    }

    private void MovementHandler()
    {
        _body.AddForce(new Vector2(_moveDirection * _moveSpeed * Time.fixedDeltaTime, _body.velocity.y), ForceMode2D.Impulse);
    }

    private IEnumerator KnockbackTest()
    {
        while(true)
        {
            yield return new WaitForSeconds(5f);
            if (_moveDirection <= 0)
            {
                _body.AddForce(new Vector2(-1f * _moveSpeed * 2, _body.velocity.y), ForceMode2D.Impulse);
            }
            else
            {
                _body.AddForce(new Vector2(1f * _moveSpeed * 2, _body.velocity.y), ForceMode2D.Impulse);
            }
            Debug.Log("ADDFORCE");
        }
    }*/
}
