using System.Collections;
using UnityEngine;

namespace BlockSnake
{
    public class LevelSystem : MonoBehaviour
    {
        private int _currentIndex = 0;

        private float _lastZ = 25f;

        private Vector3 position;

        [SerializeField] private Vector3 platformUpdatePos;
        [SerializeField] private Transform[] _levels;

        private void Start()
        {
            StartCoroutine(CheckPosition());
        }

        private IEnumerator CheckPosition()
        {
            while (true)
            {
                for (var i = 0; i < _levels.Length; i++)
                {
                    if (_levels[i].transform.position.z <= platformUpdatePos.z) UpdateLevel();
                }

                yield return new WaitForFixedUpdate();
            }

        }

        private void UpdateLevel()
        {
            position = _levels[_currentIndex].position;
            position.z = _lastZ;

            _levels[_currentIndex].position = position;

            _currentIndex++;
            if (_currentIndex >= _levels.Length)
            {
                _currentIndex = 0;
            }
        }
    }
}