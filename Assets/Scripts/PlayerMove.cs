using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 5.0f;
	[SerializeField] private float _rotationSpeed = 5.0f;

	[SerializeField] private Rigidbody _rb;

	private Vector3 _moveDirection;
	private Vector3 _previousDirection = Vector3.zero;

	Quaternion _prevRotation = Quaternion.LookRotation(Vector3.zero, Vector3.up);

	Vector2 inputData;
	float _horizontalValue, _verticalValue;

	void Update()
	{
		_horizontalValue = Input.GetAxis("Horizontal");
		_verticalValue = Input.GetAxis("Vertical");
	     Debug.Log("Vertical Value " + _verticalValue + "  hor val "  + _horizontalValue);
	   
	}

	private void FixedUpdate()
	{
		inputData = new Vector2(_horizontalValue, _verticalValue);
		_moveDirection = new Vector3(_horizontalValue, 0, _verticalValue);
		_moveDirection.Normalize();

		if(_moveDirection != Vector3.zero)
		{
			//Debug.Log("Move Direction - " + _moveDirection);
			_rb.MovePosition(transform.position + _moveDirection * _moveSpeed * Time.fixedDeltaTime);
			Quaternion rotation = Quaternion.LookRotation(_moveDirection, Vector3.up);
			_rb.MoveRotation(rotation);
			_previousDirection = _moveDirection;
			_prevRotation = rotation;
		}
		else
		{
			//Debug.Log("Move Direction "  +  _moveDirection +"Prev Direction - " + _previousDirection);
			_rb.MovePosition(transform.position + _previousDirection * _moveSpeed * Time.fixedDeltaTime);
			_rb.MoveRotation(_prevRotation);
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

}
