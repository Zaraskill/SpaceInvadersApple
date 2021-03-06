﻿using System.Collections;
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
    public AudioClip enemyMovement;
    public AudioClip enemyShot;
    public AudioClip enemyDeath;
    public AudioClip pointWin;
    public AudioClip enemyChange;
    public List<AudioClip> enemyTrashtalk;

    [Header("Voices reactions")]
    public List<AudioClip> positivesFeedback;
    public List<AudioClip> negativesFeedback;

    private float pitchMin = 1f;
    private float pitchMax = 1f;
    private float timeLerp = 0f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        musicSource = gameObject.GetComponent<AudioSource>();
        musicSource.clip = music;
        musicSource.loop = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic();
    }

    void Update()
    {
        if(pitchMax > 1f)
        {
            timeLerp += Time.deltaTime *0.5f;
            musicSource.pitch = Mathf.Lerp(pitchMin, pitchMax, timeLerp);
        }        
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
        if (FeaturesManager.instance.feature3 % 2 == 0)
        {
            return;
        }
        int random = Random.Range(0, enemyTrashtalk.Count);
        Play(enemyTrashtalk[random]);
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

    public void IncreasePitch(float pitchToGo)
    {
        if (FeaturesManager.instance.feature7 % 2 == 0)
        {
            return;
        }
        pitchMin = pitchMax;
        pitchMax = pitchToGo;
        timeLerp = 0f;
    }

    public void PlayPositiveFeedbacks()
    {
        int random = Random.Range(0, positivesFeedback.Count);
        Play(positivesFeedback[random]);
    }

    public void PlayNegativeFeedbacks()
    {
        int random = Random.Range(0, negativesFeedback.Count);
        Play(negativesFeedback[random]);
    }
}
