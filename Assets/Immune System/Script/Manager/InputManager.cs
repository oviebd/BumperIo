using UnityEngine;

public class InputManager : MonoBehaviour
{
	[SerializeField] private FloatingJoystick _movementJoystick;
//	[SerializeField] private Camera _mainCamera;

	public static InputManager instance;

	private void Awake()
    {
		if (instance == null)
			instance = this;
    }

    public Vector3 GetPlayerMovementAxisValue()
    {
		Vector3 movementVector = Vector3.zero;
		if (Utils.IsItMobilePlatform())
            movementVector = new Vector3(_movementJoystick.Horizontal,0, _movementJoystick.Vertical);
		else
		{
			movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
			//  rotationMovement = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
		}
		return movementVector;
    }

}
