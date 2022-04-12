using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{   
    [SerializeField]private float acceleration;
    private float duration = 5.0f;
    private Rigidbody missileBody;
    // Start is called before the first frame update
     private void Awake() {
        missileBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        missileBody.constraints = RigidbodyConstraints.FreezeRotationX;
        missileBody.constraints = RigidbodyConstraints.FreezeRotationY;
    }

    public void missileBehavior(Vector2 direction){
        missileBody.AddForce(direction * acceleration);
        Destroy(gameObject, duration);
    }

    private void OnCollisionEnter(Collision other) {
            Destroy(this.gameObject);    
        }

}
