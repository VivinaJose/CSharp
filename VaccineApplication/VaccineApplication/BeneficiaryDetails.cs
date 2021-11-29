using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineApplication
{
    class BeneficiaryDetails
    {
        private static int _autoIncreamentedNumber = 1001;
        public int RegistrationID { get; set; }
        public string Name { get; set; }
        public long Mobile { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public GenderChoice Gender { get; set; }
        public List<VaccineDetails> VaccineDetails = new List<VaccineDetails>();
        public BeneficiaryDetails(string name, long mobile, string address, int age, int gender)
        {
            RegistrationID = _autoIncreamentedNumber++;
            Name = name;
            Mobile = mobile;
            Address = address;
            Age = age;
            Gender = (GenderChoice)gender;

        }
       
        public void Vaccinate(int vaccine, DateTime date)
        {
            

            if (VaccineDetails.Count == 0)
            {
                
                var details = new VaccineDetails(vaccine, date, 1);
                VaccineDetails.Add(details);
                

            }
            else if (VaccineDetails.Count == 1)
            {
                var details = new VaccineDetails(vaccine, date, 2);
                VaccineDetails.Add(details);
                
                    
                
            }
            else
            {
                Console.WriteLine("You have two doses already");
            }

           
        }
      
    }
    public enum GenderChoice
    {
        Male = 1, Female, Transgender
    }
    public enum VaccineType
    {
        Covaxin = 1, Covishield, Sputnic
    }
}
