using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthManager healthManager = other.GetComponent<HealthManager>();
            healthManager.scheduleInjury = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthManager healthManager = other.GetComponent<HealthManager>();
            healthManager.scheduleInjury = false;
        }
    }
}

