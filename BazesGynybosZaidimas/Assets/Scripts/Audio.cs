using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Your audio clip
    public AudioClip MusicClipEnd;

    // the component that Unity uses to play your clip
    public AudioSource MusicSourceEnd;

    // Use this for initialization
    void Start()
    {
        MusicSourceEnd.clip = MusicClipEnd;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Ending.IsDead)
        {
           
            Debug.Log("tue if");//test
            MusicSourceEnd.Play();
            Ending.IsDead = false;
        }

    }
}
