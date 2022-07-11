using UnityEngine;
using UnityEngine.AI;

public class AlienController : MonoBehaviour
{
    static Transform playerTransform;
    static GameController gameController;
  
    NavMeshAgent alien;

    void SetDestination()
    {
        Vector3 playerPosition = new(playerTransform.position.x, transform.position.y, playerTransform.position.z);
        transform.LookAt(playerPosition);
        alien.SetDestination(playerTransform.position);
    }

    private void Awake()
    {
        alien = GetComponent<NavMeshAgent>();
        if (playerTransform == null) playerTransform = GameObject.Find("OVRPlayerController").transform;
        if (gameController == null) gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Start()
    {
        SetDestination();
    }

    private void Update()
    {
        SetDestination();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Power"))
        {
            Destroy(transform.gameObject);
            gameController.score += 1;
            gameController.setCurrentLevelEnemies(gameController.GetCurrentLevelEnemies()+1);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            if (gameController.life > 0) gameController.life -= 1;
        }
    }
}
