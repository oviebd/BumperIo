using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private Rigidbody _rb;
	[SerializeField] private float _moveSpeed = 5.0f;

	private bool canRotate = false;
	Vector3 rotateDirection;

	Vector2 inputData;
	float _horizontalValue, _verticalValue;

	void Update()
	{
		_horizontalValue = Input.GetAxis("Horizontal");
		_verticalValue = Input.GetAxis("Vertical");
		// Debug.Log("Vertical Value " + _verticalValue);
		inputData = new Vector2(_horizontalValue, _verticalValue);
		
	}

	private void FixedUpdate()
	{
		RotateObj();
		//MoveObj();
		if (canRotate == false)
		{
			//MoveObj();
		}
	}

	private void MoveRorward()
	{

	}

	private void MoveBackWard()
	{

	}

	private void MoveRight()
	{

	}

	private void MoveLeft()
	{

	}

	private void RotateObj()
	{
		Vector2 inputDir = inputData.normalized;
		if (inputDir != Vector2.zero)
		{

			float angle =  (Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg);
			//angle = flipRot ? -angle : angle;
			Debug.Log(angle);
			Quaternion rotation = Quaternion.Euler(0, angle, 0);
			_rb.MoveRotation(rotation);
			canRotate = true;
		}
		else
		{
			canRotate = false;
		}

	}

	public void MoveObj()
	{
		Vector2 newPos = _rb.position + transform.forward * _moveSpeed * Time.fixedDeltaTime;
		_rb.MovePosition(newPos);
		//transform.Translate(transform.forward * _moveSpeed * Time.deltaTime, Space.World);
	}


}
