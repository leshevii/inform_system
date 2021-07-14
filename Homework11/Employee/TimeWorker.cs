using System;
namespace Homework11
{
    /// <summary>
    /// Работник с почасовой оплатой
    /// </summary>
    public class TimeWorker : Employee
    {
        /// <summary>
        /// Колличество 
        /// </summary>
        private const int HOURS = 30;
        /// <summary>
        /// Заробатная плата за 1 hour
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
        public TimeWorker(string fName,string sName,DateTime birth,DateTime dateOfEmployment,float wage) : base(fName, sName, birth, dateOfEmployment) { _wage = wage; }

        public override float Salary()
        {
            return _wage * HOURS;
        }
    }
}
