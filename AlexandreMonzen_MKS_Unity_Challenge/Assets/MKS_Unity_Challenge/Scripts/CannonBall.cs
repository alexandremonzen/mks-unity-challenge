using UnityEngine;

namespace MKS.Challenge
{
    public class CannonBall : MonoBehaviour
    {
        [SerializeField] float _force = 10;
        private IDamage _damageInterface;
        private Rigidbody2D _rigidbody;
        private TrailRenderer _trailRenderer;

        public IDamage IDamage { get => _damageInterface; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _trailRenderer = GetComponentInChildren<TrailRenderer>();
            _damageInterface = GetComponent<IDamage>();
        }

        private void OnEnable()
        {
            _trailRenderer.emitting = true;
        }

        private void OnDisable()
        {
            _trailRenderer.emitting = false;
            _trailRenderer.Clear();
        }

        public void ShootCannonBall(Vector2 directionCannonBall)
        {
            _rigidbody.AddRelativeForce(new Vector2(directionCannonBall.x, directionCannonBall.y) * _force, ForceMode2D.Impulse);
        }

        public void ResetRigidbodyVelocity()
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}