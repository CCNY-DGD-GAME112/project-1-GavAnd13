using TMPro;
using UnityEngine;

public class LossManager : MonoBehaviour
{
    public AudioClip explosionClip;
    public AudioSource explosionAudio;

    public TextMeshProUGUI scoreText;
    void Start()
    {
        explosionAudio.clip = explosionClip;
        explosionAudio.Play();

        scoreText.text = $"Your score: {GameManager.o2Generated}!";
    }
}
