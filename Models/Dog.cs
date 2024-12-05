using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace week4assignment.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string DogName { get; set; }
        public string DogPattern { get; set; }
        public float DogWeight { get; set; }
        public string DogSize { get; set; }

        public Dog()
        {
            Random rand = new Random();
            this.Id = rand.Next(1, 10001);
            this.DogName = "default dog name";
            this.DogPattern = "default dog pattern is golden retriever";
            this.DogWeight = 50.0f;
            this.DogSize = "default dog size is medium";
        }
        public Dog(int id)
        {
            this.Id = id;
            this.DogName = "default dog name";
            this.DogPattern = "default dog pattern is golden retriever";
            this.DogWeight = 50.0f;
            this.DogSize = "default dog size is medium";
        }
    }
}