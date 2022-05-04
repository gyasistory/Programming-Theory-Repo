using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
     public abstract class Collectable : MonoBehaviour
    {
        [SerializeField] float rotationSpeed = 5f;

        [HideInInspector]
        public abstract int points { get; }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}