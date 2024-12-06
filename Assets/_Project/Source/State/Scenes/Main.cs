using System.Collections.Generic;
using _Project.Data;
using _Project.Source.Village;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtils;
using Random = UnityEngine.Random;

namespace _Project.Source.Scenes
{
    public class Main : MonoBehaviour
    {
        public bool simulateDeath = false;
        
        public Transform villageHeroParent;

        public Transform entrance;
        public Transform partyMeetup;
        public GameObject randomPlaces;
        public Blacksmith blacksmith;
        public Alchemist alchemist;
        public Spa spa;
        public GameObject dungeonEntry;

        public List<VillageHero> villageHeroes = new List<VillageHero>();

        private async void Start()
        {
            G.main = this;
            G.fader.FadeOut();

            if (G.state.isJustFromDungeon)
            {
                G.state.isJustFromDungeon = false;
                G.state.canSummonToday = true;
                await OnDungeonExit();
            }

            if (simulateDeath)
                G.state.heroes[0].WitnessDeath(FieldData.AddDeceasedHero(G.state.heroes[0]));
            foreach (var hero in G.state.heroes)
            {
                villageHeroes.Add(SummonVillageHero(hero));
            }

            G.state.selectedHeroes.Clear();
        }

        private async UniTask OnDungeonExit()
        {
            G.ui.expeditionSummary.gameObject.SetActive(true);
            await UniTask.WaitWhile(() => G.ui.expeditionSummary.isActiveAndEnabled);
            G.ui.expeditionSummary.Show();
        }

        public async void SummonInitialHeroes()
        {
            var all = CMS.GetAll<BaseHeroClass>();
            foreach (var model in all)
            {
                var villageHero = SummonVillageHero(model);
                G.state.heroes.Add(villageHero.hero);
                // G.state.villageHeroes.Add(villageHero);
                await UniTask.WaitForSeconds(0.05f);
            }
        }

        public VillageHero SummonVillageHero(BaseHeroClass model = null)
        {
            var hero = HeroSummoning.CreateHero(model);
            var villageHero = Instantiate(hero.model.Get<TagClass>().villagePrefab, villageHeroParent);
            villageHero.transform.localPosition = Random.insideUnitSphere.With(y: 0) * 0.1f;
            villageHero.Init(hero);

            return villageHero;
        }

        public VillageHero SummonVillageHero(Hero hero)
        {
            hero.LastVillagePosition = Vector2.zero;
            Debug.Log(G.state.selectedHeroes.Contains(hero));
            var position = G.state.selectedHeroes.Contains(hero) ? dungeonEntry.transform.position :
                hero.LastVillagePosition == Vector2.zero ? villageHeroParent.position :
                new Vector3(hero.LastVillagePosition.x, 0, hero.LastVillagePosition.y);


            var villageHero = Instantiate(hero.model.Get<TagClass>().villagePrefab, villageHeroParent);
            villageHero.transform.position = position + Random.insideUnitSphere.With(y: 0) * 2.5f;
            villageHero.Init(hero);

            return villageHero;
        }

        public async UniTask ToBattle(List<Hero> party)
        {
            G.state.selectedHeroes = party;
            G.state.waveIndex = 0;

            SetLastVillagePosition();

            var m_EnterDungeon = GameResources.Materials.m_EnterDungeon;
            await m_EnterDungeon.DOFloat(1, "_Scale", 2f).SetEase(Ease.InOutQuad);
            SceneManager.LoadScene("Dungeon");
            m_EnterDungeon.DOFloat(0, "_Scale", 0f);
        }

        public void SetLastVillagePosition()
        {
            foreach (var vh in villageHeroes)
            {
                if (!G.state.selectedHeroes.Contains(vh.hero))
                {
                    vh.hero.LastVillagePosition = new Vector2(vh.transform.position.x, vh.transform.position.z);
                }
            }
        }

        public async void SummonRecruits()
        {
            var classes = CMS.GetAll<BaseHeroClass>();
            for (int i = 0; i < 3; i++)
            {
                var model = classes.GetRandom();
                classes.Remove(model);
                var vh = SummonVillageHero(model);
                vh.ForceState(VillagerState.WAITING_FOR_RECRUITMENT);
            }
        }

        public void StartNextDay()
        {
            G.state.canSummonToday = true;
        }

        public bool CanRecruit()
        {
            return G.state.heroes.Count <= 20 && G.state.gold >= 8;
        }

        public void RecruitHero(VillageHero hero)
        {
            G.state.heroes.Add(hero.hero);
            // G.state.villageHeroes.Remove(hero);
            G.state.gold -= 8;
            hero.hero.Gold += 8;
            hero.ForceState(VillagerState.IN_VILLAGE);
        }

        public void Sponsor(Hero hero, int amount)
        {
            if (G.state.gold < amount) return;
            G.state.gold -= amount;
            hero.Gold += amount;
        }

        private void OnDestroy()
        {
            // SaveSystem.Save(G.state);
        }
    }
}