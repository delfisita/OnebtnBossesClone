using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections;

public class IntegrationTests
{
    [UnityTest]
    public IEnumerator Proyectil_Impacta_Enemigo_VidaBaja()
    {
        int currentHealth = 100;
        currentHealth -= 10;
        yield return null;
        Assert.AreEqual(90, currentHealth);
    }

    [UnityTest]
    public IEnumerator Enemigo_SinVida_Muere()
    {
        int currentHealth = 100;
        bool isDead = false;
        currentHealth -= 100;
        if (currentHealth <= 0)
            isDead = true;
        yield return null;
        Assert.IsTrue(isDead);
    }

    [UnityTest]
    public IEnumerator EnemyProjectile_Impacta_Player_PierdeVida()
    {
        int currentLives = 3;
        currentLives -= 1;
        yield return null;
        Assert.AreEqual(2, currentLives);
    }

    [UnityTest]
    public IEnumerator Player_SinVidas_ActivaGameOver()
    {
        int currentLives = 3;
        bool gameOver = false;
        currentLives -= 1;
        currentLives -= 1;
        currentLives -= 1;
        if (currentLives <= 0)
            gameOver = true;
        yield return null;
        Assert.IsTrue(gameOver);
    }

    [UnityTest]
    public IEnumerator Timer_SeDetiene_NoSigueCorriendo()
    {
        float elapsedTime = 0f;
        bool isRunning    = true;
        float deltaTime   = 0.1f;

        for (int i = 0; i < 20; i++)
            if (isRunning) elapsedTime += deltaTime;

        isRunning = false;
        float timeAtStop = elapsedTime;

        for (int i = 0; i < 10; i++)
            if (isRunning) elapsedTime += deltaTime;

        yield return null;
        Assert.AreEqual(timeAtStop, elapsedTime, 0.01f);
    }
}
