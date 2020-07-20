using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SessionController : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float timeLeft = 60f;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft >= 0f) {
            timeLeft -= Time.deltaTime;
            UpdateTimerText();
        } else {
            SceneManager.LoadScene("TimeIsOver");
		}
    }

    private void UpdateTimerText() {
        float minutes = timeLeft / 60;
        float seconds = timeLeft % 60;
        if (seconds > 59) {
            seconds = 59;
		}
        timerText.text = string.Format("{0:00}:{1:00}", (int)minutes, Mathf.Round(seconds));

        if (timeLeft <= 20f) {
            timerText.color = new Color32(200, 10, 10, 255);
        }
	}
}
