using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> rabbits;
        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.rabbits = new List<Rabbit>();
        }
        public int Count { get { return this.rabbits.Count(); } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public void Add(Rabbit rabbit)
        {
            if (this.Capacity > 0)
            {
                rabbits.Add(rabbit);
               
            }
            this.Capacity--;
        }
        public bool RemoveRabbit(string name)
        {
            var rabbit = rabbits.Where(r => r.Name == name).FirstOrDefault();
            if (rabbit != null)
            {
                rabbits.Remove(rabbit);
                return true;
            }
            return false;
        }
        public void RemoveSpecies(string species)
        {
            Rabbit[] kind = rabbits.Where(s => s.Species == species).ToArray();
            if (kind.Length>0)
            {
                foreach (var item in kind)
                {
                    rabbits.Remove(item);
                }
            }
            
        }
        public Rabbit SellRabbit(string name)
        {
            var rabbit = rabbits.Where(n => n.Name == name).FirstOrDefault();
            if (rabbit!=null)
            {
                rabbit.Available = false;
                return rabbit;
            }
            else
            {
                 throw new ArgumentException("Rabbit dosn't exist");
            }

        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] kind = rabbits.Where(s => s.Species == species).ToArray();
            if (kind.Length>0)
            {
                foreach (var item in kind)
                {
                    item.Available = false;
                }
                return kind;
            }
            else
            {
                throw new ArgumentException("No Rabbits");
            }
            
            
        }
        public string Report()
        {
            var available = rabbits.Where(x => x.Available == true);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {Name}:");
            foreach (var item in available)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
