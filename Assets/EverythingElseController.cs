using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EverythingElseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.7f;
        SoundManager.Instance.PlaySoundEffect("SillyButt", loop:true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
