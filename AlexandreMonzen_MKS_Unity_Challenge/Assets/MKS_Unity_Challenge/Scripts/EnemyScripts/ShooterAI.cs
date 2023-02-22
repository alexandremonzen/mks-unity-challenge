using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAI : MonoBehaviour
{
    [SerializeField] private GameObject _cannonBall;
    [SerializeField] private float _timeToShoot;
    [SerializeField] private float _distanceToShoot;
    [SerializeField] private Transform _offsetSingleShoot;

    private float _timer;
    IMovementAI _movementAI;

    private void Awake()
    {
        _movementAI = GetComponent<IMovementAI>();

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
        if (_timer >= _timeToShoot)
        {
            _timer = 0;

            Instantiate(_cannonBall, _offsetSingleShoot.position, _offsetSingleShoot.rotation, null);
            //cannonBall.transform.position = _offsetSingleShoot.position;
            //cannonBall.transform.rotation = _offsetSingleShoot.rotation;
            //cannonBall.SetActive(true);

            //audio
        }
    }
}
