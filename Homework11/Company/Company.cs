using System;
using System.Collections.Generic;
namespace Homework11
{
    /// <summary>
    /// Тип характеризует организацию
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Директор
        /// </summary>
        private Manager manager;
        private List<Department> departmens;
        /// <summary>
        /// Название компании
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Получает общие колличество родительских департаментов
        /// </summary>
        /// <returns></returns>
        public int getCountDepartmants()
        {
            return departmens.Count;
        }
        /// <summary>
        /// Возвращает директора компании
        /// </summary>
        public Manager Manager
        {
            get
            {
                List<Employee> employees = new List<Employee>();

                foreach (Department department in departmens)
                {
                    employees.AddRange(Department.getAllEmployesWithManager(department));
                }                                

                manager.fillStaff(employees);

                return manager;
            }
            private set => manager = value;
        }
        public Department this[int num]
        {
            get { return departmens[num]; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Название организации</param>
        /// <param name="manager">Директор</param>
        /// <param name="departmens">Департаменты организации</param>
        public Company(string name,Manager manager,List<Department> departmens)
        {
            Name = name;
            this.manager = manager;
            this.departmens = departmens;
        }
        /// <summary>
        /// Вывод ощей информации для компании
        /// </summary>
        public void printInfo()
        {
            Console.WriteLine();
            Console.WriteLine("<-----------------КОМПАНИЯ---------------->");
            Console.WriteLine("Компания   - " + Name);            
            Console.WriteLine("Директор   - " + Manager);
            Console.WriteLine("Кол-во.деп - " + departmens.Count);
            Console.WriteLine("<----------------------------------------->");
            Console.WriteLine();
        }
        /// <summary>
        /// Вывод информации о всех департаментах
        /// </summary>
        /// <param name="department">Родительский департамент</param>
        /// <param name="name">имя родительского департамента</param>
        private void PrintNesteedStructure(Department department,string name)
        {
            department.printInfo(name);

            foreach (Department department1 in department.Departments)
            {
                PrintNesteedStructure(department1, department.Name);
            }
        }
        /// <summary>
        /// Вывод информации о компании
        /// </summary>
        public void PrintStructure()
        {
            Console.WriteLine();
            Console.WriteLine("!!!!!!!!!!!!!СТРУКТУРА КОМПАНИИ!!!!!!!!!!!!!!");

            foreach (Department department in departmens)
            {                
                PrintNesteedStructure(department,null);
            }
        }
    }
}
