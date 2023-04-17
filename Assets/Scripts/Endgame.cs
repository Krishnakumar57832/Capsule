using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
   public void Restartagain()
    { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2); 
    }
}
