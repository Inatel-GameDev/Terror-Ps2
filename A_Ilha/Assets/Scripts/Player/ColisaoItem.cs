using System;
using UnityEngine;

public class ColisaoItem : MonoBehaviour
{
    private Player _player;

    private void OnTriggerEnter(Collider item)
    {
        if (item.gameObject.CompareTag("item"))
        {
            item.gameObject.GetComponent<Item>().ativaImagem(true);
        }
    }
    

    private void OnTriggerStay(Collider item)
    {
        if (!item.gameObject.CompareTag("item")) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            _player.ItemAtual = item.gameObject.GetComponent<Item>();
        }
    }
    
    private void OnTriggerExit(Collider item)
    {
        if (item.gameObject.CompareTag("item"))
        {
            item.gameObject.GetComponent<Item>().ativaImagem(false);
        }
    }
}
