using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject deathChunkParticle,
        deathBloodParticle;


    public float currentHealth { get; set; }

    private GameManager GM;

    [SerializeField]
    private AudioSource dieSoundEffect;

    public bool isgettingHit { get; private set; }

    private void Awake()
    {

    }

    private void Start()
    {
        dieSoundEffect.Stop();
        currentHealth = maxHealth;
        isgettingHit = false;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (isgettingHit == true)
        {
            dieSoundEffect.Play();
        }
        isgettingHit = false;
    }

    public void DescreaseHealth(float amount)
    {
        currentHealth -= amount;
        isgettingHit = true;
        // Destroy(hearts[(int)currentHealth].gameObject);      

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            dieSoundEffect.Play();
            isgettingHit = false;
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        Destroy(gameObject);
        GM.Respawn();
    }
}
