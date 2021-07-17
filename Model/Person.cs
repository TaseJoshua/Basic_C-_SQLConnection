using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI.Model
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public string FullInfo
        {
            get 
            {
                return $"{FirstName} {SurName} ({Email})"; 
            
            }
        }

    }
}
