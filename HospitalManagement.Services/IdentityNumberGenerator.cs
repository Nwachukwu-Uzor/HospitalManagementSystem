using HospitalManagement.Services.Contracts;
using System;
using System.Linq;

namespace HospitalManagement.Services
{
    public class IdentityNumberGenerator : IIdentityNumberGenerator
    {
        public string GenerateIdNumber(string designationInitial, int length = 10)
        {
            if(designationInitial.Length > 3)
            {
                designationInitial = designationInitial.Substring(0, 3);
            }
            var random = new Random();
            const string stringChar = "1234567890";
         
            var randomNumber = new string(Enumerable.Repeat(stringChar, length)
                                .Select(s => s[random.Next(s.Length)])
                                .ToArray()
            );

            return $"{designationInitial.ToUpper()}-{randomNumber}";
        }
    }
}
