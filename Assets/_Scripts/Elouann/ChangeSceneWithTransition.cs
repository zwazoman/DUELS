using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithTransition : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    private BlackTransition _transitionScript;

    private void Start()
    {
        _transitionScript = GameObject.Find("Transition").GetComponent<BlackTransition>(); //connard
    }

    public async void ChangeScene()
    {
        _transitionScript.TransitionIn();
        await Task.Delay(1750);
        SceneManager.LoadScene(_sceneName);
    }
}