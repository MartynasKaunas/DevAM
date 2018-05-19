using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class test1
{
    [Test]
    public void GameSceneLoadTest()
    {

        int playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        int spawnerCount = GameObject.FindGameObjectsWithTag("Spawner").Length;
        int wallCount = GameObject.FindGameObjectsWithTag("Wall").Length;
        int delWallCount = GameObject.FindGameObjectsWithTag("DeletionWall").Length;

        Debug.Log(enemyCount);
        Debug.Log(Spawner.currentlyAlive);

        Assert.IsTrue(enemyCount == Spawner.currentlyAlive);
        Assert.IsTrue(playerCount == 1);
        Assert.IsTrue(spawnerCount == 1);
        Assert.IsTrue(wallCount == 1);
        Assert.IsTrue(delWallCount == 1);

        var player = GameObject.Find("Player");
        var playerplayer = player.GetComponent<Player>();
        var playerability = player.GetComponent<Buff_1>();

        Assert.IsTrue(playerability.buffParticle != null);
        Assert.IsTrue(playerplayer.smokeParticle != null);

        var enemy = GameObject.FindGameObjectWithTag("Enemy");
        var enemyenemy = enemy.GetComponent<Enemy>();

        Assert.IsTrue(enemyenemy.AttackSound != null);
        Assert.IsTrue(enemyenemy.damageTakenParticle != null);
        Assert.IsTrue(enemyenemy.DeathSound != null);

        var spawner = GameObject.Find("Spawner");
        var spawnerspawner = spawner.GetComponent<Spawner>();
        Assert.IsTrue(spawnerspawner.enemyPrefab != null);
        Assert.IsTrue(spawnerspawner.enemyPrefab1 != null);
        Assert.IsTrue(spawnerspawner.enemyPrefab2 != null);
        Assert.IsTrue(spawnerspawner.enemyPrefabBoss != null);
        Assert.IsTrue(spawnerspawner.levelMusic1 != null);
        Assert.IsTrue(spawnerspawner.levelMusic2 != null);
        Assert.IsTrue(spawnerspawner.levelMusic3 != null);
    }
}
