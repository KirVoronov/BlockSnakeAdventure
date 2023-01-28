using System;
using TMPro;
using UnityEngine;

namespace BlockSnake
{
    public class SnakeTrigger : MonoBehaviour
    {
        private int _snakeTempLenght = 1;

        public int GetSnakeTempLenght { get => _snakeTempLenght; }

        private void OnCollisionEnter(Collision collision)
        {
            var normal = -collision.contacts[0].normal.normalized;
            var dot = Vector3.Dot(normal, Vector3.forward);
          
            if (collision.gameObject.name.Contains("Block") && dot >= .7f)
            {
                _snakeTempLenght -= Int32.Parse(collision.collider.GetComponentInChildren<TMP_Text>().text);
            }
            else if (collision.gameObject.name.Contains("Sin"))
            {
                _snakeTempLenght += Int32.Parse(collision.collider.GetComponentInChildren<TMP_Text>().text);
            }
        }
    }
}