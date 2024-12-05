using System.Collections.Generic;
using UnityEngine;

namespace _Project.Source.Village
{
    public class Spa : MonoBehaviour
    {
        public Transform[] spaPoints;

        private bool[] spaReservations;

        private void Start()
        {
            spaReservations = new bool[spaPoints.Length];
        }

        public bool ReserveSpaPoint(out int index)
        {
            List<int> availableIndices = new List<int>();
            for (int i = 0; i < spaReservations.Length; i++)
            {
                if (!spaReservations[i])
                {
                    availableIndices.Add(i);
                }
            }

            if (availableIndices.Count > 0)
            {
                index = availableIndices[Random.Range(0, availableIndices.Count)];
                spaReservations[index] = true;
                return true;
            }

            index = -1;
            return false;
        }

        public void GetInSpa(VillageHero hero, int index)
        {
            hero.Agent.enabled = false;
            hero.behaviorAgent.enabled = false;

            hero.transform.parent = spaPoints[index];
            hero.transform.position = spaPoints[index].position;
        }

        public void GetOutSpa(VillageHero hero, int index)
        {
            hero.transform.parent = hero.InitParent;
            hero.transform.position = transform.position;

            hero.Agent.enabled = true;
            hero.behaviorAgent.enabled = true;
            spaReservations[index] = false;
        }
    }
}