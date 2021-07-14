using System;
using System.Collections.Generic;
namespace Homework11
{
    public class Manager : Employee
    {
        /// <summary>
        /// процент зарплаты 
        /// </summary>
        private const float PERCENT = 0.15f;
        /// <summary>
        /// Список подчиненных
        /// </summary>
        private List<Employee> _staff = new List<Employee>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fName">имя</param>
        /// <param name="sName">фамилия</param>
        /// <param name="birth">дата рождения</param>
        /// <param name="dateOfEmployment">дата поступления на работу</param>
        /// <param name="staff">список подчиненных</param>
        public Manager(string fName, string sName, DateTime birth, DateTime dateOfEmployment) : base(fName, sName, birth, dateOfEmployment)
        {            
        }
        /// <summary>
        /// Заполняет сотрудников для управляющего
        /// </summary>
        /// <param name="employees">Сотрудники находящтеся под управлением данного управленца</param>
        public void fillStaff(List<Employee> employees)
        {
            _staff = employees;
        }
        /// <summary>
        /// Возвращает зарплату у менеджера
        /// </summary>
        /// <returns>float</returns>
        public override float Salary()
        {
            float count = 0f;
            
            foreach(Employee employee in _staff)
            {
                count += employee.Salary();
            }
            count = PERCENT * count;

            if (count < 1300) count = 1300;

            return count;
        }        
    }
}
