using System.Collections;
using UnityEngine;

namespace BlockSnake
{
    public class LevelMoving : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(MoveRoadSegments());
        }

        private IEnumerator MoveRoadSegments()
        {
            while (true)
            {
                transform.position -= transform.forward * Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }

        }
    }
}