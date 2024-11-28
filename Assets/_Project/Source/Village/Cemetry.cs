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

        public int GetAvailableGrave()
        {
            return Random.Range(0, graves.Length);
        }

        public GameObject GetTombObject(int tombPlace)
        {
            return graves[tombPlace];
        }
    }
}