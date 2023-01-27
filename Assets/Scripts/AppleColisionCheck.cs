using UnityEngine;

namespace BlockSnake
{
    public class AppleColisionCheck : MonoBehaviour
    {
        private void OnCollisionStay(Collision collision)
        {
            gameObject.SetActive(false);
        }
    }
}