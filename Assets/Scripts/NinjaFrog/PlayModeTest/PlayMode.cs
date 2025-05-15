using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

namespace NinjaFrog
{
    [TestFixture]
    public class PlayMode
    {
        private GameObject NinjaFrog1;
        private GameObject NinjaFrog2;
        private NinjaFrogStats s1, s2;
        private GameObject Ground;

        [SetUp]
        public void SetUp()
        {
            EditorSceneManager.LoadScene("SampleScene");
            NinjaFrog1 = GameObject.Find("NinjaFrog1");
            NinjaFrog2 = GameObject.Find("NinjaFrog2");

            s1 = NinjaFrog1.GetComponent<NinjaFrogStats>();
            s2 = NinjaFrog2.GetComponent<NinjaFrogStats>();
            Debug.Log("Scene Loaded");
        }
        [UnityTest]
        public IEnumerator NinjaFrogFall()
        {
            yield return new WaitForSeconds(6);

            NinjaFrog1 = GameObject.Find("NinjaFrog1");
            Ground = GameObject.Find("Ground");
            Assert.That(NinjaFrog1.transform.position.y > Ground.transform.position.y);

        }

        [UnityTest]
        public IEnumerator TestDarPorrazoReduceFuerza()
        {
            s1.fuerza = 100;
            s2.fuerza = 100;
            int resultado = s1.DarPorrazo(30);
            yield return null;
            Assert.AreEqual(70, resultado, "Debe de reducirse la fuerza");
        }

        [UnityTest]
        public IEnumerator TestPeleaConGanaElMasFuerte()
        {
            s1.fuerza = 100;
            s2.fuerza = 10;
            bool resultado = s1.PeleaCon(s2);
            yield return null;
            Assert.IsTrue(resultado, "Ninja1 debe de ganar");
        }

        [UnityTest]
        public IEnumerator TestPuedeHacerAtaqueEspecialConEnergia()
        {
            s1.energia=50;
            yield return null;
            Assert.IsTrue(s1.PuedeHacerAtaqueEspecial(), "Con mas de 50 de energia o más, debe devolver true");
        }

        [UnityTest]
        public IEnumerator TestGetFuerzaNoEsNegativa()
        {
            s1.DarPorrazo(200);
            yield return null;
            Assert.AreEqual(0, s1.GetFuerza(), "No debe de bajar de 0");
        }

        [UnityTest]
        public IEnumerator TestCanAttackSoloSiTieneParametrosValidos()
        {
            yield return null;
            Assert.IsTrue(s1.CanAttack(1, 1), "Debe poder atacar si attackPower y attackRange son mayores que cero.");
        }


        [TearDown]
        public void TearDown()
        {
            EditorSceneManager.UnloadSceneAsync("SampleScene");
        }
    }

}
