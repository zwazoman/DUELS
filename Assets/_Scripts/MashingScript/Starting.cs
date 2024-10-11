using System.Collections;
using UnityEngine;
using TMPro;

public class Starting : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _beginTimerText;

    [field: SerializeField] public bool GameStarted { get; set; }

    private void Start()
    {
        GameStarted = false;
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
        GameStarted = true;
    }
}
