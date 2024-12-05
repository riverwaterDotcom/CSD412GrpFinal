using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace week4assignment.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string CatName { get; set; }
        public string CatPattern { get; set; }
        public float CatWeight { get; set; }
        public string CatSize { get; set; }

        // commented out constructors because it wouldnt work with them in here
        /* public Cat()
        {
            Random rand = new Random();
            this.Id = rand.Next(1, 10001);
            this.CatName = "default cat name";
            this.CatPattern = "default cat pattern is tabby";
            this.CatWeight = 10.0f;
            this.CatSize = "default cat size is medium";
        }
        public Cat(int id)
        {
            this.Id = id;
            this.CatName = "default cat name";
            this.CatPattern = "default cat pattern is tabby";
            this.CatWeight = 10.0f;
            this.CatSize = "default cat size is medium";
        } */
    }
}