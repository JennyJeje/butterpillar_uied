using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour
{
    private ParticleSystem ps; 
    void Awake()
    {
        if (ps.isPlaying)
        {
            ps.Stop();
        }
    }
}
