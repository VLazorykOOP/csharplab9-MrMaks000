namespace Lab9_10CharpT
{
    class Employee : ICloneable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public Employee()
        {
            LastName = "";
            FirstName = "";
            MiddleName = "";
            Gender = 'M';
            Age = 0;
            Salary = 0;
        }

        public Employee(string lastName, string firstName, string middleName, char gender, int age, decimal salary)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Gender = gender;
            Age = age;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}, {MiddleName}, {Gender}, {Age}, {Salary}";
        }

        public object Clone()
        {
            return new Employee(this.LastName, this.FirstName, this.MiddleName, this.Gender, this.Age, this.Salary);
        }
    }

}
