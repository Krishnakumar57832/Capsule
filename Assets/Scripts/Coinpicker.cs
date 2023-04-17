using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coinpicker : MonoBehaviour
{
    int coin = 0;

    [SerializeField] Text coinstext;

    [SerializeField] AudioSource coinsound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CoinPicker"))
        {
            Destroy(other.gameObject);
            coin++;
            coinstext.text = "coins : " + coin;
            coinsound.Play();
        }
    }
}
