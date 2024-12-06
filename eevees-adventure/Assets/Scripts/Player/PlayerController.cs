using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.5f;
    [SerializeField] private float _crouchSpeed = 1.0f;
    [SerializeField] private float _jumpForce = 1.0f;
    [SerializeField] private float _gravityScaleMuliplier = 1.0f;
    [SerializeField] private float _gravityScaleMuliplierFalling = 1.0f;
    [SerializeField] private float _isGroundedDistance = 1.0f;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    
    private InputController _inputController;
    private float _gravityScaleGrounded;
    private float _gravityScaleFalling;
    private float _gravityScale;

    private void Awake()
    {
        _inputController = new InputController();
        _inputController.PlayerGameplay.Enable();
        _inputController.PlayerGameplay.Movement_Jump.performed += _ => Jump();


        //this._gravityScaleGrounded = (Physics.gravity.y * (this._gravityScaleMuliplier - 1) * this._rigidbody.mass);
        //this._gravityScaleFalling = (Physics.gravity.y * (this._gravityScaleMuliplierFalling - 1) * this._rigidbody.mass);

    }

    private void OnDestroy()
    {
        _inputController.PlayerGameplay.Movement_Jump.performed -= _ => Jump();
        _inputController.PlayerGameplay.Disable();
    }

    private void Update()
    {
        //GravityModifier();
    }

    private void FixedUpdate()
    {

        this._gravityScaleGrounded = (Physics.gravity.y * (this._gravityScaleMuliplier - 1) * this._rigidbody.mass);
        this._gravityScaleFalling = (Physics.gravity.y * (this._gravityScaleMuliplierFalling - 1) * this._rigidbody.mass);
        GravityModifier();

        SideMovement(_inputController.PlayerGameplay.Movement_Sides.ReadValue<float>());   
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, _isGroundedDistance);
    }

    private void GravityModifier()
    {
        Debug.Log(this._rigidbody.linearVelocity.y);

        if (this._rigidbody.linearVelocity.y >= 0f)
        {
            this._gravityScale = this._gravityScaleGrounded;
        }
        else if (this._rigidbody.linearVelocity.y < 0f)
        {
            this._gravityScale = this._gravityScaleFalling;
        }

        this._rigidbody.AddForce(new Vector3(0f, this._gravityScale, 0f), ForceMode.Force);
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            _rigidbody.AddForce(new Vector3(0f, this._jumpForce, 0f), ForceMode.Force);
        } else
        {
            Debug.Log("NOT GROUNDED");
        }
    }

    private void SideMovement(float inputValue)
    {
        if (!this._inputController.PlayerGameplay.Movement_Crouch.IsPressed())
        {
            _rigidbody.linearVelocity = new Vector3(-(inputValue) * this._moveSpeed, 0f, 0f);
        } else
        {
            _rigidbody.linearVelocity = new Vector3(-(inputValue) * this._crouchSpeed, 0f, 0f);
        }
    }
}
