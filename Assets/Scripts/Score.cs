using System;
using TMPro;
using UnityEngine;

namespace BlockSnake
{
    public class Score : MonoBehaviour
    {
        private SnakeTrigger _snake;

        [SerializeField] private GameObject _snakePrefab;
        [SerializeField] private TMP_Text _text;

        public static Score Self { get; private set; }
        public int GetScore => Int32.Parse(_text.text);

        private void Start()
        {
            Self = this; 
            _text.text = "0";
            _snake = _snakePrefab.GetComponent<SnakeTrigger>();
        }

        private void Update()
        {
            _text.text = Convert.ToString(_snake.GetScoreSum);
        }
    }
}