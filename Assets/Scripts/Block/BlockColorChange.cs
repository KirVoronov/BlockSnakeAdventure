using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace BlockSnake
{
    public class BlockColorChange : MonoBehaviour
    {
        private float _colorNum = 10f;
        private float _colorModif = 8.5f;
        private Renderer _renderer;


        [SerializeField] private TMP_Text _text;

        void Start()
        {
            _renderer = GetComponent<Renderer>();
            _colorNum = Int32.Parse(_text.text);
            StartCoroutine(ChangeColor());
        }

        private IEnumerator ChangeColor()
        {
            while (true)
            {
                var tempColor = _colorNum * _colorModif;
                _renderer.material.color = new Color(tempColor/255f, 125f/255f, 50f / 255f);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}