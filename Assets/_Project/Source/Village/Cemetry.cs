using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Source.Village
{
    public class Cemetry : MonoBehaviour
    {
        public GameObject[] graves;
        
        public int deceasedCount;

        private void Start()
        {
            G.cemetry = this;
            deceasedCount = G.state.deceasedHeroes.Count;
            
            for (var i = 0; i < graves.Length; i++)
            {
                graves[i].SetActive(i < deceasedCount);
            }
        }

        public GameObject GetTombObject(int tombPlace)
        {
            return graves[tombPlace];
        }
    }
}