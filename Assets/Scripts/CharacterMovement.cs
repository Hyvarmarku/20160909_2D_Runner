using UnityEngine;
using System.Collections;

namespace Runner
{
    //Adds automatically if missing
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        //cosnt can't be modified
        private const float GroundedRadius = 0.2f;
        private const string GroundedAnimationName = "Ground";
        private const string VecricalSpeedAnimationName = "vSpeed";
        private const string SpeedAnimationName = "Speed";

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce = 800.5f;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rigidbody;

        private bool _isGrounded = false;
		private bool _doubleJumped = false;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _isGrounded = false;
            var colliders = Physics2D.OverlapCircleAll(_groundCheck.position, GroundedRadius);

            for (var i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    _isGrounded = true;
					_doubleJumped = false;
                    break;
                }
            }

            _animator.SetBool(GroundedAnimationName, _isGrounded);
            _animator.SetFloat(VecricalSpeedAnimationName, _rigidbody.velocity.y);
        }

        public void Move(float move, bool jump)
        {
            // Should we move?
            if (_isGrounded)
            {
                _animator.SetFloat(SpeedAnimationName, move);
                _rigidbody.velocity = new Vector2(move * _speed, _rigidbody.velocity.y);
            }

            // Should we jump?
			if (jump)
            {
				//Is the player in air and not jumped twice yet?
				if (!_isGrounded && !_doubleJumped) 
				{
					Jump ();
					_doubleJumped = true;
				} 
				//Is the player on the ground?
				else if (_isGrounded) 
				{
					Jump ();
					_isGrounded = false;
				}
            }


        }

		void Jump()
		{
			_animator.SetBool(GroundedAnimationName, _isGrounded);
			_rigidbody.AddForce(new Vector2(0, _jumpForce));
		}
    }
}