﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject rat;
    public GameObject ratSpawn;
    public float ratsSpawnRate = 15.0f;
    public bool canSpawn = true;

    private float ratsSpawnTimer = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        ratsSpawnTimer = ratsSpawnRate;
        SpawnFirstMonsters();
    }

    // Update is called once per frame
    void Update()
    {
        if(ratsSpawnTimer <= 0.0f && canSpawn) {
            Instantiate(rat, ratSpawn.transform.position, Quaternion.identity)
            .transform.SetParent(ratSpawn.transform);

            ratsSpawnTimer = ratsSpawnRate;
        }

        UpdateTimers();
    }

    public void SetRate(float rate) {
        ratsSpawnRate = rate;
    }

    public float GetRate() {
        return this.ratsSpawnRate;
    }

    private void SpawnFirstMonsters() {
        Instantiate(rat, ratSpawn.transform.position, Quaternion.identity)
            .transform.SetParent(ratSpawn.transform);
        Instantiate(rat, ratSpawn.transform.position + new Vector3(-2.5f, 0, 0), Quaternion.identity)
            .transform.SetParent(ratSpawn.transform);
    }

    private void UpdateTimers() {
        ratsSpawnTimer -= Time.deltaTime;
    }
}
