using System;
using UnityEngine;

namespace MKS.Challenge
{
    public sealed class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth = 100;
        private int _actualHealth;

        public event Action OnDied;
        public event Action<int> OnTookDamage;

        private void OnEnable()
        {
            SetDefaultHealth();
        }

        public void TakeDamage(int damageValue)
        {
            _actualHealth -= damageValue;
            OnTookDamage?.Invoke(_actualHealth);

            if (_actualHealth <= 0)
            {
                Die();
            }
        }

        public int GetMaxHealth()
        {
            return _maxHealth;
        }

        private void Die()
        {
            OnDied?.Invoke();
        }

        private void SetDefaultHealth()
        {
            _actualHealth = _maxHealth;
        }
    }
}