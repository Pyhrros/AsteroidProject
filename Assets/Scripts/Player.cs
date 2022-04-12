using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Missile missileConstruct;
    private Camera mainCamera;
    private Rigidbody playerBody;
    private float shootCount;

    private Vector3 direction;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField]private float shootRate;
    

    void Start()
    {
        mainCamera = Camera.main;
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        
       processInput();
       screenWrapAround();
       shipRotation();
    }

    void FixedUpdate() {
        if(direction == Vector3.zero){
            return;
        }
        playerBody.AddForce(direction*acceleration,ForceMode.Force);
        //playerBody.AddTorque(direction*acceleration,ForceMode.Force);
        playerBody.velocity = Vector3.ClampMagnitude(playerBody.velocity,maxSpeed);
        
    }

    void LateUpdate()
 {
     transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
 }
    private void processInput(){
     if(Touchscreen.current.primaryTouch.press.isPressed){

            Vector2 position = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(position);

            direction = worldPosition - transform.position;

            direction.z = 0f;

            direction.Normalize();

            if(shootCount == shootRate){
                shoot();
                shootCount = 0;
            }else{
                shootCount++;
            }
        }else {
            direction = Vector3.zero;
        }
    }
    private void screenWrapAround(){
        Vector3 newPosition = transform.position;
        Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);

        if(viewPortPosition.x > 1){
            newPosition.x = -newPosition.x + 0.1f;
        }else if(viewPortPosition.x < 0 ){
            newPosition.x = -newPosition.x - 0.1f;
        }
        if(viewPortPosition.y > 1){
            newPosition.y = -newPosition.y + 0.1f;
        }else if(viewPortPosition.y < 0 ){
            newPosition.y = -newPosition.y - 0.1f;
        }
        transform.position = newPosition;
    }

    private void shipRotation(){

        if(playerBody.velocity == Vector3.zero){
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(playerBody.velocity,Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,rotationSpeed*Time.smoothDeltaTime);
    }
    

    private void shoot(){
        Missile missile = Instantiate(this.missileConstruct,this.transform.position,Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
        missile.missileBehavior(this.direction);
    }
}
