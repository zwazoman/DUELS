using System.Collections;
using TMPro;
using System;
using UnityEngine;
using DG.Tweening;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameTimer;

    private float _timer = 10;

    private void Start()
    {
        _gameTimer.text = null;
    }

    public IEnumerator Timer()
    {
        for (float i = _timer; i >= -0.01f; i -= 0.01f)
        {
            if (!TrucsQuiTombentManager.Instance.GameRunning) break;
            _timer = i;
            _gameTimer.text = String.Format("{0:0.00}", _timer);
            yield return new WaitForSeconds(0.01f);
            if (_timer <= 0)
            {
                Wobbling();
                TrucsQuiTombentManager.Instance.GameEnd();
            }
        }
    }

    public float GetTimer()
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
