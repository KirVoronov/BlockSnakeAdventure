using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSnake
{
    public class BlockTrigger : MonoBehaviour
    {
        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.name == "SnakeHead")
            {
                var normal = -collision.contacts[0].normal.normalized;
                var dot = Vector3.Dot(normal, Vector3.back);
                if (dot >= .7f)
                    gameObject.SetActive(false);
            }
        }
    }
}