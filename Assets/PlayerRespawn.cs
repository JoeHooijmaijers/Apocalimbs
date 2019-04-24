using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform player;
    public Vector3 spawnLocation;
    public Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
        spawnLocation = transform.position;
    }

    IEnumerator IESpawnPlayer()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(7);
        player.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().Respawn(spawnLocation);
        player.GetComponent<Combat>().FullHeal();
    }

    public void SpawnPlayer()
    {
        StartCoroutine(IESpawnPlayer());
    }
}
