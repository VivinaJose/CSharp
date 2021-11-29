using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineApplication
{
    class VaccineApplication
    {
        static List<BeneficiaryDetails> Beneficiaries = new List<BeneficiaryDetails>();
        static VaccineApplication BenefitaryObject = new VaccineApplication();
        static void Main(string[] args) 
        {
           

            var sample1 = new BeneficiaryDetails("Vivina", 9159584171, "chennai", 23, 2);
            var sample2 = new BeneficiaryDetails("jose", 12345678, "chengalpatu", 24, 2);
            sample1.Vaccinate(1, DateTime.Now);
            sample2.Vaccinate(2, DateTime.Now);
            Beneficiaries.Add(sample1);
            Beneficiaries.Add(sample2);

            int firstaction = 0;
            string functionpick = Option.YES.ToString(); string functionshow = Option.YES.ToString();
            bool firstactionflag = false;

            do
            {
                Console.WriteLine(" Welcome! Choose the option");
                Console.WriteLine("1-Beneficiary Registration\n 2-Vaccination\n 3-Exit");
                do
                {
                    Console.WriteLine("Enter the option:");
                    firstactionflag = int.TryParse(Console.ReadLine(), out firstaction);
                    if (firstactionflag)
                    {
                        switch (firstaction)
                        {
                            case 1:
                                BenefitaryObject.NewBenefitaryDetails();
                                functionpick = Option.NO.ToString();
                                break;
                            case 2:
                                BenefitaryObject.Vaccination();
                                functionpick = Option.NO.ToString();
                                break;
                            case 3:
                                functionpick = Option.NO.ToString();
                                functionshow = Option.NO.ToString();
                                break;
                            default:
                                Console.WriteLine("Please enter valid input:");
                                functionpick = Option.YES.ToString();
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Please enter valid input:");
                        functionshow = Option.YES.ToString();
                        break;
                    }



                } while (functionpick == Option.YES.ToString());

            } while (functionshow == Option.YES.ToString());
        }

        

        public void NewBenefitaryDetails()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(">>Home>>Adding Beneficiary");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your your Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose your Gender:\n1.Male\n2.Female\n3.Transgender");
            int gender = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Phone number:");
            long mobile = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Address:");
            string address = Console.ReadLine();
            var newMem = new BeneficiaryDetails (name, mobile, address, age, gender);
            Console.WriteLine("your Registration ID is{0}", newMem.RegistrationID);
            Beneficiaries.Add(newMem);
        }


        public void Vaccination()
        {
            string ffunctionpick = Option.YES.ToString();
            string ffunctionshow = Option.YES.ToString();
            bool secondactionflag = false;
           
            
            do
            {

                int act;
                ShowListOfBeneficiaries();
                Console.WriteLine("Enter your Registration ID:");
                int registeredId = int.Parse(Console.ReadLine());
                BeneficiaryDetails currentBenificiary = null;
                foreach (BeneficiaryDetails each in Beneficiaries)
                {
                    if (registeredId == each.RegistrationID)
                    {
                        currentBenificiary = each;
                    }
                }

                if (currentBenificiary != null)
                {
                    
                    do
                    {

                        Console.WriteLine("Enter your choice ");
                        Console.WriteLine("1-Take Vaccination\n 2-Vaccination History\n 3-Next due date\n 4-exit ");
                        act = int.Parse(Console.ReadLine());
                        secondactionflag = int.TryParse(Console.ReadLine(), out act);
                        if (secondactionflag)
                        {
                            switch (act)
                            {
                                case 1:
                                    TakeVaccination(currentBenificiary);
                                    break;
                                case 2:
                                    VaccinationHistory(currentBenificiary);
                                    break;
                                case 3:
                                    DueDate();
                                    break;
                                case 4:
                                    ffunctionpick = Option.YES.ToString();
                                    ffunctionshow = Option.YES.ToString();
                                    break;
                                default:
                                    Console.WriteLine("invalid input");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter valid input:");
                            ffunctionshow = Option.YES.ToString();
                            break;
                        }
                    } while (ffunctionpick == Option.YES.ToString());
                }

                else
                {
                    Console.WriteLine("Incorrect registration number");
                }

            } while (ffunctionshow == Option.YES.ToString()) ;
            


        }
        public void DueDate()
        {


            if (VaccineDetails.Count == 1)
            {

                Console.WriteLine("Your Next dose due time is ");

            }
            else
            {
                Console.WriteLine("Completed your vaccination course. Thank you for  participating");
            }
        }

        public void TakeVaccination(BeneficiaryDetails currentBeneficiary)
        {

            do
            {

                Console.WriteLine("Choose your Vaccine:\n1.Covaxin\n2.Covishield\n3.Sputnic");
                int vaccineType = int.Parse(Console.ReadLine());
                if (currentBeneficiary.VaccineDetails.Count == 0)
                {

                    break;
                }
                else if (currentBeneficiary.VaccineDetails.Count == 1)
                {

                    
                    break;


                }

            } while (true);
        }


        private static void VaccinationHistory(BeneficiaryDetails currentBeneficiary)
        {
            
            foreach (VaccineDetails detail in currentBeneficiary.VaccineDetails)
            {
                Console.WriteLine("Vaccine: {1} \n Dosage:{1} \n }",detail.Vaccine, detail.Dosage);
            }


        }
        
        private static void ShowListOfBeneficiaries()
        {
            foreach (BeneficiaryDetails beneficiary in Beneficiaries)
            {
                Console.WriteLine("Registration  ID: {0} \n Benificiary Name:{1}", beneficiary.RegistrationID, beneficiary.Name);
            }
        }































    }
    public enum Option
    {
        YES,
        NO
    }
       
    }

