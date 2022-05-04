using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class BonusCollectable : Collectable
    {
        public override int points => 5;
        [SerializeField]
        private ParticleSystem particle;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Lady") || collision.gameObject.CompareTag("Cowboy"))
            {
                particle.Play();
            }
        }

    }
}