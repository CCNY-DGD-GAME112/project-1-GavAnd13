using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Main");
    }
}
