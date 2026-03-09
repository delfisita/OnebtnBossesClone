using NUnit.Framework;

public class UnitTests
{
    [Test]
    public void enemigomuere_()
    {
        int currentHealth = 100;
        currentHealth -= 100;
        Assert.IsTrue(currentHealth <= 0);
    }

    [Test]
    public void playermuere_()
    {
        int currentLives = 3;
        bool gameOver = false;
        currentLives -= 1;
        currentLives -= 1;
        currentLives -= 1;
        if (currentLives <= 0)
            gameOver = true;
        Assert.IsTrue(gameOver);
    }

    [Test]
    public void enemigo_muere_con_10_impactos_()
    {
        int currentHealth = 100;
        int damagePerHit  = 10;
        int hits          = 0;
        bool isDead       = false;

        while (currentHealth > 0)
        {
            currentHealth -= damagePerHit;
            hits++;
        }

        if (currentHealth <= 0)
            isDead = true;

        Assert.IsTrue(isDead);
        Assert.AreEqual(10, hits);
    }
}
