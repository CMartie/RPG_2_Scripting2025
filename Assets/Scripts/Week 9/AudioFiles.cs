using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFiles : MonoBehaviour
{
    public AudioSource birdHit;
    public AudioSource birdAttack;
    public AudioSource catHit;
    public AudioSource catAttack;
    public AudioSource bugHit;
    public AudioSource bugAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BirdAttack()
    {
        birdAttack.Play();
    }

    public void BirdHit()
    {
        birdHit.Play();
    }

    public void CatAttack()
    {
        catAttack.Play();
    }

    public void CatHit()
    {
        catHit.Play();
    }

    public void BugAttack()
    {
        bugAttack.Play();
    }
    public void BugHit()
    {
        bugHit.Play();
    }
}
