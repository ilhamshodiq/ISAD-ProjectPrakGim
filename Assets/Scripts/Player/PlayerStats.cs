using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool isMintaRestart { get; set; }

    private void Awake()
    {
    }

    private void Start()
    {
        isMintaRestart = false;

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
            isMintaRestart = true;
            Die();
            //get current scene
            dieSoundEffect.Play();
            // Scene scene = SceneManager.GetActiveScene();
            // //load scene
            // SceneManager.LoadScene(scene.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            isMintaRestart = true;
            dieSoundEffect.Play();
            isgettingHit = false;
            Die();
            // Scene scene = SceneManager.GetActiveScene();
            // //load scene
            // SceneManager.LoadScene(scene.name);
        }
    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        Destroy(gameObject);
        // GM.Respawn();
    }
}
