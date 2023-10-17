using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float m_MoveSpeed = 3f;
	[SerializeField]
	private Animator m_Animator;
	[SerializeField] private Collider2D m_MoveUpDisableCollider;
	[SerializeField] private LayerMask m_WhatIsGround;
	[SerializeField] private Transform m_CeilingCheck;
	private bool m_FacingRight = true;

	const float k_CeilingRadius = .2f;
	private void Awake()
    {

	}

    private void Start()
    {

	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void Move(Vector2 _move)
    {
		//Debug.Log("Move.x =" + _move.x);

		if (_move.y > 0)
        {
			if(m_MoveUpDisableCollider != null)
            {
				m_MoveUpDisableCollider.enabled = false;

			}
        }
        else
        {
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				m_MoveUpDisableCollider.enabled = false;
			}
			else
			{
				if (m_MoveUpDisableCollider != null)
				{
					m_MoveUpDisableCollider.enabled = true;

				}
			}
		}

		m_Animator.SetFloat("Speed", _move.magnitude);
		if(_move.x < 0 && m_FacingRight || _move.x > 0 && !m_FacingRight)
        {
			Flip();
        }

		Vector3 targetPosition = transform.position + new Vector3(
			_move.x,
			_move.y,
			0
		);
		transform.position = Vector3.Lerp(transform.position, targetPosition, m_MoveSpeed * Time.deltaTime);
	}



}
