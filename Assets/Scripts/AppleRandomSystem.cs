using UnityEngine;
using System;
using TMPro;
using Random = System.Random;


namespace BlockSnake
{
    public class AppleRandomSystem : MonoBehaviour
    {
        private Random _rand = new Random();

        [SerializeField] private TMP_Text _text;
        [SerializeField, Range(1, 100)] private int _spawnWindowNum = 10;

        private void Awake()
        {
            _text.text = Convert.ToString(_rand.Next(1, 11));
            BlockRandomSpawn();
        }

        public void RunRandomSpawn() => BlockRandomSpawn();

        private void BlockRandomSpawn()
        {
            var tempNum = _rand.Next(1, 101);
            if (tempNum > _spawnWindowNum) gameObject.SetActive(false);
        }
    }
}