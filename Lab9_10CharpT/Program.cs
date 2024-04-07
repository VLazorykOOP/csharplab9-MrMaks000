using System.Collections;

namespace Lab9_10CharpT
{
    class Program
    {
        static void Main(string[] args)
        {
            char n;
            while(true)
            {
                Console.Write("\nSelect the task number(1/4):");
                n = Convert.ToChar(Console.ReadLine());

                switch(n)
                {
                    case '1': Task1(); break;
                    case '2': Task2(); break;
                    case '3': Task3(); break;
                    case '4': Task4(); break;
                    default: Console.WriteLine("\nProgram has ended "); return;
                }
            }
        }

        private static void Task1()
        {
            Console.WriteLine("Task1");
            string formula = "(M(m(3,5),M(1,2)))"; // Вхідна формула
            int result = EvaluateFormula(formula);
            Console.WriteLine("Значення формули {0} = {1}", formula, result);
        }

        private static void Task2()
        {
            Console.WriteLine("Task2");
            string filePath = "employees.txt"; // Шлях до файл
            Queue employees = ReadEmployeesFromFileQueue(filePath);

            Queue youngerThan30Queue = new Queue();
            Queue olderThan30Queue = new Queue();

            foreach (Employee emp in employees)
            {
                if (emp.Age < 30)
                    youngerThan30Queue.Enqueue(emp.Clone());
                else
                    olderThan30Queue.Enqueue(emp.Clone());
            }

            Console.WriteLine("Employees younger than 30:");
            PrintCollection(youngerThan30Queue);

            Console.WriteLine("Other employees:");
            PrintCollection(olderThan30Queue);
        }

        private static void Task3()
        {
            Console.WriteLine("Task3");
            string filePath = "employees.txt";
            ArrayList employees2 = ReadEmployeesFromFileList(filePath);

            ArrayList youngerThan30ArrayList = new ArrayList();
            ArrayList olderThan30ArrayList = new ArrayList();

            foreach (Employee emp in employees2)
            {
                if (emp.Age < 30)
                    youngerThan30ArrayList.Add(emp.Clone());
                else
                    olderThan30ArrayList.Add(emp.Clone());
            }

            Console.WriteLine("Employees younger than 30:");
            PrintCollection(youngerThan30ArrayList);

            Console.WriteLine("Other employees:");
            PrintCollection(olderThan30ArrayList);
        }

        private static void Task4()
        {
            Console.WriteLine("Task4");
            MusicCatalog catalog = new MusicCatalog();

            MusicCD cd1 = new MusicCD("CD1");
            cd1.AddSong(new Song("Song1", "Artist1"));
            cd1.AddSong(new Song("Song2", "Artist2"));
            catalog.AddCD(cd1);

            MusicCD cd2 = new MusicCD("CD2");
            cd2.AddSong(new Song("Song3", "Artist1"));
            cd2.AddSong(new Song("Song4", "Artist3"));
            catalog.AddCD(cd2);

            catalog.DisplayCatalog();

            catalog.DisplayCDContent("CD1");
            catalog.SearchByArtist("Artist1");
        }

        private static int EvaluateFormula(string formula)
        {
            Stack<int> operands = new Stack<int>();
            Stack<char> operators = new Stack<char>();

            formula = formula.Substring(0, formula.Length - 1);
            foreach (char c in formula)
            {
                if (Char.IsDigit(c))
                {
                    operands.Push(Convert.ToInt32(c.ToString()));
                }
                else if (c == 'm' || c == 'M')
                {
                    operators.Push(c);
                }
                else if (c == ')')
                {
                    int operand1 = operands.Pop();
                    int operand2 = operands.Pop();
                    char operation = operators.Pop();
                    int result;

                    if (operation == 'm')
                    {
                        result = Math.Min(operand1, operand2);
                    }
                    else // operation == 'M'
                    {
                        result = Math.Max(operand1, operand2);
                    }

                    operands.Push(result);
                }
            }

            return operands.Pop();
        }

        private static Queue ReadEmployeesFromFileQueue(string filePath)
        {
            Queue employees = new Queue();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(',');

                    Employee employee = new Employee
                    {
                        LastName = data[0],
                        FirstName = data[1],
                        MiddleName = data[2],
                        Gender = char.Parse(data[3]),
                        Age = int.Parse(data[4]),
                        Salary = decimal.Parse(data[5])
                    };
                    employees.Enqueue(employee);
                }
            }
            return employees;
        }

        private static ArrayList ReadEmployeesFromFileList(string filePath)
        {
            ArrayList employees = new ArrayList();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(',');

                    Employee employee = new Employee
                    {
                        LastName = data[0],
                        FirstName = data[1],
                        MiddleName = data[2],
                        Gender = char.Parse(data[3]),
                        Age = int.Parse(data[4]),
                        Salary = decimal.Parse(data[5])
                    };
                    employees.Add(employee);
                }
            }
            return employees;
        }

        private static void PrintCollection(Queue collection)
        {
            foreach (object item in collection)
            {
                Console.WriteLine(item);
            }
        }
        private static void PrintCollection(ArrayList collection)
        {
            foreach (object item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}







