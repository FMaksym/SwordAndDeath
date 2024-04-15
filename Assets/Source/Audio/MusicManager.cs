using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _musicClips;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        PlayRandomMusic();
    }

    private void FixedUpdate()
    {
        if (!_audioSource.isPlaying)
        {
            PlayRandomMusic();
        }
    }

    private void PlayRandomMusic()
    {
        if (_musicClips.Count > 0)
        {
            int randomIndex = Random.Range(0, _musicClips.Count);
            AudioClip randomClip = _musicClips[randomIndex];
            _audioSource.clip = randomClip;
            _audioSource.Play();
        }
    }
}
