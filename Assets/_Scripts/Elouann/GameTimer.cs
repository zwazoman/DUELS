using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using DG.Tweening;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameTimer;

    private float _timer;

    private void Start()
    {
        _timer = 0;
        _gameTimer.text = null;
    }

    public IEnumerator StartTimer()
    {
        StartCoroutine(ScaleTimer());
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            _timer += 0.01f;
            _gameTimer.text = String.Format("{0:0.00}", _timer);
        }
    }

    private IEnumerator ScaleTimer()
    {
        while (true)
        {
        yield return new WaitForSeconds(10.01f);
        print("OY");
        _gameTimer.transform.DOScale(2, 0.2f).SetEase(Ease.InOutElastic);
        yield return new WaitForSeconds(0.2f);
        _gameTimer.transform.DOScale(1, 0.4f);
        }
    }
}
