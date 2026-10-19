using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    [SerializeField] private int health = 3;
    [SerializeField] public bool scheduleInjury = false;
    [SerializeField] private bool recentlyInjured = false;
    [SerializeField] private GameObject healthIcon;
    [SerializeField] private Image healthBackground;
    [SerializeField] public String stageName = "FirstStage";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBackground.fillAmount = (1 - (health / 3));

        if (recentlyInjured)
        {
            scheduleInjury = false;
        }
        if (scheduleInjury)
        {
            Injure();
            scheduleInjury = false;
        }

        if (health == 0)
        {
            health = 3;
            Die();
        }
    }

    private IEnumerator Injure()
    {
        recentlyInjured = true;
        health--;
        yield return new WaitForSeconds(0.5f); // 500ms of invulnerability
        recentlyInjured = false;
    }

    private void Die()
    {
        ScoreManager.Instance.restartScore();
        ChangeStage(stageName);
    }

    public void ChangeStage(String newStage)
    {
        stageName = newStage;
        SceneManager.LoadScene(newStage);
    }


}

