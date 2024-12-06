using Microsoft.AspNetCore.Mvc;

namespace week4assignment.Models
{
    public class AdminDashboardViewModel
    {
        public int CatCount { get; set; }
        public int DogCount { get; set; }
        public int HouseholdCount { get; set; }
    }
}
