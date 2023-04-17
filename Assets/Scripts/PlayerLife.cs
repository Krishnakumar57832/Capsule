using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathsound;
    bool dead = false;
    
    private void Update()
    {
        if (transform.position.y <= -2f && !dead)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }
    

    void Die() 
    {
        Invoke(nameof(Loadscene), 1.5f);
        dead= true;
        deathsound.Play();
    }

    void Loadscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}

