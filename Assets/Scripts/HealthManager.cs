using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    [SerializeField] private int health = 3;
    public bool scheduleInjury = false;
    [SerializeField] private bool recentlyInjured = false;
    [SerializeField] private GameObject healthIcon;
    [SerializeField] private Image healthBackground;
    [SerializeField] public String stageName = "FirstStage";
    private Coroutine injureCoroutine;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBackground.fillAmount = (1f - (health / 3f));

        if (scheduleInjury && !recentlyInjured)
        {
            injureCoroutine = StartCoroutine(Injure());
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
        Debug.Log("You hit a trap! Health: " + health);
        yield return new WaitForSeconds(1f); // 1s of invulnerability
        recentlyInjured = false;
    }

    public void Die()
    {
        ScoreManager.Instance.restartScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeStage(String newStage)
    {
        stageName = newStage;
        SceneManager.LoadScene(newStage);
    }


}

