using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKS.Challenge
{
    public sealed class MovementAI : MonoBehaviour, IMovementAI
    {
        [SerializeField] private GameObject _targetToSeek;
        [SerializeField] private float _distanceToStop = 0.1f;
        [SerializeField] private float _movementSpeed = 2;

        private bool _canMove;
        private Vector2 _movementVector;
        private float _distanceFromTarget;
        private Vector3 _directionVector;
        private float _angleDirection;

        private Rigidbody2D _rigidbody;
        public GameObject targetToSeek { get => _targetToSeek; set => _targetToSeek = value; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _canMove = true;
        }

        private void Update()
        {
            CalculateMovement();
            CalculateRotation();
        }

        private void FixedUpdate()
        {
            if (_canMove)
            {
                if (NotReachedMaxDistance())
                {
                    MoveToTarget(_movementVector);
                }
            }

            RotateToTarget();
        }

        private void CalculateMovement()
        {
            _directionVector = _targetToSeek.transform.position - transform.position;
            _directionVector.Normalize();
            _movementVector = _directionVector;

            _distanceFromTarget = Vector3.Distance(transform.position, _targetToSeek.transform.position);
        }

        private void CalculateRotation()
        {
            _angleDirection = Mathf.Atan2(-_directionVector.x, _directionVector.y) * Mathf.Rad2Deg;
        }

        private void MoveToTarget(Vector2 directionVector)
        {
            _rigidbody.MovePosition((Vector2)transform.position + (directionVector * _movementSpeed * Time.fixedDeltaTime));
        }

        private void RotateToTarget()
        {
            _rigidbody.rotation = _angleDirection;
        }

        public float GetDistanceFromTarget()
        {
            return _distanceFromTarget;
        }

        public bool NotReachedMaxDistance()
        {
            return _distanceFromTarget >= _distanceToStop;
        }
    }
}