using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Source.Village
{
    public class Cemetry : MonoBehaviour
    {
        public GameObject[] graves;

        private void Start()
        {
            G.cemetry = this;
        }

        public GameObject GetAvailableGrave()
        {
            return graves[Random.Range(0, graves.Length)];
        }
    }
}