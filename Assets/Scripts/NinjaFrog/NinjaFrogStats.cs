using UnityEngine;


namespace NinjaFrog
{
    public class NinjaFrogStats : MonoBehaviour
    {
        public int maxLives = 3;
        public float speed = 5f;
        public float jumpForce = 10f;
        public int attackPower = 1;

        public int attackRange = 1;
        public int fuerza;
        public int energia;



        public int DarPorrazo(int intensidad)
        {
            fuerza -= intensidad;
            return fuerza;
        }

        public bool PeleaCon(NinjaFrogStats n2)
        {
            return fuerza > n2.fuerza;
        }

        public int GetFuerza()
        {
            if (fuerza < 0) fuerza = 0;
            return fuerza;
        }

        public bool EstaVivo()
        {
            return fuerza > 0;
        }

        public bool PuedeHacerAtaqueEspecial()
        {
            return energia >= 50;
        }
        public bool CanAttack(int attackPower, int attackRange)
        {
            if (attackPower > 0 && attackRange > 0)
            {
                return true;
            }
            return false;
        }
    }
}