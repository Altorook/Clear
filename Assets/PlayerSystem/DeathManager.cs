using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] KillPlayer soKill;
    [SerializeField] GameObject deathText;
    void Start()
    {
        soKill.isPlayerDead = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if( soKill.isPlayerDead)
        {
            StartCoroutine(DeathSequence());
        }
    }
    IEnumerator DeathSequence()
    {
        deathText.SetActive(true);
        soKill.isPlayerDead = false;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Clear");

    }
}
