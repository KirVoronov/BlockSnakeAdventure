using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace BlockSnake
{
    public class TailMotion : MonoBehaviour
    {
        private float _offset = .25f;

        [SerializeField] private GameObject _targetTailPart;
        [SerializeField] private float _speed = 5f;

   private void Start()
        {
            //Как там говорил куплинов...  https://coub.com/view/1ax9m4
            if(_targetTailPart == null )
                _targetTailPart = GameObject.Find(Convert.ToString(int.Parse(gameObject.name) - 1));
        }

        private void FixedUpdate()
        {
            ApplyTailPursuit();
        }

        private void ApplyTailPursuit()
        {
            var currentTarget = new Vector3(_targetTailPart.transform.position.x, _targetTailPart.transform.position.y, _targetTailPart.transform.position.z - _offset);
           
            transform.LookAt(currentTarget);
            transform.position = Vector3.Lerp(transform.position, currentTarget, (_speed * Time.deltaTime));
        }
    }
}