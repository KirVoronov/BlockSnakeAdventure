using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using static BlockSnake.TopScoreHelper;

namespace BlockSnake
{
    public class SnakeLengthSystem : MonoBehaviour
    {
        private float tailUpdateTime = .3f;
        private int _tailLangthModif = 2;

        [SerializeField] private float tailUpdateDisappearTickTime = .1f;
        [SerializeField] private int _snakeLength;
        [SerializeField] private int _startLength = 2;

        [SerializeField] private List<GameObject> _tailPartList = new();
        [SerializeField] private GameObject _headPart;
        [SerializeField] private TMP_Text _headText;
        [SerializeField] private GameObject _mainMenu;


        private void Start()
        {
            _snakeLength = _startLength;
            StartCoroutine(ControlLength());
        }

        private void CheckLength()
        {
            var _snakeLengthTemp = _headPart.GetComponent<SnakeTrigger>().GetSnakeTempLenght;

            _snakeLength = _snakeLengthTemp / _tailLangthModif;
            _headText.text = Convert.ToString(_snakeLengthTemp);

            if (_snakeLength > 44) _tailLangthModif = 4;
            if (_snakeLengthTemp <= 0)
            {
                if (Score.Self.GetScore > 0)
                {
                    LastScore s = new LastScore(Score.Self.GetScore);
                    TopScoreHelper.AllScores.Add(s);
                    var serialized = JsonConvert.SerializeObject(TopScoreHelper.AllScores);
                    using (StreamWriter writer = new StreamWriter(TopScoreHelper.FilePath))
                    {
                        writer.WriteLine(serialized);
                    }
                    CanUpdateScore = true;
                }

                _mainMenu.SetActive(true);
                Time.timeScale = 0.001f;
            }
        }

        private IEnumerator ControlLength()
        {
            var currentLangth = 0;
            while (true)
            {
                CheckLength();
                if (currentLangth < 0) currentLangth = 0;
                Debug.Log(currentLangth + " " + _snakeLength);
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