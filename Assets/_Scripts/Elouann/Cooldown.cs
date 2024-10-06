using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _beginTimerText;

    public static bool GameStarted;

    private void Start()
    {
        TrucsQuiTombentManager.Instance.GameRunning = false;
        _beginTimerText.text = 3.ToString();
        StartCoroutine(StartCooldown());
    }

    private IEnumerator StartCooldown()
    {
        for (int i = 3; i > 0; i--)
        {
            _beginTimerText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        _beginTimerText.text = "GO !";
        yield return new WaitForSeconds(1);
        _beginTimerText.gameObject.SetActive(false);
        TrucsQuiTombentManager.Instance.GameRunning = true;
        StartCoroutine(GetComponent<GameTimer>().Timer());
    }
}
