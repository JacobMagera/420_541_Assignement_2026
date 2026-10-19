using UnityEngine;

// Gives the player a speed boost for a limited time.
public class PlayerPowerUps : MonoBehaviour
{
    [SerializeField] private float speedBoostMultiplier = 1.5f; // 50% faster
    [SerializeField] private int scoreMultiplier = 2;

    // Seconds of boost left. The HUD reads it; only this script changes it.
    public float SpeedTimeLeft { get; private set; }
    public float JumpTimeLeft { get; private set; }
    public float ScoreTimeLeft { get; private set; }

    private PlayerMovement movement;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    // Called by the pickup. Collecting another boost restarts the timer.
    public void ActivateSpeedBoost(float duration)
    {
        SpeedTimeLeft = duration;
        movement.SpeedMultiplier = speedBoostMultiplier;
    }

    public void ActivateJumpBoost(float duration)
    {
        JumpTimeLeft = duration;
        movement.DoubleJumpActive = true;
    }

    public void ActivateScoreBoost(float duration)
    {
        ScoreTimeLeft = duration;
        ScoreManager.Instance.multiplier = scoreMultiplier;
    }

    private void Update()
    {

        if (SpeedTimeLeft > 0f)
        {

            SpeedTimeLeft -= Time.deltaTime;

            if (SpeedTimeLeft <= 0f)
            {
                movement.SpeedMultiplier = 1f; // back to normal speed
            }
        }

        if (JumpTimeLeft > 0f)
        {

            JumpTimeLeft -= Time.deltaTime;

            if (JumpTimeLeft <= 0f)
            {
                movement.DoubleJumpActive = false; // back to normal speed
            }
        }

        if (ScoreTimeLeft > 0f)
        {

            ScoreTimeLeft -= Time.deltaTime;

            if (ScoreTimeLeft <= 0f)
            {
                ScoreManager.Instance.multiplier = 1; // back to normal speed
            }
        }
    }
}
