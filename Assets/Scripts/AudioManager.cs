using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip music;
    private AudioSource musicSource;

    [Header("Sounds")]
    public AudioClip playerMovement;
    public AudioClip playerShot;
    public AudioClip playerSpawn;
    public AudioClip playerDeath;
    public AudioClip playerTrashTalk;
    public AudioClip enemyTrashtalk;
    public AudioClip enemyMovement;
    public AudioClip enemyShot;
    public AudioClip enemyDeath;
    public AudioClip pointWin;
    public AudioClip enemyChange;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = music;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic();
    }

    private void Play(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void PlayPlayerShot()
    {
        Play(playerShot);
    }

    public void PlayPlayerSpawn()
    {
        Play(playerSpawn);
    }

    public void PlayPlayerDeath()
    {
        Play(playerDeath);
    }

    public void PlayPlayerMovement()
    {
        Play(playerMovement);
    }

    public void PlayPlayerThrash()
    {
        Play(playerTrashTalk);
    }

    public void PlayEnemyTrash()
    {
        Play(enemyTrashtalk);
    }

    public void PlayEnemyMovement()
    {
        Play(enemyMovement);
    }

    public void PlayEnemyShot()
    {
        Play(enemyShot);
    }

    public void PlayEnemyDeath()
    {
        Play(enemyDeath);
    }

    public void PlayPointWin()
    {
        Play(pointWin);
    }

    public void PlayEnemyChange()
    {
        Play(enemyChange);
    }
}
