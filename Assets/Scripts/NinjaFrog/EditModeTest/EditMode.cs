using NUnit.Framework;
using UnityEngine;


namespace NinjaFrog
{
    [TestFixture]
public class EditMode
{
    private NinjaFrogStats stats;
    [SetUp]
    public void SetUp()
    {
        stats = new NinjaFrogStats(); 
    }

    [Test] 
    public void DefaultLives_ShouldBeThree()
    {
        Assert.AreEqual(3, stats.maxLives, "The default lives should be " + 3 + " but was " + stats.maxLives);
    }

    [TestCase(true, 1, 1)]
    [TestCase(true, 2, 1)]
    [TestCase(false, 0, 1)]
    [TestCase(false, 1, 0)]
    [TestCase(true, 1, 0)]
    public void AttackPower_Cases(bool expected, int attackPower, int attackRange)
    {
        bool actual = stats.CanAttack(attackPower, attackRange);
        Assert.AreEqual(expected, actual, "The expected value should be " + expected + " but was " + actual);
    }

    [TestCase(100, 10, ExpectedResult = 90)]
    public int TestDarPorrazo(int fuerza, int intensidad)
    {
        NinjaFrogStats n = new NinjaFrogStats();
        n.fuerza = fuerza;
        return n.DarPorrazo(intensidad);
    }

    [TestCase(70, 40, ExpectedResult = true)]
    [TestCase(10, 20, ExpectedResult = false)]
    public bool TestPeleaCon(int f1, int f2)
    {
        NinjaFrogStats n1 = new NinjaFrogStats();
        NinjaFrogStats n2 = new NinjaFrogStats();
        n1.fuerza = f1;
        n2.fuerza = f2;
        return n1.PeleaCon(n2);
    }

    [TestCase(100, ExpectedResult = 100)]
    [TestCase(-100, ExpectedResult = 0)]
    public float TestGetFuerza(int f)
    {
        NinjaFrogStats n = new NinjaFrogStats();
        n.fuerza = f;
        return n.GetFuerza();
    }

    [TestCase(52, ExpectedResult = true)]
    [TestCase(0, ExpectedResult = false)]
    [TestCase(-40, ExpectedResult = false)]
    public bool TestEstaVivo(int f)
    {
        NinjaFrogStats n = new NinjaFrogStats();
        n.fuerza = f;
        return n.EstaVivo();
    }

    [TestCase(51, ExpectedResult = true)]
    [TestCase(50, ExpectedResult = true)]
    [TestCase(49, ExpectedResult = false)]
    public bool TestPuedeHacerAtaqueEspecial(int energia)
    {
        NinjaFrogStats n = new NinjaFrogStats();
        n.energia = energia;
        return n.PuedeHacerAtaqueEspecial();
    }
}

}
