using UnityEngine;
using UnityEngine.UI;

namespace MKS.Challenge
{
    public sealed class HealthBarUI : MonoBehaviour
    {
        private Image _fillBar;
        private IDamageable _damageable;

        private void Awake()
        {
            _fillBar = GetComponentInChildren<Image>();
            _damageable = GetComponentInParent<IDamageable>();
        }

        private void OnEnable()
        {
            _damageable.OnTookDamage += UpdateFillBarUI;
        }

        private void OnDisable()
        {
            _damageable.OnTookDamage -= UpdateFillBarUI;
        }

        private void UpdateFillBarUI(int fillValue)
        {
            _fillBar.fillAmount = fillValue / (float)_damageable.GetMaxHealth();
        }
    }
}