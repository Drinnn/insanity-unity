using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AgentStepAudioPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private float pitchRandomness = 0.05f;
    [SerializeField] private AudioClip stepClip;

    private float basePitch;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        basePitch = _audioSource.pitch;
    }

    private void PlayClipWithVariablePitch(AudioClip clip)
    {
        var randomPitch = Random.Range(-pitchRandomness, pitchRandomness);

        _audioSource.pitch = basePitch + randomPitch;

        PlayClip(clip);
    }

    private void PlayClip(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void PlayStepSound()
    {
        PlayClipWithVariablePitch(stepClip);
    }

}
