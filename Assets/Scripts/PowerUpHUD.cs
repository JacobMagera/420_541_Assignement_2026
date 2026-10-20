using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI; // TMP_Text

// Shows the speed boost icon and seconds left while the boost is on.
public class PowerUpHUD : MonoBehaviour
{
    [SerializeField] private PlayerPowerUps powerUps;
    [SerializeField] private GameObject speedIndicator; // icon + time
    [SerializeField] private GameObject speedIcon; // only icon
    [SerializeField] private Image speedClockIcon;
    [SerializeField] private GameObject jumpIndicator; // icon + time
    [SerializeField] private GameObject jumpIcon; // only icon
    [SerializeField] private Image jumpClockIcon;
    [SerializeField] private GameObject scoreIndicator; // icon + time
    [SerializeField] private GameObject scoreIcon; // only icon
    [SerializeField] private Image scoreClockIcon;
    [SerializeField] private TMP_Text speedTimeText;
    [SerializeField] private TMP_Text jumpTimeText;
    [SerializeField] private TMP_Text scoreTimeText;

    private bool speedIsBlinking = false;
    private Coroutine speedBlinkCoroutine;
    private bool jumpIsBlinking = false;
    private Coroutine jumpBlinkCoroutine;
    private bool scoreIsBlinking = false;
    private Coroutine scoreBlinkCoroutine;

    private void Update()
    {
        float speedTimeLeft = powerUps.SpeedTimeLeft;

        // Changing the icon fill?
        speedClockIcon.fillAmount = (1 - (1 * speedTimeLeft / 5f));

        // Visible for the whole boost, hidden the rest of the time
        if (speedTimeLeft <= 0f)
        {
            StopSpeedBlinking();
            speedIndicator.SetActive(false);
        } else if (speedTimeLeft <= 3f)
        {
            if (!speedIsBlinking)
            {
                speedBlinkCoroutine = StartCoroutine(SpeedBlinkSequence());
            }
        }
        else
        {
            StopSpeedBlinking();
            speedIndicator.SetActive(true);
        }

        // CeilToInt rounds 6.2 up to 7, so we never show 0s too early
        speedTimeText.text = Mathf.CeilToInt(speedTimeLeft) + "s";

        float jumpTimeLeft = powerUps.JumpTimeLeft;

        // Changing the icon fill?
        jumpClockIcon.fillAmount = (1 - (1 * jumpTimeLeft / 30f));

        // Visible for the whole boost, hidden the rest of the time
        if (jumpTimeLeft <= 0f)
        {
            StopJumpBlinking();
            jumpIndicator.SetActive(false);
        }
        else if (jumpTimeLeft <= 3f)
        {
            if (!jumpIsBlinking)
            {
                jumpBlinkCoroutine = StartCoroutine(JumpBlinkSequence());
            }
        }
        else
        {
            StopJumpBlinking();
            jumpIndicator.SetActive(true);
        }

        // CeilToInt rounds 6.2 up to 7, so we never show 0s too early
        jumpTimeText.text = Mathf.CeilToInt(jumpTimeLeft) + "s";


        //

        float scoreTimeLeft = powerUps.ScoreTimeLeft;

        // Changing the icon fill?
        scoreClockIcon.fillAmount = (1 - (1 * scoreTimeLeft / 10f));

        // Visible for the whole boost, hidden the rest of the time
        if (scoreTimeLeft <= 0f)
        {
            StopScoreBlinking();
            scoreIndicator.SetActive(false);
        }
        else if (scoreTimeLeft <= 3f)
        {
            if (!scoreIsBlinking)
            {
                scoreBlinkCoroutine = StartCoroutine(ScoreBlinkSequence());
            }
        }
        else
        {
            StopScoreBlinking();
            scoreIndicator.SetActive(true);
        }

        // CeilToInt rounds 6.2 up to 7, so we never show 0s too early
        scoreTimeText.text = Mathf.CeilToInt(scoreTimeLeft) + "s";
    }

    private IEnumerator SpeedBlinkSequence()
    {
        speedIsBlinking = true;

        while (speedIsBlinking)
        {
            speedIcon.SetActive(false);
            yield return new WaitForSeconds(0.25f);

            speedIcon.SetActive(true);
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void StopSpeedBlinking()
    {
        if (speedIsBlinking)
        {
            speedIsBlinking = false;
            if (speedBlinkCoroutine != null)
            {
                StopCoroutine(speedBlinkCoroutine);
            }
        }
    }

    private IEnumerator JumpBlinkSequence()
    {
        jumpIsBlinking = true;

        while (jumpIsBlinking)
        {
            jumpIcon.SetActive(false);
            yield return new WaitForSeconds(0.25f);

            jumpIcon.SetActive(true);
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void StopJumpBlinking()
    {
        if (jumpIsBlinking)
        {
            jumpIsBlinking = false;
            if (jumpBlinkCoroutine != null)
            {
                StopCoroutine(jumpBlinkCoroutine);
            }
        }
    }

    private IEnumerator ScoreBlinkSequence()
    {
        scoreIsBlinking = true;

        while (scoreIsBlinking)
        {
            scoreIcon.SetActive(false);
            yield return new WaitForSeconds(0.25f);

            scoreIcon.SetActive(true);
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void StopScoreBlinking()
    {
        if (scoreIsBlinking)
        {
            scoreIsBlinking = false;
            if (scoreBlinkCoroutine != null)
            {
                StopCoroutine(scoreBlinkCoroutine);
            }
        }
    }
}
