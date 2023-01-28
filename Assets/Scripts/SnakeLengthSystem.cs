using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace BlockSnake
{
    public class SnakeLengthSystem : MonoBehaviour
    {
        private float tailUpdateTime = .3f;

        [SerializeField] private float tailUpdateDisappearTickTime = .1f;
        [SerializeField]private int _snakeLength;
        [SerializeField] private int _startLength = 2;

        [SerializeField] private List<GameObject> _tailPartList = new();
        [SerializeField] private GameObject _headPart;
        [SerializeField] private TMP_Text _headText;


        private void Start()
        {
            _snakeLength = _startLength;
            StartCoroutine(ControlLength());
        }

        private void CheckLength()
        {
            _snakeLength = _headPart.GetComponent<SnakeTrigger>().GetSnakeTempLenght;
            _headText.text = Convert.ToString(_snakeLength);
            if (_snakeLength < 0) UnityEditor.EditorApplication.isPaused = true;
        }

        private IEnumerator ControlLength()
        {
            var currentLangth = 0;
            while (true)
            {
                CheckLength();
                if (currentLangth < _snakeLength)
                {
                    for (var i = currentLangth; i < _snakeLength; i++)
                    {
                        _tailPartList[i].SetActive(true);
                        currentLangth++;
                        yield return new WaitForSeconds(tailUpdateDisappearTickTime);
                    }
                }

                if (currentLangth > _snakeLength)
                {
                    for (var i = currentLangth; i >= _snakeLength; i--)
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