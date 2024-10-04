using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameTimer;

    private float _timer;

    bool canScale = true;

    private void Start()
    {
        _timer = 0;
        _gameTimer.text = null;
    }

    public IEnumerator StartTimer()
    {
        //StartCoroutine(ScaleTimer());
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            //if(Mathf.Round(_timer) % 10 == 0) StartCoroutine(Scale());
            _timer += 0.01f;
            _gameTimer.text = String.Format("{0:0.00}", _timer);
        }
    }

    private IEnumerator ScaleTimer()
    {
        while (true)
        {
        yield return new WaitForSeconds(10.75f);
        print("OY" + _timer.ToString());
        _gameTimer.transform.DOScale(2, 0.2f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);
        _gameTimer.transform.DOScale(1, 0.4f);
        }
    }

    private IEnumerator Scale()
    {
        if (canScale)
        {
            canScale = false;
            print(_timer);
            _gameTimer.transform.DOScale(2, 0.2f).SetEase(Ease.OutBack);
            yield return new WaitForSeconds(0.2f);
            _gameTimer.transform.DOScale(1, 0.4f);
            canScale = true;
        }
    }
}
