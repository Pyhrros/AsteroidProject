using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private GameOverBehavior gameOverBehavior;
    public void Hit(){
        gameOverBehavior.EndGame();
        gameObject.SetActive(false);
    }
}
