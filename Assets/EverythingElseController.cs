using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EverythingElseController : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.7f;
        SoundManager.Instance.PlaySoundEffect("SillyButt", loop:true);
    }

    void ChangeTarget() {
        GetComponent<Follow>().target = target2;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("joystick 1")) {
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
            GetComponent<Follow>().target = target1;
            Invoke("ChangeTarget", 4);
        }
    }
}
