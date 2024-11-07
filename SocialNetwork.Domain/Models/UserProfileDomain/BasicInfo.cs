using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Models.UserProfileDomain
{
    public class BasicInfo
    {
        private BasicInfo()
        {
            
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string? Bio { get; private set; }
        public string? ProfilePicture { get; private set; }
        public string? CoverPicture { get; private set; }
        public Location? Location { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public static BasicInfo Create(string firstName, string lastName, string emailAddress, string phoneNumber, Location location, DateTime dateOfBirth, string bio = "", string profilePicture = "", string coverPicture = "")
        {
            //TODO ADD VALIDATION, ERROR HANDILING ,ERROR NOTIFIY
            return new BasicInfo
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Bio = bio,
                ProfilePicture = profilePicture,
                CoverPicture = coverPicture,
                Location = location,
                DateOfBirth = dateOfBirth
            };
        }
    }
}
