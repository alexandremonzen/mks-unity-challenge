using UnityEngine;

namespace MKS.Challenge
{
    public sealed class VisualShip : MonoBehaviour, IVisualShip
    {
        [Header("Sprites")]
        [SerializeField] private Sprite[] _hullLargeSprites;
        [SerializeField] private Sprite[] _sailLargeSprites;
        [SerializeField] private Sprite[] _sailSmallSprites;

        private SpriteRenderer _actualHullLargeSprite;
        private SpriteRenderer _actualSailLargeSprite;
        private SpriteRenderer _actualSailSmallSprite;

        private IDamageable _damageable;

        private void Awake()
        {
            _damageable = GetComponentInParent<IDamageable>();

            _actualHullLargeSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
            _actualSailLargeSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
            _actualSailSmallSprite = transform.GetChild(2).GetComponent<SpriteRenderer>();

            UpdateSprites(0);
        }

        private void OnEnable()
        {
            _damageable.OnTookDamage += UpdateSprites;
        }

        private void OnDisable()
        {
            _damageable.OnTookDamage -= UpdateSprites;
        }

        public void UpdateSprites(int value)
        {
            int setSprites = 0;

            switch (value)
            {
                case int n when n > 49 && n < 100:
                    setSprites = 1;
                    break;

                case int n when n > 0 && n <= 49:
                    setSprites = 2;
                    break;

                default:
                    break;
            }

            for (int i = 0; i < _hullLargeSprites.Length; i++)
            {
                _actualHullLargeSprite.sprite = _hullLargeSprites[setSprites];
                _actualSailLargeSprite.sprite = _sailLargeSprites[setSprites];
                _actualSailSmallSprite.sprite = _sailSmallSprites[setSprites];
            }
        }
    }
}