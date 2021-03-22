using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public LayerMask layer;
	[SerializeField] private float _moveSpeed = 5.0f;
	[SerializeField] private float _rotationSpeed = 10.0f;

	private Vector3 _moveDirection;
	[SerializeField] private Rigidbody _rb;
	
	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		CheckRayCast();
		if (Input.GetKeyDown(KeyCode.R))
		{
			MoveRight();
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			MoveLeft();
		}
		if (Input.GetKeyDown(KeyCode.B))
			MoveDown();
		if (Input.GetKeyDown(KeyCode.T))
			MoveUp();
	}

	private void FixedUpdate()
	{
		MovePlayer();
	}

	void MovePlayer()
	{
		if (_moveDirection != Vector3.zero)
		{
			_rb.MovePosition(transform.position + _moveDirection * _moveSpeed * Time.fixedDeltaTime);
			Quaternion rotation = Quaternion.LookRotation(_moveDirection, Vector3.up);
			_rb.MoveRotation(rotation);
		}
	}


	private void MoveRight()
	{
		_moveDirection = new Vector3(1,0,0);
	}
	private void MoveLeft()
	{
		_moveDirection = new Vector3(-1, 0, 0);
	}
	private void MoveDown()
	{
		_moveDirection = new Vector3(0, 0, -1);
	}
	private void MoveUp()
	{
		_moveDirection = new Vector3(0, 0, 1);
	}


	public void CheckRayCast()
	{
		Vector3 fromPosition = transform.position;
		fromPosition.y = 1.0f;
		Vector3 direction = new Vector3(100, 0, 0);

		RaycastHit hit;
		Debug.DrawRay(fromPosition, direction, Color.green);
		if (Physics.Raycast(fromPosition, direction, out hit, layer))
		{
		//	Debug.DrawRay(fromPosition, direction, Color.yellow);
			/*	if (Input.GetMouseButtonDown(0))
				{
					Rigidbody obj = Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
					obj.velocity = vo;
				}*/
		}
	}


}
