using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            RecognizeCommand();
        }
    }

    IEnumerator SaveClip()
    {
        //wait for 1 sec
        yield return new WaitForSeconds(1.0f);
        //save audio file to Assets/player_command.wav
        SavWav.Save("player_command", myAudioClip);

        yield return null;
    }

    private string RecognizeCommand()
    {
        string filename = "player_command.wav";
        string command = "";
        Process process = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = "/C python abc.py " + Path.Combine(Application.dataPath, filename);
        process.StartInfo = startInfo;
        process.Start();
        process.WaitForExit();
        command = process.StandardOutput.ReadLine();

        return command;
    }
}