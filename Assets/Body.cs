using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        SoundManager.Instance.PlaySoundEffect("Ouch");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
