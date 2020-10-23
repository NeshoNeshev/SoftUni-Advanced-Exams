using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        private List<Pet> pets;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new List<Pet>();
        }
        public int Capacity { get; set; }
        public int Count { get { return pets.Count(); } }
        public void Add(Pet pet)
        {
            if (this.Capacity > 0)
            {
                pets.Add(pet);
                this.Capacity--;
            }
        }
        public bool Remove(string name)
        {
            var pet = pets.Where(p => p.Name == name).FirstOrDefault();
            if (pet !=null)
            {
                pets.Remove(pet);
                Capacity++;
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            var petAndOwner = pets.Where(p => p.Name == name).Where(o => o.Owner == owner).FirstOrDefault();
            if (petAndOwner==null)
            {

                
                return null;
            }
            else
            {
                return petAndOwner;
            }
        }
        public Pet GetOldestPet()
        {
            if (pets.Count>0)
            {
                var oldestPet = pets.OrderByDescending(p => p.Age).ToArray();
                return oldestPet[0];
            }
            return null;
            
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();


        }
    }
}
