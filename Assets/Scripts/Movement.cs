using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 200f;
    [SerializeField] AudioClip thrustAudio;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying) {
                audioSource.PlayOneShot(thrustAudio);
            } 
        } 
        else {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Rotate(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Rotate(-rotationThrust);
        }
    }

    void Rotate(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
