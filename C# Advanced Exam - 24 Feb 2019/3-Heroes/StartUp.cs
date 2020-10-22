using System;
namespace Heroes
{
    
    public class StartUp
    {
        public static void Main()
        {

            HeroRepository repository = new HeroRepository();
            //Initialize entity
            Item item = new Item(23, 35, 48);
            //Print Item
            Console.WriteLine(item);
            Hero hero = new Hero("Hero Name", 24, item);
            //Print Hero
            Console.WriteLine(hero);

            repository.Add(hero);
            //Remove Hero
            repository.Remove("Hero Name");

            Item secondItem = new Item(100, 20, 13);
            Hero secondHero = new Hero("Second Hero Name", 125, secondItem);

            //Add Heroes
            repository.Add(hero);
            repository.Add(secondHero);

            Hero heroStrength = repository.GetHeroWithHighestStrength(); // Hero with name Second Hero
            Hero heroAbility = repository.GetHeroWithHighestAbility(); // Hero with name Hero Name
            Hero heroIntelligence = repository.GetHeroWithHighestIntelligence(); // Hero with name Hero

            Console.WriteLine(repository.Count); //2

            Console.WriteLine(repository);



        }
    }
}
