namespace TaskManager.User
{
    using System;
    using System.Text;

    using Enums;
    using Validation;
    using User.Interfaces;

    public abstract class Person : IPerson
    {
        
        private const string GeneralPlaceHolderShablonToString = "Name: {0}, Date of Birth: {1}, Sex: {2}, Age: {3}";

        private readonly IPersonValidation validation = new PersonValidation();

        private string name;
        private DateTime dateBirth;


        public Person(string name, DateTime dateBirth, Gender sex)
        {
            this.Name = name;
            this.dateBirth = dateBirth;
            this.Sex = sex;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.validation.ValidateName(value);

                this.name = value;
            }
        }

        public Gender Sex { get; private set; }

        public DateTime DateBirth
        {
            get
            {
                return this.dateBirth;
            }

            private set
            {
                this.validation.ValidateDateOfBirth(value);

                this.dateBirth = value;
            }
          
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - this.dateBirth.Year;
            }
            
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() << this.dateBirth.GetHashCode() ^ 20;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format(GeneralPlaceHolderShablonToString, this.Name, this.DateBirth.ToShortDateString(), this.Sex, this.Age));
            return result.ToString();
        }

        protected IPersonValidation Validation { get { return this.validation; } }
    }
}
