using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetValueAudio : MonoBehaviour
{
    private AudioMixer audioMixer;
    private Slider scroller;
    private const float disableVolume = -80f;
    private const float minimumVolume = -30f;
    [SerializeField]
    private string nameGroups;
    private void Start()
    {
        audioMixer = FindObjectOfType<AudioManager>().audioMixer;
        scroller = GetComponent<Slider>();
    }
    public void SetVolume()
    {
        float volumeValue = Mathf.Lerp(minimumVolume,0,scroller.value);
        if(scroller.value == 0f)
            audioMixer.SetFloat(nameGroups,disableVolume);
        else
        {

            audioMixer.SetFloat(nameGroups,volumeValue);
        }
    }
}
