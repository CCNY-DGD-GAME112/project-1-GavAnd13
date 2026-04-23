using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.o2Generated = 0;
        SceneManager.LoadScene("Main");
    }
}
