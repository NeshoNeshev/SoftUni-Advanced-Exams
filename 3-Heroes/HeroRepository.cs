using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        
        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }
        public List<Hero> heroes { get; set; }
        public int Count { get { return this.heroes.Count(); } }
        public void Add(Hero hero)
        {
            heroes.Add(hero);
        
        }
        public void Remove(string name)
        {
            var hero = heroes.Where(x => x.Name == name).FirstOrDefault();
            if (hero!=null)
            {
                heroes.Remove(hero);
            }
        }
        public Hero GetHeroWithHighestStrength()
        {
            var highestStrength = heroes.OrderByDescending(h => h.Item.Strength).ToList();
            return highestStrength[0];
           
        }
        public Hero GetHeroWithHighestAbility()
        {
            var highestStrength = heroes.OrderByDescending(h => h.Item.Ability).ToList();
            return highestStrength[0];
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            var highestStrength = heroes.OrderByDescending(h => h.Item.Intelligence).ToList();
            return highestStrength[0];
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Hero hero in heroes)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
