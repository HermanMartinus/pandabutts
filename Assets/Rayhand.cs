using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayhand : MonoBehaviour
{   
    public bool isLeft = false;
    public float climbStrength = 5;
    public float holdStamina = 10;
    public float armLength = 1;
    public float staminaDepletionRate = 0.1f;
    public bool handPumped = false;
    public Rigidbody2D rigidbody;
    public bool canGrip = false;
    public bool holding = false;
    bool prevHolding = false;
    Collider2D touchingArea;

    public Color start;
    public Color end;

    public HingeJoint2D hingeJoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Climbable" && !holding) {
            canGrip = true;
            touchingArea = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Climbable" && !holding) {
            canGrip = false;
            touchingArea = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = (isLeft ? -Input.GetAxis("LeftHorizontal") : -Input.GetAxis("RightHorizontal"));
        float vertical = (isLeft ? Input.GetAxis("LeftVertical") : -Input.GetAxis("RightVertical"));
        float angle = (Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg); 
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float magnitude = Mathf.Clamp01(new Vector2(horizontal, vertical).magnitude);
        if(magnitude > 0.1f){
            rigidbody.AddRelativeForce(Vector2.up * climbStrength);
        }
        GetComponent<SpringJoint2D>().distance = Mathf.Lerp(GetComponent<SpringJoint2D>().distance, magnitude*armLength, 10);

        if(!handPumped && canGrip) {
            if(Input.GetAxis("GripRight") > 0 && !isLeft) {
                holding = true;
            } else if(!isLeft) {
                holding = false;
            }
            if(Input.GetAxis("GripLeft") > 0 && isLeft) {
                holding = true;
                

            } else if(isLeft){
                holding = false;
            }
        } else {
            holding = false;
        }

        if(holding) {
            hingeJoint.enabled = true;
            hingeJoint.connectedBody = touchingArea.GetComponent<Rigidbody2D>();
            holdStamina -= staminaDepletionRate;
        } else {
            hingeJoint.enabled = false;
            hingeJoint.connectedBody = null;
            holdStamina += staminaDepletionRate;
        }

        if(prevHolding != holding){
            if(holding)
                SoundManager.Instance.PlaySoundEffect("Hold");
            prevHolding = holding;
        }
        
        if (holdStamina < 0) {
            handPumped = true;
            SoundManager.Instance.PlaySoundEffect("Ouch");
            StartCoroutine(RechargeHand());
        }
        if(holdStamina > 100) {
            holdStamina = 100;
        }
        GetComponent<SpriteRenderer>().color = Color.Lerp(end, start, holdStamina/100);
    }

    IEnumerator RechargeHand () {
        yield return new WaitForSeconds(3);
        handPumped = false;
    }
}
