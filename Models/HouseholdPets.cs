using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace week4assignment.Models
{
    public class HouseholdPets
    {
        public int Id { get; set; }
        public string HouseHoldName { get; set; }
        public IEnumerable<Cat> CatList { get; set; }
        public IEnumerable<Dog> DogList { get; set; }
        public int DogCount { get; set; }
        public int CatCount { get; set; }

       /*  public HouseholdPets()
        {
            Random rand = new Random();
            this.Id = rand.Next(1, 10001);
            this.CatList = new List<Cat>();
            this.DogList = new List<Dog>();
            this.CatCount = 0;
            this.DogCount = 0;
        }
        public HouseholdPets(int id)
        {
            this.Id = id;
            this.CatList = new List<Cat>();
            this.DogList = new List<Dog>();
            this.CatCount = 0;
            this.DogCount = 0;
        } */

        public void addCat(Cat cat)
        {
            this.CatList.ToList<Cat>().Add(cat);
            this.CatCount++;
        }
        public void addDog(Dog dog)
        {
            this.DogList.ToList<Dog>().Add(dog);
            this.DogCount++;
        }
    }
}