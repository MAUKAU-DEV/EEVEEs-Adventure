using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// The PlayerController class manages the movement inputs of the player object.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _moveSpeed = 8.0f;
    [SerializeField] private float _crouchSpeed = 4.0f;
    [SerializeField] private float _jumpForce = 15.0f;
    [SerializeField] private float _gravity = 22.0f;
    [SerializeField] private float _isGroundedDistance = 1.1f;

    [Header("Connected Components")]
    [SerializeField] private Rigidbody _rigidbody;
    
    // Internal
    private InputController _inputController;
    private Vector3 _currentMovement;

    #region UNITY_RUNTIME
    private void Awake()
    {
        _inputController = new InputController();
        _inputController.PlayerGameplay.Enable();
        _inputController.PlayerGameplay.Movement_Jump.performed += Jump;
    }

    private void OnDestroy()
    {
        _inputController.PlayerGameplay.Movement_Jump.performed -= Jump;
        _inputController.PlayerGameplay.Disable();
    }


    private void FixedUpdate()
    {

        SideMovement(this._inputController.PlayerGameplay.Movement_Sides.ReadValue<float>());
        this._rigidbody.linearVelocity = this._currentMovement;

        Gravity();
    }

    #endregion

    /// <summary>
    /// SideMovement moves the player to the sides on the X axis. If the crouch button is pressed it moves the player with the crouch speed.
    /// </summary>
    /// <param name="inputValue">The float from the input action.</param>
    private void SideMovement(float inputValue)
    {
        if (!this._inputController.PlayerGameplay.Movement_Crouch.IsPressed())
        {
            // Normal Movement speed
            this._currentMovement = new Vector3(-(inputValue) * this._moveSpeed, this._rigidbody.linearVelocity.y, 0f);
        } else
        {
            // Crouch Movement speed
            this._currentMovement = new Vector3(-(inputValue) * this._crouchSpeed, this._rigidbody.linearVelocity.y, 0f);
        }
    }

    #region JUMP_MECHANIC

    /// <summary>
    /// Lets the player object jump with a upward impulse.
    /// </summary>
    /// <param name="ctx">The <c>CallbackContext</c> from the inputActions.</param>
    private void Jump(InputAction.CallbackContext ctx)
    {
        if (!IsGrounded()) return;

        this._rigidbody.AddForce(new Vector3(0f, this._jumpForce, 0f), ForceMode.Impulse);
    }

    /// <summary>
    /// IsGrounded confirms that the player is grounded, by checking if it hits a collider in range set by _isGroundedDistance.
    /// </summary>
    /// <returns>  bool If the player is grounded it returns true if not then false. </returns>
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, _isGroundedDistance);
    }

    /// <summary>
    /// Adds a own gravity to the player object to get the desired feeling.
    /// </summary>
    private void Gravity()
    {
        if (this._rigidbody.linearVelocity.y < 0f)
        {
            this._rigidbody.AddForce(new Vector3(0f, -(this._gravity * 2), 0f), ForceMode.Acceleration);
        } else
        {
            this._rigidbody.AddForce(new Vector3(0f, -(this._gravity), 0f), ForceMode.Acceleration);
        }
    }

    #endregion
}
