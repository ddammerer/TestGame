using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
private Transform playerPos;
    [SerializeField]private GameObject[] enemyPrefabs;

  

    private void Update() {
        playerPos = GameObject.FindGameObjectWithTag("SpawnPos").transform;
    }

   

    private void Awake() {
        Invoke("startroutine", 1f);
    }

    void startroutine() {
        StartCoroutine(Spawnroutine());
    }

    private IEnumerator Spawnroutine() {
        while (true) {
            yield return new WaitForSeconds(5f);
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], playerPos.position, playerPos.rotation);
        }
    }

}
