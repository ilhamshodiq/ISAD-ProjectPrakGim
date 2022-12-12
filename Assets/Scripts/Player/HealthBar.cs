using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerHealth;

    [SerializeField]
    public GameObject[] hearts;


    private void Awake()
    {
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(true);
        }
        hearts[0] = GameObject.Find("Heart1");
        hearts[1] = GameObject.Find("Heart2");
        hearts[2] = GameObject.Find("Heart3");
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(true);
        }

    }
    void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        }
        hearts[0] = GameObject.Find("Heart1");
        hearts[1] = GameObject.Find("Heart2");
        hearts[2] = GameObject.Find("Heart3");
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealth.isgettingHit == true)
        {
            hearts[(int)playerHealth.currentHealth].SetActive(false);
        }
    }
}
