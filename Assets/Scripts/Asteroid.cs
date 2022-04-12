using UnityEngine;

public class Asteroid : MonoBehaviour
{

    private float size = 6.0f;
    private float minSize = 1.5f;
    private Rigidbody rigidBody;
    private Camera mainCamera;

    private ScoreSystem score;
    
    void Awake() {
         rigidBody = this.GetComponent<Rigidbody>();
    }
    void Start(){
       mainCamera = Camera.main;
        this.transform.localScale = Vector3.one * this.size;
    }

    void Update(){
        rigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
        screenWrapAround();
    }

    private void OnTriggerEnter(Collider other) {
        HealthSystem health = other.GetComponent<HealthSystem>();

        if(health == null){
            return;
        }
        health.Hit();
        
    }

    /*private void OnBecameInvisible() {

        Destroy(gameObject);
    }*/

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Missile"){
            if(this.size * 0.5f >= this.minSize){
                InstantiateSplit();
                InstantiateSplit();
            }
            Destroy(this.gameObject);
        }
    }
    public void InstantiateSplit(){
       
        this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,10);
        Vector3 position = this.transform.position;
        Asteroid instance = Instantiate(this, position, Quaternion.Euler(0f,0f,Random.Range(10f,360f)));
        instance.size = this.size * 0.5f;
        instance.rigidBody.AddForce(Random.insideUnitCircle.normalized* 200);
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
}

