using System.Collections;
using UnityEngine;

namespace BlockSnake
{
    public class SnakeMotion : MonoBehaviour
    {
        private SnakeControls _controls;
        private float _direction;
        private float _radius = 1.2f;

        [SerializeField] private GameObject _snakeHead;
        [SerializeField] private Vector3 _centerPoint;

        private void Awake()
        {
            _controls = new SnakeControls();
        }

        private void Start()
        {
            StartCoroutine(SnakeMotionCoroutine());
        }

        private void OnEnable() => _controls.Snake.Enable();

        private IEnumerator SnakeMotionCoroutine()
        {
            while (true)
            {
                _direction = _controls.Snake.HorizontalMorion.ReadValue<float>() * (Time.deltaTime * 5f); //todo speed modif
                if (_direction != 0f)
                {
                    var newPos = transform.position += _direction * transform.right;
                    var offset = newPos - _centerPoint;

                    transform.position = _centerPoint + Vector3.ClampMagnitude(offset, _radius);
                }

                yield return new WaitForFixedUpdate();
            }
        }

        private void OnDestroy() => _controls.Snake.Disable();

        private void OnDisable() => _controls.Snake.Enable();
    }
}