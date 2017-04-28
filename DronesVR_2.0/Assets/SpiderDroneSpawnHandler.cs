﻿using UnityEngine;
using System.Collections;

public class SpiderDroneSpawnHandler : MonoBehaviour {

    // Use this for initialization
    public EnemyPoolScript spiderDronePool;
    public GameObject player;

    public int createEnemy(int numberOfEnemys2Spawn)
    {
        GameObject obj = spiderDronePool.GetPulledObject();
        if (obj != null)
        {
            obj.GetComponent<ZombieController>().player = player;
            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            obj.GetComponent<EnemyHealth>().isDead = false;
            obj.SetActive(true);
            numberOfEnemys2Spawn--;
        }
        return numberOfEnemys2Spawn;
    }
}