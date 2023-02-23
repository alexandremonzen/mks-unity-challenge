using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKS.Challenge
{
    public class ShooterAI : MonoBehaviour
    {
        [SerializeField] private float _shootIntervalTime = 1;
        [SerializeField] private float _distanceToShoot = 3;
        [SerializeField] private GameObject _cannonBall;
        [SerializeField] private Transform _offsetSingleShoot;

        private float _timer;
        private IMovementAI _movementAI;
        private IDamageable _damageable;
        private GameObjectsPooling _objectPooler;

        private void Awake()
        {
            _movementAI = GetComponent<IMovementAI>();
            _damageable = GetComponent<IDamageable>();
            _objectPooler = FindObjectOfType<GameObjectsPooling>();

            _timer = 0;
        }

        private void Update()
        {
            _timer += 1 * Time.deltaTime;

            if (_movementAI.GetDistanceFromTarget() <= _distanceToShoot)
            {
                ShootAtTarget();
            }
        }

        private void ShootAtTarget()
        {
            if (_timer >= _shootIntervalTime)
            {
                _timer = 0;

                CannonBall cannonBall = _objectPooler.GetPooledCannonBall();
                cannonBall.transform.position = _offsetSingleShoot.position;
                cannonBall.transform.rotation = _offsetSingleShoot.rotation;
                cannonBall.IDamage.SetTeamSide(_damageable.GetTeamSide());
                cannonBall.ResetRigidbodyVelocity();

                cannonBall.gameObject.SetActive(true);
                cannonBall.ShootCannonBall(Vector2.up);

                //audio
            }
        }
    }
}