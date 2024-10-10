using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackTransition : MonoBehaviour
{
    private float _radius = 100f;
    private Image _circle;

    public bool IsAnimating { get; set; }

    [SerializeField] private AnimationCurve _animCurveIn;
    [SerializeField] private AnimationCurve _animCurveOut;

    //// Singleton
    //#region Singleton

    //private static BlackTransition _instance;

    //public static BlackTransition Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //            Debug.Log("TrucsQuiTombentManager is null");
    //        return _instance;
    //    }
    //}

    //private void Awake()
    //{
    //    if (_instance != null)
    //    {
    //        Destroy(this.gameObject);
    //        Debug.Log($"<color=#e655c4>{this.name}</color> instance <color=#eb624d>destroyed</color>");
    //    }
    //    else
    //    {
    //        _instance = this;
    //        Debug.Log($"<color=#e655c4>{this.name}</color> instance <color=#58ed7d>created</color>");
    //    }
    //}
    //#endregion

    private void Start()
    {
        _circle = GetComponent<Image>();    
    }

    private void Update()
    {
        if (!IsAnimating) return;
        _circle.rectTransform.sizeDelta = new Vector2(_radius, _radius);
    }

    /// <summary>
    /// Remove the black screen with a little pop-out animation (1 second).
    /// </summary>
    public void TransitionOut()
    {
        StartCoroutine(TransiOut());
    }

    /// <summary>
    /// Cover the screen with black in a little cartoonish pop-in animation (1.5 seconds). 
    /// </summary>
    public void TransitionIn()
    {
        StartCoroutine(TransiIn());
    }

    #region Coroutines
    public IEnumerator TransiIn()
    {
        IsAnimating = true;
        _circle.enabled = true;
        float t = 0.01f;
        while (t <= _animCurveIn.length)
        {
            _radius = _animCurveIn.Evaluate(t);
            t += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        IsAnimating = false;
    }

    public IEnumerator TransiOut()
    {
        IsAnimating = true;
        float t = 0.01f;
        while (t <= _animCurveOut.length)
        {
            _radius = _animCurveOut.Evaluate(t);
            t += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        _circle.enabled = false;
        IsAnimating = false;
    }
    #endregion
}
