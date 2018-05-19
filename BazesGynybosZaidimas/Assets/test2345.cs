using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class test2345 {

    [UnityTest]
    public IEnumerator ParticleSelfDestructTest()
    {

        var particlePrefab = Resources.Load("Prefabs/particles/BasicGunShotParticle");

        Vector3 V = new Vector3(0, Random.Range(-3.0f, 2.0f));
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(0, 0) * Mathf.Rad2Deg);

        GameObject particle = GameObject.Instantiate(particlePrefab, V, rotation) as GameObject;

        yield return new WaitForSeconds(2.5f);

        Assert.IsTrue(particle == null);
    }

    [UnityTest]
    public IEnumerator EnemySpawnTest()
    {

        var enemyPrefab = Resources.Load("Prefabs/Slow");

        Vector3 V = new Vector3(0, Random.Range(-3.0f, 2.0f));
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(0, 0) * Mathf.Rad2Deg);

        GameObject enemySlow = Transform.Instantiate(enemyPrefab, V, rotation) as GameObject;

        Assert.AreEqual(enemySlow.tag, "Enemy");

        yield return null;
    }

    [UnityTest]
    public IEnumerator EnemyDeathTest()
    {
        Player.score = 0;

        var enemyPrefab = Resources.Load("Prefabs/Slow");

        Vector3 V = new Vector3(0, Random.Range(-3.0f, 2.0f));
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(0, 0) * Mathf.Rad2Deg);

        GameObject enemySlow = Transform.Instantiate(enemyPrefab, V, rotation) as GameObject;
        Enemy e1 = enemySlow.GetComponent<Enemy>();

        e1.curent_enemy_hp = 0;

        yield return new WaitForSeconds(2f);

        Assert.IsTrue(enemySlow == null);
        Assert.IsTrue(Player.score > 0);

    }

    [UnityTest]
    public IEnumerator SpawnerTest()
    {

        var spawnerPrefab = Resources.Load("Prefabs/Spawner");

        Vector3 V = new Vector3(0, Random.Range(-3.0f, 2.0f));
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(0, 0) * Mathf.Rad2Deg);

        GameObject spawner = Transform.Instantiate(spawnerPrefab, V, rotation) as GameObject;
        Spawner p1 = spawner.GetComponent<Spawner>();

        int enemyCount1 = GameObject.FindGameObjectsWithTag("Enemy").Length;

        p1.minTime = 1f;
        p1.maxTime = 2f;
        p1.LevelUpSpawner();

        yield return new WaitForSeconds(10f);

        int enemyCount2 = GameObject.FindGameObjectsWithTag("Enemy").Length;

        Assert.IsTrue(enemyCount1 < enemyCount2);
    }
}
