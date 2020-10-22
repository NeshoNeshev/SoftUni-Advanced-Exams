using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    class Parking
    {
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Cars = new List<Car>();
        }
        public int Count { get { return Cars.Count; } }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Car> Cars { get; set; }
        public void Add(Car car)
        {
            if (this.Capacity > 0)
            {
                Capacity--;
                Cars.Add(car);
            }
        }
        public bool Remove(string manifacture, string model)
        {
            var exist = Cars.Where(x => x.Manufacturer == manifacture).Where(x => x.Model == model).FirstOrDefault();
            if (exist != null)
            {
                Capacity++;
                Cars.Remove(exist);
                return true;
            }
            return false;

        }
        public Car GetLatestCar()
        {
            if (Cars.Count!=0)
            {
                var sorttCar = Cars.OrderByDescending(x => x.Year);
                var latest = sorttCar.First();
                return latest;
            }
            else
            {
                return null;
            }
            
        }
        public Car GetCar(string manifacture, string model)
        {
            var exist = Cars.Where(x => x.Manufacturer == manifacture).Where(x => x.Model == model).FirstOrDefault();
            if (exist!=null)
            {
                return exist;
            }
            else
            {
                return null;
            }
        }
       
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var item in Cars)
            {
               
                sb.AppendLine(item.ToString());
            }
            int index = sb.Length - 1;
            sb.Remove(index,1);
            return sb.ToString();
        }
    }
}
