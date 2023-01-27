using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSnake
{
    public class SnakePool : MonoBehaviour
    {
        private float tailUpdateTime = 1f;
        [SerializeField] private float tailUpdateDisappearTickTime = .1f;
        [SerializeField]private int snakeLangth;

        [SerializeField] private List<GameObject> _tailPartList = new();
        [SerializeField] private int _startLangth = 2;



        private void Start()
        {
            snakeLangth = _startLangth;
            StartCoroutine(ControlLangth());
        }

        private IEnumerator ControlLangth()
        {
            var currentLangth = 0;
            while (true)
            {
                if (currentLangth < snakeLangth)
                {
                    for (var i = currentLangth; i < snakeLangth; i++)
                    {
                        _tailPartList[i].SetActive(true);
                        currentLangth++;
                        yield return new WaitForSeconds(tailUpdateDisappearTickTime);
                    }
                }

                if (currentLangth > snakeLangth)
                {
                    for (var i = currentLangth; i >= snakeLangth; i--)
                    {
                        _tailPartList[i].SetActive(false);
                        currentLangth--;
                        yield return new WaitForSeconds(tailUpdateDisappearTickTime);
                    }
                }

                yield return new WaitForSecondsRealtime(tailUpdateTime);
            }
        }
    }
}