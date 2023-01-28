using UnityEngine;
using Random = System.Random;

namespace BlockSnake
{
    public class BarrierRandomSystem : MonoBehaviour
    {
        private Random _rand = new Random();

        [SerializeField, Range(1, 100)] private int _spawnWindowNum = 10;

        private void Awake()
        {
            BarrierRandomSpawn();
        }

        public void RunRandomSpawn() => BarrierRandomSpawn();

        private void BarrierRandomSpawn()
        {
            var tempNum = _rand.Next(1, 101);
            if (tempNum > _spawnWindowNum) gameObject.SetActive(false);
        }
    }
}