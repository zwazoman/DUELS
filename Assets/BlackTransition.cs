using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackTransition : MonoBehaviour
{
    private float _radius = 100f;
    private Image _circle;

    [SerializeField] private AnimationCurve _animCurveIn;
    [SerializeField] private AnimationCurve _animCurveOut;

    private void Start()
    {
        _circle = GetComponent<Image>();    
    }

    private void Update()
    {
       _circle.rectTransform.sizeDelta = new Vector2(_radius, _radius);
    }

    public void TransitionOut()
    {
        StartCoroutine(TransiOut());
    }

    public void TransitionIn()
    {
        StartCoroutine(TransiIn());
    }

    public IEnumerator TransiIn()
    {
        float t = 0.01f;
        while (t <= _animCurveIn.length)
        {
            _radius = _animCurveIn.Evaluate(t);
            t += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator TransiOut()
    {
        float t = 0.01f;
        while (t <= _animCurveOut.length)
        {
            _radius = _animCurveOut.Evaluate(t);
            t += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
