using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR8
{
    interface IEquipment
    {
        void Clothes();
        void Trainer();
        void TrainingPlace();
        void Nutrition();
    }
    class LowLevelEquipment : IEquipment
    {
        public void Clothes()
        {
            Console.WriteLine("You wear normal clothes");
        }
        public void Trainer()
        {
            Console.WriteLine("You don't have your own coach");
        }
        public void TrainingPlace()
        {
            Console.WriteLine("You train at home or on the sports ground");
        }
        public void Nutrition()
        {
            Console.WriteLine("Your diet is no different from usual diet");
        }
    }
    class MedLevelEquipment : IEquipment
    {
        public void Clothes()
        {
            Console.WriteLine("You are wearing branded sportswear");
        }
        public void Trainer()
        {
            Console.WriteLine("You work with a personal coach");
        }
        public void TrainingPlace()
        {
            Console.WriteLine("You work out in the gym");
        }
        public void Nutrition()
        {
            Console.WriteLine("You are on a sports diet");
        }
    }
    class HighLevelEquipment : IEquipment
    {
        public void Clothes()
        {
            Console.WriteLine("You wear top class clothing");
        }
        public void Trainer()
        {
            Console.WriteLine("You are trained by the best coaches");
        }
        public void TrainingPlace()
        {
            Console.WriteLine("You train in expensive gyms");
        }
        public void Nutrition()
        {
            Console.WriteLine("You are following a diet designed for you");
        }
    }
    interface ICompetable
    {
        void Compete();
        void DopingTest();
    }
    class Human : IComparable
    {
        protected static int amountOfObjects = 0;
        protected string name;
        protected string surname;
        protected string patronymic;
        protected int age;
        protected string gender;
        protected string nationality;
        private string phoneNumber;
        private string emailAddress;
        private string vkAddress;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }


        public Human() { }
        public Human(string name, string surname, string patronymic, int age, string gender, string nationality)
        {
            amountOfObjects++;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.age = age;
            this.gender = gender;
            this.nationality = nationality;
        }

        public int CompareTo(object s)
        {
            Human subject = s as Human;
            if (subject != null)
                return this.age.CompareTo(subject.Age);
            else
                throw new Exception("Unable to compare these objects");
        }
        public void InitHuman()
        {
            Console.Write("Enter name:\n>> ");
            this.Name = Human.ValidWordInput();
            Console.Write("Enter surname:\n>> ");
            this.Surname = Human.ValidWordInput();
            Console.Write("Enter patronymic:\n>> ");
            this.Patronymic = Human.ValidWordInput();
            Console.Write("Enter age:\n>> ");
            do
            {
                this.Age = Human.ValidIntInput();
            } while (Human.CheckAge(this.age));
            Console.Write("Enter gender (Male/Female):\n>> ");
            do
            {
                this.Gender = Human.ValidWordInput();
            } while (Human.CheckGender(this.gender));
            Console.Write("Enter nationality:\n>> ");
            this.Nationality = Human.ValidWordInput();
        }
        public static string ValidWordInput()
        {
            string input;
            StringBuilder str = new StringBuilder();
            do
            {
                bool error = false;
                input = Console.ReadLine();
                if (input.Length == 0)
                {
                    Console.Write("You haven't typed anythyng. Try again:\n>> ");
                    continue;
                }
                for (int i = 0; i < input.Length; i++)
                {
                    if (!char.IsLetter(input[i]))
                    {
                        Console.Write("You have entered invalid symbols. Try again:\n>> ");
                        error = true;
                        break;
                    }
                }
                if (error) continue;
                else break;
            } while (true);
            str.Append(input.ToLower());
            str[0] = char.ToUpper(str[0]);
            return str.ToString();
        }
        public static int ValidIntInput()
        {
            string input;
            int result;
            while (true)
            {
                input = Console.ReadLine();
                if (!int.TryParse(input, out result))
                {
                    Console.Write("You have entered invalid symbols or you haven't typed anything. Try again:\n>> ");
                    continue;
                }
                else if (Convert.ToInt32(input) < 0)
                {
                    Console.WriteLine("Input must be positive. Try again:\n>> ");
                    continue;
                }
                else break;
            }
            return result;
        }
        public static double ValidDoubleInput()
        {
            string input;
            double result;
            while (true)
            {
                input = Console.ReadLine();
                if (!double.TryParse(input, out result))
                {
                    Console.Write("You have entered invalid symbols or you haven't typed anything. Try again:\n>> ");
                    continue;
                }
                else if (Convert.ToDouble(input) < 0)
                {
                    Console.WriteLine("Input must be positive. Try again:\n>> ");
                    continue;
                }
                else break;
            }
            return result;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{this.surname} {this.name} {this.patronymic}\n" +
                $"Age: {this.age} years\nGender: {this.gender}\nNationality: {this.nationality}");
        }
        public void ShowContacts()
        {
            Console.WriteLine($"Phone number: {this["phone"]}\nEmail address: {this["email"]}\nVK address: {this["vk"]}");
        }
        public static bool CheckAge(int age)
        {
            if (age <= 0)
            {
                Console.Write("Age must be positive. Try again:\n>> ");
                return true;
            }
            else if (age < 5)
            {
                Console.Write("Age must be greater than 5. Try again:\n>> ");
                return true;
            }
            else if (age > 125)
            {
                Console.Write("Age must be less than 125. Try again:\n>> ");
                return true;
            }
            else return false;
        }
        public static bool CheckGender(string gender)
        {
            if (gender != "Male" && gender != "Female")
            {
                Console.Write("Gender must be male or female. Try again:\n>> ");
                return true;
            }
            else return false;
        }
        public void GrowUp()
        {
            this.age++;
        }

        public string this[string index]
        {
            get
            {
                switch (index)
                {
                    case "phone":
                        return phoneNumber;
                    case "email":
                        return emailAddress;
                    case "vk":
                        return vkAddress;
                    default:
                        return null;
                }
            }
            set
            {
                switch (index)
                {
                    case "phone":
                        phoneNumber = value;
                        break;
                    case "email":
                        emailAddress = value;
                        break;
                    case "vk":
                        vkAddress = value;
                        break;
                }
            }
        }
    }
    abstract class Sportsman : Human
    {
        static protected object record = 0;
        protected int careerLength;
        protected int goldMedals = 0;
        protected int silverMedals = 0;
        protected int bronzeMedals = 0;
        protected int salary;
        protected int category;

        public IEquipment Equipment { get; set; }
        public int CareerLength
        {
            get { return careerLength; }
            set { careerLength = value; }
        }
        public int GoldMedals
        {
            get { return goldMedals; }
            set { goldMedals = value; }
        }
        public int SilverMedals
        {
            get { return silverMedals; }
            set { silverMedals = value; }
        }
        public int BronzeMedals
        {
            get { return bronzeMedals; }
            set { bronzeMedals = value; }
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public void SetCategory()
        {
            Console.WriteLine("Enter a category:\n>> ");
            switch (ValidWordInput())
            {
                case "None":
                    category = Convert.ToInt32(Category.None);
                    break;
                case "Third":
                    category = Convert.ToInt32(Category.Third);
                    break;
                case "Second":
                    category = Convert.ToInt32(Category.First);
                    break;
                case "Candidate":
                    category = Convert.ToInt32(Category.Candidate);
                    break;
                case "Master":
                    category = Convert.ToInt32(Category.Master);
                    break;
                case "InternationalMaster":
                    category = Convert.ToInt32(Category.InternationalMaster);
                    break;
            }
        }
        public void GetCategory()
        {
            switch (category)
            {
                case 0:
                    Console.WriteLine("None");
                    break;
                case 1:
                    Console.WriteLine("Third youth rank");
                    break;
                case 2:
                    Console.WriteLine("Second youth rank");
                    break;
                case 3:
                    Console.WriteLine("First youth rank");
                    break;
                case 4:
                    Console.WriteLine("Сandidate to master sport");
                    break;
                case 5:
                    Console.WriteLine("Master of sport");
                    break;
                case 6:
                    Console.WriteLine("International master of sports");
                    break;
            }
        }

        public enum Category
        {
            None = 0,
            Third = 1,
            Second = 2,
            First = 3,
            Candidate = 4,
            Master = 5,
            InternationalMaster = 6
        }

        protected Sportsman(string name, string surname, string patronymic, int age, string gender, string nationality) : base(name, surname, patronymic, age, gender, nationality)
        {

        }
        protected Sportsman(Human subject)
        {
            amountOfObjects++;
            this.name = subject.Name;
            this.surname = subject.Surname;
            this.patronymic = subject.Patronymic;
            this.age = subject.Age;
            this.gender = subject.Gender;
            this.nationality = subject.Nationality;
        }
        protected Sportsman() : base() { }

        virtual public void GetAllInfo()
        {
            this.ShowInfo();
            Console.WriteLine($"Career: {careerLength} years\nGold medals: {goldMedals}\nSilver medals: {silverMedals}\n" +
                $"Bronze medals: {bronzeMedals}\nSalary: {salary} conventional units\nCategory: ");
            this.GetCategory();
        }
        public void GoJogging()
        {
            Console.WriteLine("You went for a jogging");
        }
        public void GoToGym()
        {
            Console.WriteLine("You went to the gym");
        }
        abstract public void SpecialTraining();
        public void GetSalary()
        {
            Console.WriteLine($"You received a salary of {salary} conventional units");
        }
    }
    sealed class Footballer : Sportsman, IComparable, ICompetable
    {
        public delegate void SalaryHandler(int salary);
        public delegate void MedalHandler(int bronze, int silver, int gold);
        public event SalaryHandler SalaryNotify;
        public event MedalHandler MedalNotify;

        private string club = "None";
        private int scoredGoals;

        public string Club
        {
            get { return club; }
            set { club = value; }
        }
        public int ScoredGoals
        {
            get { return scoredGoals; }
            set { scoredGoals = value; }
        }

        public Footballer(string name, string surname, string patronymic, int age, string gender, string nationality, string club, int scoredGoals) : base(name, surname, patronymic, age, gender, nationality)
        {
            this.club = club;
            this.scoredGoals = scoredGoals;
        }
        public Footballer() : base() { }
        public Footballer(Human subject) : base(subject) { }

        public new int CompareTo(object s)
        {
            Footballer subject = s as Footballer;
            if (subject != null)
                return this.scoredGoals.CompareTo(subject.scoredGoals);
            else throw new Exception("Unable to compare these objects");
        }
        public override void GetAllInfo()
        {
            base.GetAllInfo();
            Console.WriteLine($"Player's club: {club}");
        }
        public override void SpecialTraining()
        {
            Console.WriteLine("You had a training session with renowned football coaches");
        }
        public void Compete()
        {
            Random result = new Random();
            int place = result.Next(1, 16);
            Console.WriteLine($"Your team took {place} place");
            if (place == 1)
            {
                Console.WriteLine("You received a gold medal!");
                goldMedals++;
                salary += 150;
            }
            else if (place == 2)
            {
                Console.WriteLine("You received a silver medal!");
                silverMedals++;
                salary += 100;
            }
            else if (place == 3)
            {
                Console.WriteLine("You received a bronze medal!");
                bronzeMedals++;
                salary += 50;
            }
            SalaryNotify?.Invoke(salary);
            MedalNotify?.Invoke(bronzeMedals, silverMedals, goldMedals);
        }
        public void DopingTest()
        {
            Random result = new Random();
            if (result.Next(1, 20) == 10) throw new Exception("You failed the doping test\n");
            else Console.WriteLine("The doping test has been passed. You are admitted to the tournament");
        }
    }
    sealed class Athlete : Sportsman, IComparable, ICompetable
    {
        public delegate void SalaryHandler(int salary);
        public delegate void MedalHandler(int bronze, int silver, int gold);
        public event SalaryHandler SalaryNotify;
        public event MedalHandler MedalNotify;

        private string specialization;

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public Athlete(string name, string surname, string patronymic, int age, string gender, string nationality, string specialization) : base(name, surname, patronymic, age, gender, nationality)
        {
            this.specialization = specialization;
        }
        public Athlete() : base() { }
        public Athlete(Human subject) : base(subject) { }

        public new int CompareTo(object s)
        {
            Athlete subject = s as Athlete;
            if (subject != null)
                return this.specialization.CompareTo(subject.specialization);
            else throw new Exception("Unable to compare these objects");
        }
        public override void GetAllInfo()
        {
            if (specialization == null) throw new Exception("You haven't set the athlet's specialization\n");
            base.GetAllInfo();
            Console.WriteLine($"Athlete's specialization: {specialization}");
        }
        public override void SpecialTraining()
        {
            if (specialization == "None")
            {
                Console.WriteLine("You have practiced athletics");
            }
            else
            {
                Console.WriteLine($"You hone your {specialization} skills");
            }
        }
        public void Compete()
        {
            if (specialization == null) throw new Exception("You haven't set the athlet's specialization\n");
            Random result = new Random();
            double distance = 60 * result.NextDouble();
            int place;
            if (distance > Convert.ToDouble(record))
            {
                Console.WriteLine($"Congratulations! You have set a new record: {distance} meters!");
                record = distance;
                place = 1;
            }
            else
            {
                place = result.Next(1, 16);
            }
            Console.WriteLine($"You took {place} place");
            if (place == 1)
            {
                Console.WriteLine("You received a gold medal!");
                goldMedals++;
                salary += 150;
            }
            else if (place == 2)
            {
                Console.WriteLine("You received a silver medal!");
                silverMedals++;
                salary += 100;
            }
            else if (place == 3)
            {
                Console.WriteLine("You received a bronze medal!");
                bronzeMedals++;
                salary += 50;
            }
            SalaryNotify?.Invoke(salary);
            MedalNotify?.Invoke(bronzeMedals, silverMedals, goldMedals);
        }
        public void DopingTest()
        {
            Random result = new Random();
            if (result.Next(1, 20) == 10) throw new Exception("You failed the doping test\n");
            else Console.WriteLine("The doping test has been passed. You are eligible to compete in athletics");
        }
    }
    sealed class Weightlifter : Sportsman, IComparable, ICompetable
    {
        public delegate void SalaryHandler(int salary);
        public delegate void MedalHandler(int bronze, int silver, int gold);
        public event SalaryHandler SalaryNotify;
        public event MedalHandler MedalNotify;

        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Weightlifter(string name, string surname, string patronymic, int age, string gender, string nationality, int weight) : base(name, surname, patronymic, age, gender, nationality)
        {
            this.weight = weight;
        }
        public Weightlifter() : base() { }
        public Weightlifter(Human subject) : base(subject) { }


        public new int CompareTo(object s)
        {
            Weightlifter subject = s as Weightlifter;
            if (subject != null)
            {
                return this.weight.CompareTo(subject.weight);
            }
            else throw new Exception("Unable to compare these objects");
        }
        public override void GetAllInfo()
        {
            base.GetAllInfo();
            Console.WriteLine($"Weight: {weight}");
        }
        public override void SpecialTraining()
        {
            Console.WriteLine("You did a barbell workout");
        }
        public void Compete()
        {
            Random result = new Random();
            int totalWeight = result.Next(60, 250);
            int place;
            if (totalWeight > Convert.ToInt32(record))
            {
                Console.WriteLine($"Congratulations! You have set a new record: {totalWeight} kg!");
                record = totalWeight;
                place = 1;
            }
            else
            {
                place = result.Next(1, 16);
            }
            Console.WriteLine($"You took {place} place");
            if (place == 1)
            {
                Console.WriteLine("You received a gold medal!");
                goldMedals++;
                salary += 150;
            }
            else if (place == 2)
            {
                Console.WriteLine("You received a silver medal!");
                silverMedals++;
                salary += 100;
            }
            else if (place == 3)
            {
                Console.WriteLine("You received a bronze medal!");
                bronzeMedals++;
                salary += 50;
            }
            SalaryNotify?.Invoke(salary);
            MedalNotify?.Invoke(bronzeMedals, silverMedals, goldMedals);
        }
        public void DopingTest()
        {
            Random result = new Random();
            if (result.Next(1, 20) == 10) throw new Exception("You failed the doping test\n");
            else Console.WriteLine("The doping test has been passed. You are eligible to compete in weightlifting");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Footballer Lionella = new Footballer();
            Lionella.SalaryNotify += salary => Console.WriteLine($"Current salary: {salary}\n");
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Lionella.DopingTest();
                    Lionella.Compete();
                }
                catch (Exception details)
                {
                    Console.WriteLine(details.Message);
                }
            }
            Weightlifter Tolya = new Weightlifter();
            Tolya.MedalNotify += delegate (int bronzeMedals, int silverMedals, int goldMedals)
            {
                Console.WriteLine($"Current medals:\nGold: {goldMedals}\nSilver: {silverMedals}\nBronze: {bronzeMedals}\n");
            };
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Tolya.DopingTest();
                    Tolya.Compete();
                }
                catch (Exception details)
                {
                    Console.WriteLine(details.Message);
                }
            }
            Athlete Matvey = new Athlete();
            try
            {
                Matvey.Compete();
            }
            catch (Exception details)
            {
                Console.WriteLine(details.Message);
            }
            Matvey.Specialization = "Javelin-throwing";
            try
            {
                Matvey.Compete();
            }
            catch (Exception details)
            {
                Console.WriteLine(details.Message);
            }
            Console.ReadKey();
        }
    }
}
