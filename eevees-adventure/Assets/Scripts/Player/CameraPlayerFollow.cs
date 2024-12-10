using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _cameraOffset = new Vector3(0f, 3f, -15f);
    [SerializeField] private float _smootheTime = 0.1f;
    [SerializeField] private Transform _playerTransform;

    private Vector3 _velocity = Vector3.zero;
    private Vector3 _currentTargetPosition = Vector3.zero;

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    /// <summary>
    /// Makes the camera object follow the player objects transform.
    /// </summary>
    private void FollowPlayer()
    {
        this._currentTargetPosition = this._playerTransform.position + this._cameraOffset;
        this.transform.position = Vector3.SmoothDamp(this.transform.position, this._currentTargetPosition, ref this._velocity, this._smootheTime);
    }
}
