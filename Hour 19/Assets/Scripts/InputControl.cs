using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InputControl : MonoBehaviour
{
    PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (director.state == PlayState.Paused)
            {
                director.Play();
            } else
            {
                director.Stop();
            }
        }
    }
}
