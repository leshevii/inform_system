using System;
using System.Collections.Generic;
namespace Homework11
{
    /// <summary>
    /// Тип департамент
    /// </summary>
    public class Department
    {
        /// <summary>
        /// наименование
        /// </summary>
        private string _name;
        /// <summary>
        /// руководитель
        /// </summary>
        private Manager _manager;
        /// <summary>
        /// дочерние департаменты
        /// </summary>
        private List<Department> _departments = new List<Department>();
        /// <summary>
        /// сотрудники текущего департамента
        /// </summary>
        private List<Employee> _employees = new List<Employee>();
        /// <summary>
        /// позволяет добавить сотрудников типа worker
        /// </summary>
        /// <param name="worker">Рабочий с фиксированной платой</param>
        private void cloneTo(Worker worker)
        {
            _employees.Add(worker);
        }
        /// <summary>
        /// позволяет добавить коллекцию сотрудников типа worker
        /// </summary>
        /// <param name="workers">Коллекция рабочих с фиксированной платой</param>
        private void cloneTo(Worker[] workers)
        {
            foreach(Worker worker in workers)
            {
                _employees.Add(worker);
            }
        }
        /// <summary>
        /// позволяет добавить сотрудников типа TimeWorker
        /// </summary>
        /// <param name="worker">Рабочий с повременной оплатой</param>
        private void cloneTo(TimeWorker worker)
        {
            _employees.Add(worker);
        }
        /// <summary>
        /// позволяет добавить коллекцию сотрудников типа TimeWorker
        /// </summary>
        /// <param name="workers">коллекция повременьщиков</param>
        private void cloneTo(TimeWorker[] workers)
        {
            foreach (TimeWorker worker in workers)
            {
                _employees.Add(worker);
            }
        }        
        /// <summary>
        /// Вывод информации о рабочих
        /// </summary>
        private void PrintInfoEmployes()
        {
            Console.WriteLine("Рабочие департамента: ");
            foreach(Employee employee in _employees)
            {
                Console.WriteLine(employee);
            }
        }
        /// <summary>
        /// Получает наименование всех дочерних департаментов текущего департамента
        /// </summary>
        /// <param name="department">корневой департамент</param>
        /// <returns>string</returns>
        private string GetAllSubDepartmentNames(Department department)
        {
            string names = department.Name;
            foreach (Department department1 in department.Departments)
            {
                names += "," + GetAllSubDepartmentNames(department1);
            }
            return names;
        }
        /// <summary>
        /// Возвращает коллекцию всех сотрудников для переданного департамента
        /// </summary>
        /// <param name="department">корневой департамент</param>
        /// <returns>List<Employee></returns>
        public static List<Employee> getAllEmployes(Department department)
        {
            List<Employee> employees = new List<Employee>();
            employees.AddRange(department.Stаff);
            foreach (Department department1 in department.Departments)
            {
                employees.Add(department1.Manager);
                employees.AddRange(getAllEmployes(department1));
            }

            return employees;
        }
        /// <summary>
        /// Коллекция сотрудников с учетом менеджера (для директора)
        /// </summary>
        /// <param name="department">корневой департамент</param>
        /// <returns></returns>
        public static List<Employee> getAllEmployesWithManager(Department department)
        {
            List<Employee> employees = new List<Employee>();
            employees.AddRange(department.Stаff);
            employees.Add(department.Manager);
            foreach (Department department1 in department.Departments)
            {
                employees.Add(department1.Manager);
                employees.AddRange(getAllEmployes(department1));
            }

            return employees;
        }
        /// <summary>
        /// Имя департамента
        /// </summary>
        public string Name
        {
            get => _name;            
        }
        /// <summary>
        /// Руководитель департамента
        /// </summary>
        public Manager Manager
        {
            get
            {                
                return _manager;
            }
        }
        /// <summary>
        /// Персонал текущего дкпартамента
        /// </summary>
        public List<Employee> Stаff
        {
            get => _employees;
        }

        /// <summary>
        /// Базовый конструктор описывающий основную реализацию
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="manager">управляющий</param>
        /// <param name="departments">дочерние департаменты</param>
        /// <param name="workers">рабочие с фиксированной оплатой</param>
        /// <param name="timeWorkers">повременьщики</param>
        public Department(string name, Manager manager, List<Department> departments, List<Worker> workers, List<TimeWorker> timeWorkers)
        {
            _name = name;
            _manager = manager;
            _departments = departments;
            addEmploye(workers.ToArray());
            addEmploye(timeWorkers.ToArray());
            _manager.fillStaff(getAllEmployes(this));
        }

        public Department(string name, Manager manager):this(name,manager,new List<Department>(),new List<Worker>(),new List<TimeWorker>()) { }               
        public Department(string name, Manager manager,  List<Worker> workers, List<TimeWorker> timeWorkers) : this(name, manager, new List<Department>(), workers, timeWorkers) { }      
        public Department(string name, Manager manager,  List<Department> departments,List<Worker> workers) : this(name, manager,departments, workers, new List<TimeWorker>()) { }                
        public Department(string name, Manager manager,  List<Department> departments,List<TimeWorker> timeWorkers) : this(name, manager, departments, new List<Worker>(), timeWorkers) { }
        /// <summary>
        /// Список дочерних департаментов
        /// </summary>
        public List<Department> Departments
        {
            get => _departments;
        }
        /// <summary>
        /// Индексатор департамента
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public Department this[int num]
        {
            get { return _departments[num]; }
        }

        public void addDep(Department dep)
        {
            _departments.Add(dep);
            _manager.fillStaff(getAllEmployes(this));
        }

        public void addDep(List<Department> departments)
        {
            _departments.AddRange(departments);
            _manager.fillStaff(getAllEmployes(this));
        }

        public void addEmploye(Worker worker)
        {
            cloneTo(worker);
            _manager.fillStaff(getAllEmployes(this));
        }
        public void addEmploye(Worker[] workers)
        {
            cloneTo(workers);            
            _manager.fillStaff(getAllEmployes(this));
        }
        public void addEmploye(TimeWorker worker)
        {
            cloneTo(worker);
            _manager.fillStaff(getAllEmployes(this));
        }
        public void addEmploye(TimeWorker[] workers)
        {
            cloneTo(workers);
            _manager.fillStaff(getAllEmployes(this));
        }
        /// <summary>
        /// Выводит заголовк департамента
        /// </summary>
        /// <param name="parentName">имя родительсокго департамента</param>
        public void printHeader(string parentName)
        {
            if(parentName == null)
               Console.WriteLine($"-----------------{_name}---------------");
            else
               Console.WriteLine($"[!Главный({parentName}) :: Дочерний({_name})!]");
        }
        /// <summary>
        /// Вывод полной информации для департамента
        /// </summary>
        /// <param name="parentName">Имя родитеольтского департамента</param>
        public void printInfo(string parentName=null)
        {
            Console.WriteLine();
            printHeader(parentName);
            Console.WriteLine("Депортамент - " + _name);
            Console.WriteLine("Управляющий - " + Manager);
            Console.WriteLine("Кол-во.деп  - " + Departments.Count);
            Console.WriteLine("Кол-во.раб  - " + _employees.Count);
            PrintInfoEmployes();
            Console.WriteLine($"---------------------------------------------");            
        }

    }
}
