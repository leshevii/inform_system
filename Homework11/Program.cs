using System;
using System.Collections.Generic;

namespace Homework11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            Generator generator = new Generator();
            Company company = generator.GetCompany();            
            company.printInfo();
            company.PrintStructure();
            Console.ReadKey();
        }
    }
}
