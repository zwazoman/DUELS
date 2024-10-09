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

    private static float _timer = 40;

    bool canScale = true;

    private void Start()
    {
        _gameTimer.text = null;
    }

    public IEnumerator Timer()
    {
        for (float i = _timer; i >= 0; i -= 0.01f)
        {
            if (!TrucsQuiTombentManager.Instance.GameRunning)
            {
                Wobbling();
                break;
            }
            _timer = i;
            _gameTimer.text = String.Format("{0:0.00}", _timer);
            yield return new WaitForSeconds(0.01f);
        }
        if (TrucsQuiTombentManager.Instance.GameRunning)
        _timer = 0;
        _gameTimer.text = String.Format("{0:0.00}", 0);
        TrucsQuiTombentManager.Instance.GameEnd();
    }

    public static float GetTimer()
    {
        return _timer;
    }

    #region Visual

    private void Wobbling()
    {
        this._gameTimer.fontSize = 90;
        this._gameTimer.gameObject.GetComponent<CharacterWobble>().enabled = true;
        StartCoroutine(Scaling(0.6f, true));
    }

    private IEnumerator Scaling(float scaleSpeed = 0.6f, bool loop = false)
    {
        while(true)
        {
            this._gameTimer.gameObject.transform.DOScale(1.2f, 0.6f).SetEase(Ease.InOutQuad);
            yield return new WaitForSeconds(0.5f);
            this._gameTimer.gameObject.transform.DOScale(1, 0.6f).SetEase(Ease.InOutQuad);
            yield return new WaitForSeconds(0.5f);
            if (!loop) break;
        }
    }
    #endregion
}
