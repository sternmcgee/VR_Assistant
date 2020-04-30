using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMicListener : MonoBehaviour
{
    AudioClip myAudioClip;

    void Start() { }
    void Update() { }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 60, 50), "Record & Save"))
        {
            //record 1 sec audio clip
            myAudioClip = Microphone.Start(null, false, 1, 44100);
            StartCoroutine(SaveClip());
        }
    }

    IEnumerator SaveClip()
    {
        //wait for 1 sec
        yield return new WaitForSeconds(1.0f);
        //save audio file to Assets/player_command.wav
        SavWav.Save("player_command", myAudioClip);
    }
}