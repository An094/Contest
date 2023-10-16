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
	private bool m_FacingRight = true;
	

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
		m_Animator.SetFloat("Speed", _move.magnitude);
		if(_move.x < 0 && m_FacingRight || _move.x > 0 && !m_FacingRight)
        {
			Flip();
        }
		Vector3 scaledMovement = m_MoveSpeed * Time.deltaTime * new Vector3(
			_move.x,
			_move.y,
			0
		);

		transform.Translate(scaledMovement);
	}



}
