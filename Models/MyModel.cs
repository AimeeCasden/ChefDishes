using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace ChefDishes.Models
{
    public class Chef
    {
       [Key]
       public int ChefId{get;set;}

       [Required]
       [MinLength(2)]
       public string FirstName{get;set;}

       [Required]
       [MinLength(2)]
       public string LastName{get;set;}

       [Required]
       public DateTime Birthday {get;set;}
       public DateTime CreatedAt{get;set;} = DateTime.Now;
       public DateTime UpdatedAt{get;set;} = DateTime.Now;

    //  DOn't put a validation here because the validation will end up being invalid and no one wants to deal with that
       public List<Food> CreatedFood  {get;set;}
    }
    public class Food
    {
        [Key]
        public int FoodId{get;set;}

        [Required]
        [MinLength(3)]
        public string Name{get;set;}

        [Required]
        [Range(1,5000)]
        public int Calories{get;set;}

        [Required]
        [Range(1,5)]
        public int Tastiness{get;set;}

        [Required]
        [MinLength(5)]
        public string Description{get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // NO VALIDATIONS HERE  
        public Chef Cook {get;set;}
        public int ChefId {get;set;}
        

    }
}
