using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Source")]
    public AudioSource source;
    public AudioSource source_1;
    public AudioSource source_2;

    [Header("Audio Clips")]
    public AudioClip bakcgroundAudio;
    public AudioClip footStape;
    public AudioClip[] announcement;
    public AudioClip[] exitAnnouncement;

    [Header("Wait Time")]
    public float delayTimeEnter = 0.5f;
    public float dealyTimeExit = 0.5f;
    private void Start()
    {
        instance = this;
        StartCoroutine(callAnnouncemet());
        hitToPlay();
    }

    public void Update()
    {
        if (Vehicle.instance.PerfectTextPopUp && Input.GetMouseButtonUp(0)) 
        {
            StartCoroutine(callExitAnnouncemet());
        }
    }
    public void hitToPlay()
    {
        source_1.clip = null;
        source_1.clip = bakcgroundAudio;
        source_1.Play();
    }

    public IEnumerator footStapeClip()
    {
        yield return new WaitForSeconds(0f);
        source_2.clip = null;
        source_2.clip = footStape;
        source_2.Play();
    }

    IEnumerator callAnnouncemet()
    {
        yield return new WaitForSeconds(delayTimeEnter);
        int audioClip = Random.Range(0, 3);
        source.clip = null;
        source.clip = announcement[audioClip];
        source.Play();
    }
    IEnumerator callExitAnnouncemet()
    {
        yield return new WaitForSeconds(dealyTimeExit);
        int audioClip = Random.Range(0, 2);
        source.clip = null;
        source.clip = exitAnnouncement[audioClip];
        source.Play();
    }
}
