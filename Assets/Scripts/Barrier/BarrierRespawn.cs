using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSnake
{
    public class BarrierRespawn : MonoBehaviour
    {
        [SerializeField] private Vector3 _pos;
        [SerializeField] private List<GameObject> _barriers;

        private void Start()
        {
            StartCoroutine(SpawnTriggerChecker());
        }

        private IEnumerator SpawnTriggerChecker()
        {
            while (true)
            {
                if (transform.position.z == _pos.z) RespawnBarriers();

                yield return new WaitForFixedUpdate();
            }
        }

        private void RespawnBarriers()
        {
            for (var i = 0; i < _barriers.Count; i++)
            {
                _barriers[i].SetActive(false);
                _barriers[i].SetActive(true);
                _barriers[i].GetComponent<BarrierRandomSystem>().RunRandomSpawn();
            }
        }
    }
}