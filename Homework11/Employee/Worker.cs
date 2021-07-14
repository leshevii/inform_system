using System;
namespace Homework11
{
    /// <summary>
    /// Класс представляет сущность работника с заработной платой за месяц    
    /// </summary>
    public class Worker : Employee
    {
        /// <summary>
        /// Заробатная плата за месяц
        /// </summary>
        private float _wage;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fName">Имя</param>
        /// <param name="sName">Фамилия</param>
        /// <param name="birth">Дата рождения</param>
        /// <param name="dateOfEmployment">Дата поступления на работу</param>
        /// <param name="wage">Зароботная плата</param>
        public Worker(string fName, string sName, DateTime birth, DateTime dateOfEmployment,float wage) : base(fName, sName, birth, dateOfEmployment)
        {
            _wage = wage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fName">Имя</param>
        /// <param name="sName">Фамилия</param>
        /// <param name="birth">Дата Рождения</param>
        /// <param name="wage">Заработная плата</param>
        public Worker(string fName, string sName, DateTime birth,float wage) : this(fName, sName, birth, DateTime.Now,wage) { }

        public override float Salary()
        {
            return _wage;
        }
    }
}
