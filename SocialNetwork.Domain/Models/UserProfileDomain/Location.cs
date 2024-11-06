using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Models.UserProfileDomain
{
    public class Location
    {
        private Location()
        {
            
        }
        public string Country { get; private set; }
        public string City { get; private set; }

        public static Location Create(string country, string city)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            return new Location
            {
                Country = country,
                City = city
            };
        }

        public void Update(string country, string city)
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            Country = country;
            City = city;
        }

    }
}
