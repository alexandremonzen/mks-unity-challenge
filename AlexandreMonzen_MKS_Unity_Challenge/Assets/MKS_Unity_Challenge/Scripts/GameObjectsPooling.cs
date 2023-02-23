using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MKS.Challenge
{
    public sealed class GameObjectsPooling : MonoBehaviour
    {
        private List<CannonBall> _pooledCannonBall;

        [SerializeField] private GameObject _cannonBallObj;

        [SerializeField] private int _amountUpPlayerCannonBall;

        private void Awake()
        {
            _pooledCannonBall = new List<CannonBall>();
            for (int i = 0; i < _amountUpPlayerCannonBall; i++)
            {
                GameObject obj = Instantiate(_cannonBallObj);
                obj.SetActive(false);
                _pooledCannonBall.Add(obj.GetComponent<CannonBall>());
            }
        }

        public CannonBall GetPooledCannonBall()
        {
            for (int i = 0; i < _pooledCannonBall.Count; i++)
            {
                if (!_pooledCannonBall[i].gameObject.activeInHierarchy)
                {
                    return _pooledCannonBall[i];
                }
            }
            return null;
        }
    }
}