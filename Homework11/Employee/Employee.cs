using System;
namespace Homework11
{
    /// <summary>
    /// Базовый тип характеризующий всех сотрудников
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Имя 
        /// </summary>
        public string   FirstName        { get; private set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string   SecondName       { get; private set; }
        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime Birthday         { get; private set; }
        /// <summary>
        /// Дата приема на работу
        /// </summary>
        public DateTime DateOfEmployment { get; private set; }
        /// <summary>
        /// В
        /// </summary>
        /// <returns></returns>
        public virtual float Salary() => 0;

        public Employee(string fName,string sName,DateTime birth, DateTime dateOfEmployment)
        {
            FirstName  = fName;
            SecondName = sName;
            Birthday   = birth;
            DateOfEmployment = dateOfEmployment;
        }
        public override string ToString()
        {
            return FirstName + "." + SecondName + " Зарплата(" + Salary() + ")"; //+ Birthday + ";" + DateOfEmployment;
        }
    }
}
