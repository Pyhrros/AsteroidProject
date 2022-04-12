using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private GameOverBehavior gameOverBehavior;
    public void hit(){
        gameOverBehavior.endGame();
        gameObject.SetActive(false);
    }
}
