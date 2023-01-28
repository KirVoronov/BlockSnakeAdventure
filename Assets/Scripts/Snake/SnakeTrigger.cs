using System;
using TMPro;
using UnityEngine;

namespace BlockSnake
{
    public class SnakeTrigger : MonoBehaviour
    {
        private int _snakeTempLenght = 1;
        private int _scoreSum = 0;

        public int GetSnakeTempLenght => _snakeTempLenght;
        public int GetScoreSum => _scoreSum;

        private void OnCollisionEnter(Collision collision)
        {
            var normal = -collision.contacts[0].normal.normalized;
            var dot = Vector3.Dot(normal, Vector3.forward);
          
            if (collision.gameObject.name.Contains("Block") && dot >= .7f)
            {
                var currentBlockPower = Int32.Parse(collision.collider.GetComponentInChildren<TMP_Text>().text);

                _snakeTempLenght -= currentBlockPower;

                if(_snakeTempLenght >0) _scoreSum += currentBlockPower;
            }
            else if (collision.gameObject.name.Contains("Sin"))
            {
                _snakeTempLenght += Int32.Parse(collision.collider.GetComponentInChildren<TMP_Text>().text);
            }
        }
    }
}