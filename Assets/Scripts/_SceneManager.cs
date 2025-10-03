using UnityEngine;
using UnityEngine.SceneManagement;
public class _SceneManager : MonoBehaviour
{
    public void nextScene()
    {
        SceneManager.LoadScene(1);
    }
}
