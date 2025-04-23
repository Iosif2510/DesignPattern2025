using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] private KeyCode switchKey = KeyCode.F1;
    [SerializeField] private string targetScene;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            SceneManager.LoadScene(targetScene);
        }
    }
}
