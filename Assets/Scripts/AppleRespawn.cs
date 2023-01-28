using BlockSnake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSnake
{
    public class AppleRespawn : MonoBehaviour
    {
        [SerializeField] private Vector3 _pos;
        [SerializeField] private List<GameObject> _apples;

        private void Start()
        {
            StartCoroutine(SpawnTriggerChecker());
        }

        private IEnumerator SpawnTriggerChecker()
        {
            while (true)
            {
                if (transform.position.z == _pos.z) RespawnApples();

                yield return new WaitForFixedUpdate();
            }
        }

        private void RespawnApples()
        {
            for (var i = 0; i < _apples.Count; i++)
            {
                _apples[i].SetActive(false);
                _apples[i].SetActive(true);
                _apples[i].GetComponent<AppleRandomSystem>().RunRandomSpawn();
            }
        }
    }
}