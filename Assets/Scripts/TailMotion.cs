using System;
using System.Collections;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace BlockSnake
{
    public class TailMotion : MonoBehaviour
    {
        private float _offset = .25f;
        private Vector3 _startPos;

        [SerializeField] private GameObject _targetTailPart;
        [SerializeField] private float _speed = 5f;

        private void Start()
        {
            //Как там говорил куплинов...  https://coub.com/view/1ax9m4
            if(_targetTailPart == null )
                _targetTailPart = GameObject.Find(Convert.ToString(int.Parse(gameObject.name) - 1));

            StartCoroutine(ApplyTailPursuit(_targetTailPart));
        }

        private IEnumerator ApplyTailPursuit(GameObject target)
        {
            while (true)
            {
                var currentTarget = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - _offset);

                transform.LookAt(currentTarget);
                //transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
                transform.position = Vector3.Lerp(transform.position, currentTarget, (_speed * Time.deltaTime));
                yield return new WaitForFixedUpdate();
            }
        }
    }
}