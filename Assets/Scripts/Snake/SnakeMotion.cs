using System.Collections;
using UnityEngine;

namespace BlockSnake
{
    public class SnakeMotion : MonoBehaviour
    {
        private SnakeControls _controls;
        private Rigidbody _rb;

        private Vector3 _lastTouchPos;

        private float _direction;
        private float _radius = 1.2f;
        private float _sens = 3f;

        [SerializeField] private Transform _snakeHead;
        [SerializeField] private Vector3 _centerPoint;

        private void Awake()
        {
            _controls = new SnakeControls();
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            StartCoroutine(SnakeMotionCoroutine());
        }

        private void FixedUpdate()
        {
            CheckTouch();
        }

        private void OnEnable()
        {
            _controls.Snake.Enable();
        }

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

        private void CheckTouch()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - _lastTouchPos;
                _rb.velocity += new Vector3(delta.x * _sens * Time.deltaTime, 0f, 0f);

            }
            _lastTouchPos = Input.mousePosition;
        }

        private void OnDisable()
        {
            _controls.Snake.Disable();
        }

        private void OnDestroy() => _controls.Dispose();
    }
}