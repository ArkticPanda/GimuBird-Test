using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightSound : MonoBehaviour
{
    public AudioClip clickSound; // Assign your sound clip in the Unity editor
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component to this GameObject and get reference to it
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clickSound;
    }

    void Update()
    {
        // Check if the mouse button is pressed
        if (Input.GetMouseButtonDown(0)) // 0 for left mouse button, 1 for right mouse button, 2 for middle mouse button
        {
            // Play the assigned sound clip
            audioSource.Play();
        }
    }
}
