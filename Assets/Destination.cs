using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destination : MonoBehaviour
{
    public GameObject canvas;
    public GameObject start;
    public GameObject end;

    public Text population;
    public static int populationCounter = 1864;

    public GameObject heartSystem;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Pandabutt"){
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            heartSystem.SetActive(true);
            // Destroy(GameObject.Find("SillyButtAudioSource"));
            SoundManager.Instance.PlaySoundEffect("SexySax");
            StartCoroutine(Steps());
        }
    }
    void Start() {
        // StartCoroutine(Steps());
    }
    IEnumerator Steps() {
        yield return new WaitForSeconds(1);
        canvas.GetComponent<Canvas>().enabled = true; 
        start.SetActive(false);
        end.SetActive(true);
        population.text = populationCounter.ToString();
        yield return new WaitForSeconds(2);
        populationCounter++;
        population.text = populationCounter.ToString();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Test");
    }
}
