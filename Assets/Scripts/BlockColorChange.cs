using System;
using System.Collections;
using TMPro;
using UnityEngine;


namespace BlockSnake
{
    public class BlockColorChange : MonoBehaviour
    {
        private float _colorNum = 10f;
        private float _colorModif = 4f;
        private Renderer _renderer;


        [SerializeField] private TMP_Text _text;

        void Start()
        {
            _renderer = GetComponent<Renderer>();
            _text = GetComponentInChildren<TMP_Text>();
            _colorNum = Single.Parse(_text.text);
            //StartCoroutine(ChangeColor());
        }

        private IEnumerator ChangeColor()
        {
            while (true)
            {
                var tempColor = _colorNum; //* _colorModif;
                Debug.Log(tempColor);
                _renderer.material.color = new Color(tempColor, .125f, .50f);
                yield return new WaitForFixedUpdate();
            }
        }

}
}