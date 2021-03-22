
/*
 * If platform is mobilenplatform then we consider input from joystick. This will handle by InputManager
 * for rotation we need to consider when joystick drag started and end.
 * when rotation joystick start drag then player can rotate and when it end its draging then player lost its rotation capabilities
 * If we do not consider those drag , then after drag end player will rotate 0 degree instead its previous value
 */
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed = 5.0f;

    private Vector3 _moveDirection;
	private Vector3 _prevMoveDirection;
	private bool _canRotate = false;

	Quaternion _prevRotation = Quaternion.LookRotation(Vector3.zero, Vector3.up);
	private void Start()
	{
		if (Utils.IsItMobilePlatform() == true)
            // If platform is mac or Pc then player will rotate based on Mouse position. In this case we do not need to consider joystick drag
        {
			TouchPointerHandler.onDragStarted += onBeginDrag;
			TouchPointerHandler.onDragCompleted += onEndDrag;
		}
	}
	private void OnDestroy()
	{
		if (Utils.IsItMobilePlatform() == true)
		{
			TouchPointerHandler.onDragStarted -= onBeginDrag;
			TouchPointerHandler.onDragCompleted -= onEndDrag;
		}
	}
	void Update()
    {
		_moveDirection = InputManager.instance.GetPlayerMovementAxisValue();
		_moveDirection.Normalize();
	}
	
	private void FixedUpdate()
    {
		MovePlayer();
		if(_canRotate == true)
		{
			if (_moveDirection != Vector3.zero)
			{
				Quaternion rotation = Quaternion.LookRotation(_moveDirection, Vector3.up);
				_rb.MoveRotation(rotation);
				_prevRotation = rotation;
			}
		}
		else
		{
			_rb.MoveRotation(_prevRotation);
		}
	}

    void MovePlayer()
    {
		if (_moveDirection != Vector3.zero)
		{
			_prevMoveDirection = _moveDirection;
			_rb.MovePosition(transform.position + _moveDirection * _moveSpeed * Time.fixedDeltaTime);
		}
		else
			_rb.MovePosition(transform.position + _prevMoveDirection * _moveSpeed * Time.fixedDeltaTime);
	}

	void onBeginDrag()
	{
		_canRotate = true;
	}
	void onEndDrag()
	{
		_canRotate = false;
	}
    public float GetPlayerMoveSpeed()
    {
		return _moveSpeed;
    }

}
