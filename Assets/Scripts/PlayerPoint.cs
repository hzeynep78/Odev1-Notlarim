using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPoint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _text.text = score.totalscore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elmas"))
        {
            _audio.Play();
            Destroy(other.gameObject);
            score.totalscore++;
            _text.text = score.totalscore.ToString();
        }
    }
}

//private void OnTriggerEnter2D(Collider2D other)  (elmasa yazýlsaydý böyle yazýlacaktý)
//{
//    if (other.gameObject.CompareTag("Player"))
//    {
//        Destroy(gameObject);
//    }
//}
