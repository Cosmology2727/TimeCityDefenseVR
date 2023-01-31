using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCall : MonoBehaviour
{
    public AudioSource AudSource;

    [SerializeField]
    public int HowMany;

    [System.NonSerialized]
    public int ThisChoice;

    [SerializeField]
    public AudioClip ThisSFX1;
    [SerializeField]
    public AudioClip ThisSFX2;
    [SerializeField]
    public AudioClip ThisSFX3;
    [SerializeField]
    public AudioClip ThisSFX4;
    [SerializeField]
    public AudioClip ThisSFX5;



    void Start()
    {
        ThisChoice = (Random.Range(1, HowMany + 1));
        if (ThisChoice == 1)
        {
            AudSource.PlayOneShot(ThisSFX1);
        }
        else if (ThisChoice == 2)
        {
            AudSource.PlayOneShot(ThisSFX2);
        }
        else if (ThisChoice == 3)
        {
            AudSource.PlayOneShot(ThisSFX3);
        }
        else if (ThisChoice == 4)
        {
            AudSource.PlayOneShot(ThisSFX4);
        }
        else if (ThisChoice == 5)
        {
            AudSource.PlayOneShot(ThisSFX5);
        }
    }

    void Update()
    {
        
    }
}
