using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Vector3 shootDir, forceBack, lastpos;
    public float shootForce = 10f, obsForce = 10f, wallForce = 5f, groundForce = 3f;
    private bool shoot;
    private Rigidbody rb;
    private bool PlayerCanHit;
    public UI ui;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        lastpos = this.transform.position;

        rb.isKinematic = true;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R)) {
            this.transform.position = lastpos;
            // rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.AddForce(-rb.velocity * rb.mass, ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            if(PlayerCanHit) {
                Debug.Log("HIT");
                if(rb.isKinematic) {
                    rb.isKinematic = false;
                }
                shootDir = Camera.main.transform.forward + new Vector3(0, 0.5f, 0);
                shoot = true;
            }  
        }
    }

    private void FixedUpdate() {
        if(shoot) {
            rb.AddForce(shootDir * shootForce, ForceMode.Impulse);
            shoot = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Obstacles") {
            // Debug.Log("Obstacle");
            rb.AddForce(other.contacts[0].normal * obsForce, ForceMode.Impulse);
        }

        if(other.gameObject.tag == "Wall") {
            // Debug.Log("Wall");
            rb.AddForce(other.contacts[0].normal * wallForce, ForceMode.Impulse);
            ui.AddScore();
        }

        if(other.gameObject.tag == "Ground") {
            // Debug.Log("Ground");
            rb.AddForce(other.contacts[0].normal * groundForce, ForceMode.Impulse);
            ui.DeductLife();
            ResetBall();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("ZoneBox")) {
            PlayerCanHit = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("ZoneBox")) {
            PlayerCanHit = false;
        }
    }

    private void ResetBall() {
        this.transform.position = lastpos;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.AddForce(-rb.velocity * rb.mass, ForceMode.Impulse);
    }
}
