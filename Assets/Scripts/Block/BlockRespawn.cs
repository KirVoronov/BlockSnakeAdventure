using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSnake
{
    public class BlockRespawn : MonoBehaviour
    {
        [SerializeField] private Vector3 _pos;
        [SerializeField] private List<GameObject> _blocks;

        private void Start()
        {
            StartCoroutine(SpawnTriggerChecker());
        }

        private IEnumerator SpawnTriggerChecker()
        {
            while (true)
            {
                if (transform.position.z == _pos.z) RespawnBlocks();

                yield return new WaitForFixedUpdate();
            }
        }

        private void RespawnBlocks()
        {
            for (var i = 0; i < _blocks.Count; i++)
            {
                _blocks[i].SetActive(false);
                _blocks[i].SetActive(true);
                _blocks[i].GetComponent<BlockRandomSystem>().RunRandomSpawn();
            }
        }
    }
}