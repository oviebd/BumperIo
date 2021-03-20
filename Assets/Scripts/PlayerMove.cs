using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 5.0f;
	[SerializeField] private float _rotationSpeed = 5.0f;

	private Vector3 _moveDirection;
	private Vector3 _previousDirection = Vector3.zero;

	Vector2 inputData;
	float _horizontalValue, _verticalValue;

	void Update()
	{
		_horizontalValue = Input.GetAxis("Horizontal");
		_verticalValue = Input.GetAxis("Vertical");
		// Debug.Log("Vertical Value " + _verticalValue);
		inputData = new Vector2(_horizontalValue, _verticalValue);
		_moveDirection = new Vector3(_horizontalValue, 0, _verticalValue);
		_moveDirection.Normalize();

			if(_moveDirection != Vector3.zero)
			{
			transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime, Space.World);
			Quaternion rotation = Quaternion.LookRotation(_moveDirection, Vector3.up);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
			_previousDirection = _moveDirection;
		}
		else
		{
			transform.Translate( _previousDirection * _moveSpeed* Time.deltaTime, Space.World);
		}

	}

	private void FixedUpdate()
	{
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

	

	

}
