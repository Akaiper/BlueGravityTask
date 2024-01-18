using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _direction;
    
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Animator _playerAnimator;

    private KeyCode[] _leftKeys = {KeyCode.A, KeyCode.LeftArrow};
    private KeyCode[] _rightKeys = {KeyCode.D, KeyCode.RightArrow};
    private KeyCode[] _upKeys = {KeyCode.W, KeyCode.UpArrow};
    private KeyCode[] _downKeys = {KeyCode.S, KeyCode.DownArrow};

    private bool _walkRight, _walkLeft, _walkUp, _walkDown;

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }

    private void Movement()
	{
        KeyUp();

        _walkRight = _playerAnimator.GetBool("WalkingRight");
        _walkLeft = _playerAnimator.GetBool("WalkingLeft");
        _walkUp = _playerAnimator.GetBool("WalkingUp");
        _walkDown = _playerAnimator.GetBool("WalkingDown");


        if (PressedKey(_leftKeys))
		{
			if (!_walkRight && !_walkDown && !_walkUp)
			{
                _playerAnimator.SetBool("WalkingLeft", true);

                _direction = new Vector3(-1, 0, 0);
                transform.position += _speed * Time.deltaTime * _direction;
            }
        }
        if (PressedKey(_rightKeys))
		{
			if (!_walkLeft && !_walkDown && !_walkUp)
			{
                _playerAnimator.SetBool("WalkingRight", true);

                _direction = new Vector3(1, 0, 0);
                transform.position += _speed * Time.deltaTime * _direction;
            }
        }
        if (PressedKey(_downKeys))
		{
			if (!_walkUp && !_walkLeft && !_walkRight)
			{
                _playerAnimator.SetBool("WalkingDown", true);

                _direction = new Vector3(0, -1, 0);
                transform.position += _speed * Time.deltaTime * _direction;
            }
        }
        if (PressedKey(_upKeys))
		{
			if (!_walkDown && !_walkLeft && !_walkRight)
            {
                _playerAnimator.SetBool("WalkingUp", true);

                _direction = new Vector3(0, 1, 0);
                transform.position += _speed * Time.deltaTime * _direction;
            }
        }
    }

    private void KeyUp()
	{
		if (!PressedKey(_leftKeys))
		{
            _playerAnimator.SetBool("WalkingLeft", false);
        }
        if (!PressedKey(_rightKeys))
		{
            _playerAnimator.SetBool("WalkingRight", false);
        }
        if (!PressedKey(_downKeys))
		{
            _playerAnimator.SetBool("WalkingForward", false);
        }
        if (!PressedKey(_upKeys))
		{
            _playerAnimator.SetBool("WalkingBack", false);
        }
    }

    private bool PressedKey(KeyCode[] keyCodes)
    {
        foreach (KeyCode key in keyCodes)
        {
            if (Input.GetKey(key))
            {
                return true;
            }
        }

        return false;
    }
}
