using UnityEngine;

public class EnemyController : MyCharacterController
{
    [SerializeField] private ParticleController deadParticlePrefab;
    [SerializeField] private float maxHealth;
    private float helth;

    private void Start()
    {
        //GameManager.Instance.isRun = true;
        GameManager.Instance.EnemyAmount++;
        helth = maxHealth;
    }
    private void FixedUpdate()
    {
        var player = PlayerController.Instance;
        var delta = -transform.position + player.transform.position;
        delta.y = 0;
        var direction = delta.normalized;
        Move(direction);
        transform.LookAt(player.transform);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.CompareTag("Bullet"))
        {
            TakeDamege(1);
            other.gameObject.SetActive(false);
            //gameObject.SetActive(false);
            Instantiate(deadParticlePrefab, other.transform.position, Quaternion.identity);
        }
        
    }
    public void TakeDamege(float damageAmount)
    {
        helth -= damageAmount;
        if(helth <= 8)
        {
            ChangeScale();
        }
        if (helth <= 0)
        {
            gameObject.SetActive(false);
            GameManager.Instance.EnemyDeadCounter++;
        }
    }
    public void ChangeScale()
    {
        transform.localScale -= new Vector3(0.25f, 0.25f, 0.25f);
        Vector3 pos = gameObject.transform.position;
        pos.y /= 2f;
        gameObject.transform.position = pos;
    }
}

