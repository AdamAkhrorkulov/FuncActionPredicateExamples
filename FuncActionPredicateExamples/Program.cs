using System.Data.Common;

namespace FuncActionPredicateExamples
{
    internal class Program
    {
        //delegate TResult Func2<out TResult>();
        //delegate TResult Func2<in T1, out TResult>(T1 arg);
        //delegate TResult Func2<in T1, in T2, out TResult>(T1 arg, T2 arg2);
        //delegate TResult Func2<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);
        static void Main(string[] args)
        {
            //MathClass math = new MathClass();
            //Func2<int, int, int> calc = (a, b) => a + b;
            //int result = calc(2,5);
            //Console.WriteLine($"The result is: {result}");

            //float d = 2.3f, e = 4.56f;
            //int f = 5;

            //Func<float, float, int, float> calc2 = (arg1, arg2, arg3) => (arg1 + arg2) * arg3;
            //float result2 = calc2(d,e,f);
            //Console.WriteLine($"The result: {result2}");
            //Console.ReadKey();

            Action<int, string, string, decimal, char, bool> displayEmploeeDetails = (arg1, arg2, arg3, arg4, arg5, arg6) 
                => Console.WriteLine($"ID: {arg1}{Environment.NewLine}First Name: {arg2}{Environment.NewLine}Last Name: {arg3}{Environment.NewLine}" +
                $"Annual Salary: {arg4}{Environment.NewLine}Gender: {arg5}{Environment.NewLine}Manager: {arg6}{Environment.NewLine}");

            //displayEmploeeRecords(1, "Adam", "Akhror", 60000, 'f', true);

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, FirstName = "Rukhshona", LastName = "Akhror", AnnualSalary = 60000, Gender = 'f', IsManager = true });
            employees.Add(new Employee { Id = 2, FirstName = "Amir", LastName = "Asror", AnnualSalary = 80000, Gender = 'm', IsManager = false });

            //List<Employee> employeesFiltered = FilterEmployees(employees, e => e.AnnualSalary > 60000);
            //List<Employee> employeesFiltered = employees.FilterEmployees(e => e.AnnualSalary > 60000);
            List<Employee> employeesFiltered = employees.Where(e => e.AnnualSalary > 60000).ToList();

            foreach (Employee employee in employeesFiltered)
            {
                displayEmploeeDetails(employee.Id, employee.FirstName, employee.LastName, employee.AnnualSalary, employee.Gender, employee.IsManager);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        
    }

    public static class Extensions 
    {
        public static List<Employee> FilterEmployees(this List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> employeesFiltered = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    employeesFiltered.Add(employee);
                }
            }
            return employeesFiltered;
        }
    } 

  
    public class Employee 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }
       
    }
    public class MathClass  
    {
        public int Addition(int a, int b)
        {
            return a + b;
        }
    }
}