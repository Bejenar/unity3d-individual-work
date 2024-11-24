using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Project.Data;
using _Project.Source.Village;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtils;

namespace _Project.Source.Scenes
{
    public class Main : MonoBehaviour
    {
        public VillageHero villageHeroPrefab;
        public Transform villageHeroParent;

        public Transform entrance;
        public Transform partyMeetup;
        public GameObject randomPlaces;
        public Blacksmith blacksmith;
        public Alchemist alchemist;
        public GameObject spa;
        
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

            foreach (var hero in G.state.heroes)
            {
                SummonVillageHero(hero);
            }
        }

        private async UniTask OnDungeonExit()
        {
            G.ui.expeditionSummary.gameObject.SetActive(true);
            await UniTask.WaitWhile(() => G.ui.expeditionSummary.isActiveAndEnabled);
            G.ui.expeditionSummary.Show();
            G.state.selectedHeroes.Clear();
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
            var villageHero = Instantiate(villageHeroPrefab, villageHeroParent);
            villageHero.transform.localPosition = Random.insideUnitSphere.With(y:0) * 0.1f;
            villageHero.Init(hero);
            
            return villageHero;
        }
        
        public VillageHero SummonVillageHero(Hero hero)
        {
            var villageHero = Instantiate(villageHeroPrefab, villageHeroParent);
            villageHero.transform.localPosition = Random.insideUnitSphere.With(y:0) * 0.1f;
            villageHero.Init(hero);
            
            return villageHero;
        }

        public async UniTask ToBattle(List<Hero> party)
        {
            G.state.selectedHeroes = party;
            G.state.waveIndex = 0;

            var m_EnterDungeon = GameResources.Materials.m_EnterDungeon;
            await m_EnterDungeon.DOFloat(1, "_Scale", 2f).SetEase(Ease.InOutQuad);
            SceneManager.LoadScene("Dungeon");
            m_EnterDungeon.DOFloat(0, "_Scale", 0f);
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
    }
}