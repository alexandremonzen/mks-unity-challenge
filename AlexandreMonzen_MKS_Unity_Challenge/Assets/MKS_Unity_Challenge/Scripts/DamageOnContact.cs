using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKS.Challenge
{
    public sealed class DamageOnContact : MonoBehaviour, IDamage
    {
        [SerializeField] private Team _team = Team.Default;
        [SerializeField] private int _damageValue;
        [SerializeField] private bool _onCollision = true;
        [SerializeField] private bool _onTrigger = true;
        [SerializeField] private bool _autoDestroy = true;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (_onCollision)
            {
                IDamageable damageable = col.gameObject.GetComponent<IDamageable>();
                GiveDamage(damageable);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_onTrigger)
            {
                IDamageable damageable = col.GetComponent<IDamageable>();
                GiveDamage(damageable);
            }
        }

        private void GiveDamage(IDamageable damageable)
        {
            if (damageable != null)
            {
                if (damageable.GetTeamSide() != _team)
                {
                    damageable.TakeDamage(_damageValue, _team);
                    if (_autoDestroy)
                    {
                        this.gameObject.SetActive(false);
                    }
                }
            }
        }

        public void SetTeamSide(Team teamSide)
        {
            _team = teamSide;
        }
    }
}