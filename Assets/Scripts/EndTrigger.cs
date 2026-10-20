using UnityEngine;
using UnityEngine.SceneManagement;
// When the player enters it, save the score and load the End scene.

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private string endSceneName = "EndScene";
    [SerializeField] private AudioClip PortalSound;
    public HealthManager health;
 
    private void OnTriggerEnter(Collider other)
    {
        // Only the player can finish the level
        if (!other.CompareTag("Player")) return;
 
        // Save the score BEFORE loading: the ScoreManager is about
        // to be destroyed together with the rest of SampleScene
        ScoreManager.Instance.SaveFinalScore();
        PlayPersistentSound(PortalSound);
        health.ChangeStage(endSceneName);
    }

    private void PlayPersistentSound(AudioClip clip)
    {
    GameObject soundObject = new GameObject("PortalSound");
    DontDestroyOnLoad(soundObject);

    AudioSource source = soundObject.AddComponent<AudioSource>();
    source.PlayOneShot(clip);

    Destroy(soundObject, clip.length);
    }
}
