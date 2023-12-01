using System;
using CalculateSalarApplication.Enum;

namespace MyApplication
{
    class Program
    {
        static int childrenCount = 0;
        static string martialStatus;
        static int totalSalary = 0;
        static int grossSalary = 0;
        static float ratio = 1;
        static float taxPersentage = 0;
        static float taxValue;
        static float netSalary = 0;

        static void Main(string[] args)
        {
            //int childrenCount = 0;
            //string martialStatus;
            //int totalSalary = 0;
            //int grossSalary = 0;
            //float ratio = 1;
            //float taxPersentage = 0;
            //float taxValue;
            //float netSalary = 0;
            EnterData();
            CalculateChildSupport(childrenCount);
            CalculateFamilySupport(martialStatus);
            CalculateSalaryAndTax(totalSalary, ratio);
            CalculateMoney(netSalary);
        }


        public static void EnterData()
        {
            Console.WriteLine("Enter your Gross Salary: (use the number to write)");
            grossSalary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your Martial Status:(Married/Single/Divorced)");
            martialStatus = Console.ReadLine();

            if (martialStatus.ToLower() != MartialStatus.Single.ToString().ToLower())
            {
                Console.WriteLine("How many kids do you have ? (use the number to write)");
                childrenCount = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Enter your disabled status:(Yes/No)");
            string disabled = Console.ReadLine();

            if (disabled.ToLower() == DisabledStatus.Yes.ToString().ToLower())
            {
                ratio = ratio * 0.5f;
            }
        }


        public static int CalculateChildSupport(int childrenCount)
        {
            int childsupport = 0;
            switch (childrenCount)
            {
                case 0:
                    childsupport = 0;
                    break;

                case 1:
                    childsupport = 30;
                    break;

                case 2:
                    childsupport = 55;
                    break;

                case 3:
                    childsupport = 75;
                    break;

                default:
                    childsupport = 75 + (childrenCount - 3) * 15;
                    break;
            }
            totalSalary = grossSalary + childsupport;
            return totalSalary;
        }

        public static int CalculateFamilySupport(string martialStatus)
        {
            if (martialStatus.ToLower() == MartialStatus.Married.ToString().ToLower())
            {
                int familysupport = 50;
                totalSalary = totalSalary + familysupport;
            }
            return totalSalary;
        }

        public static void CalculateSalaryAndTax(int totalSalary, float ratio)
        {

            if (totalSalary <= 1000)
            {
                taxPersentage = 15 * ratio;
                taxValue = totalSalary * taxPersentage / 100;
                netSalary = totalSalary - taxValue;
            }
            else if (grossSalary > 1000 && grossSalary <= 2000)
            {
                taxPersentage = 20 * ratio;
                taxValue = totalSalary * taxPersentage / 100;
                netSalary = totalSalary - taxValue;

            }
            else if (grossSalary > 2000 && grossSalary < 3000)
            {
                taxPersentage = 25 * ratio;
                taxValue = totalSalary * taxPersentage / 100;
                netSalary = totalSalary - taxValue;
            }
            else if (grossSalary >= 3000)
            {
                taxPersentage = 30 * ratio;
                taxValue = totalSalary * taxPersentage / 100;
                netSalary = totalSalary - taxValue;

            }
            ShowResult(totalSalary, netSalary, taxPersentage, taxValue);
        }



        public static void ShowResult(int totalSalary, float netSalary, float taxPersentage, float taxValue)
        {
            Console.WriteLine("Gross salary: " + totalSalary);
            Console.WriteLine("Net salary :" + Math.Round(netSalary));
            Console.WriteLine("Tax fee :" + Math.Round(taxValue, 2));
            Console.WriteLine("Tax Persentage :" + taxPersentage);
        }


        public static int CalculateMoney(float netSalary)
        {
            int[] availableMoney = { 200, 100, 50, 20, 10, 1 };

            foreach (int i in availableMoney)
            {
                int count = Convert.ToInt32(netSalary) / i;

                if (count > 0)
                {
                    Console.WriteLine($"{count} x {i}");
                    netSalary %= i;
                }
            }
            return 0;
        }
    }
}