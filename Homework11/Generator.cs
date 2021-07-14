using System;
using System.Collections.Generic;
namespace Homework11
{
    /// <summary>
    /// Реализует генерацию компании
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Label - для работника с оплатой за месяц
        /// </summary>
        private const string LWORKER = "Worker";
        /// <summary>
        /// Label - для управленца
        /// </summary>
        private const string LMANAGER = "Manager";
        /// <summary>
        /// Label - для работника с почасовой оплатой
        /// </summary>
        private const string LTIMEWORKER = "TimeWorker";
        private const string LDEPARTMENT = "Department";

        private Random randomize = new Random();
        private string _name;
        private int _maxDepLevel;
        private int _maxDepth;
        private int _maxWorkers;
        private Company _company;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Название компании</param>
        /// <param name="maxDepLevel">Максимальная глубина дочерних департаментов на 1 уровне</param>
        /// <param name="maxDepth">Максимальное число вложенных департаментов</param>
        /// <param name="maxWorkers">Максимальное число работников в департаменте</param>
        public Generator(string name="Company",int maxDepLevel=2,int maxDepth=2,int maxWorkers = 3)
        {
            _name = name;
            _maxDepLevel = maxDepLevel;
            _maxDepth = maxDepth;
            _maxWorkers = maxWorkers;

            _company = new Company(_name, GetManager(0,0), GetDepartments(randomize.Next(1, _maxDepLevel + 1),0));           
        }
        /// <summary>
        /// Возвращает менеджера
        /// </summary>
        /// <param name="index">Метка для менеджера</param>
        /// <returns>Manager</returns>
        private Manager GetManager(int index,int level)
        {
            string name = LMANAGER + index+"_"+level;
            Manager manager = new Manager(name,  "Surname"+name, DateTime.Now, DateTime.Now);
            return manager;
        }
        /// <summary>
        /// Возвращает набор департаментов 
        /// </summary>
        /// <param name="count">Количество департаментов</param>
        /// <param name="level">индекс для имене департамента</param>
        /// <returns>List<Department></returns>
        private List<Department> GetDepartments(int count,int level)
        {
            List<Department> departments = new List<Department>();
            for(int i = 0; i < count; i++)
            {
                string name = LDEPARTMENT + level + "_" + i;
                Department department = new Department(name, GetManager(level,i));
                //TODO генерация работников
                department.addEmploye(GetWorkers(randomize.Next(1, _maxWorkers + 1), level).ToArray());
                department.addEmploye(GetTimeWorkers(randomize.Next(1, _maxWorkers + 1), level).ToArray());
                departments.Add(department);
            }
            return departments;
        }

        /// <summary>
        /// Генерирует рабочик
        /// </summary>
        /// <param name="count">кол-во рабочих</param>
        /// <param name="level">уровень вложенности департамента</param>
        /// <returns></returns>
        private List<Worker> GetWorkers(int count,int level)
        {
            List<Worker> workers = new List<Worker>();
            for(int i = 0; i < count; i++)
            {
                string name = LWORKER + level + "_" + i;
                Worker worker = new Worker(name, "Surname" + name, DateTime.Now, randomize.Next(800, 2500));
                workers.Add(worker);
            }
            return workers;
        }
        private List<TimeWorker> GetTimeWorkers(int count, int level)
        {
            List<TimeWorker> workers = new List<TimeWorker>();
            for (int i = 0; i < count; i++)
            {
                string name = LTIMEWORKER + level + "_" + i;
                TimeWorker worker = new TimeWorker(name, "Surname" + name, DateTime.Now, DateTime.Now ,randomize.Next(30, 100));
                workers.Add(worker);
            }
            return workers;
        }
        /// <summary>
        /// Наполняет переданный департамент, дочерними департаментами
        /// </summary>
        /// <param name="department">Родительский департамент</param>
        /// <param name="level">Уровень вложенности</param>
        private void FillDepartments(Department department,int level)
        {
            if(level <= _maxDepLevel)
            {
                if (randomize.Next(0, 2) == 1)
                {
                    int count = randomize.Next(1, _maxDepLevel + 1);
                    List<Department> departments = GetDepartments(count, level + 1);
                    department.addDep(departments);

                    foreach (Department department1 in department.Departments)
                    {                        
                        FillDepartments(department1, level + 1);
                    }
                }
            }
        }
        /// <summary>
        /// Полность генерирует компанию
        /// </summary>
        /// <returns>Company</returns>
        public Company GetCompany()
        {
            for (int i = 0; i < _company.getCountDepartmants(); i++)
            {
                FillDepartments(_company[i], 0);
            }

            return _company;
        }
    }
}
