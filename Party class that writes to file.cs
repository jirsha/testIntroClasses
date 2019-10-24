using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WedBasesClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathProfile = System.Environment.GetEnvironmentVariable("USERPROFILE");
            string fileName = "PartyEntries.txt";
            string filePath = pathProfile + "\\" + fileName;

            FileStream file = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);


            string answer;
            Console.Write("Type of party?\n  (Enter) Birthday\n  (G) Graduation   ");
            answer = (Console.ReadLine()).ToUpper();
            if (answer == "G")
            {
                Grad partyFirst = new Grad();
                Grad partySecond = new Grad();

                Console.WriteLine("Enter preferred party plans at {0}\n\n", Party.COMPANY);

                partyFirst.IdNumber = GetID();

                partyFirst.FirstName = GetFirst();

                partyFirst.LastName = GetLast();
                //------
                partyFirst.BalloonsQuan = GetBalloons();
                //------
                partyFirst.PartyHours = GetHours();
                //-------
                partyFirst.PeopleQuan = GetPeople();
                //-------
                partyFirst.CostPerHour = GetCost();
                                
                //------------------------------------------------------
                partyFirst.School = GetSchool();
                partyFirst.SchoolCity = GetCity();
                partyFirst.MainColor = GetColor();

                //-----------------------------------------------------
                Display(partyFirst);
                Console.WriteLine();
                WriteToFile(partyFirst, filePath, writer);

                writer.Close();
                file.Close();

                partyFirst.Message();   //non-static method
                

                Party.SaySomething();  //static method
            } //if Grad
            else
            {
                Birthday partyFirst = new Birthday();
                Birthday partySecond = new Birthday();

                Console.WriteLine("Enter preferred party plans at {0}\n\n", Party.COMPANY);

                partyFirst.IdNumber = GetID();

                partyFirst.FirstName = GetFirst();

                partyFirst.LastName = GetLast();
                //------
                partyFirst.BalloonsQuan = GetBalloons();
                //------
                partyFirst.PartyHours = GetHours();
                //-------
                partyFirst.PeopleQuan = GetPeople();
                //-------
                partyFirst.CostPerHour = GetCost();

                //-----------------------------------------------------
                partyFirst.Age = GetAge();
                partyFirst.CandleType = GetCandle();
                partyFirst.CakeTheme = GetCake();

                //----------------------------------------------------

                Display(partyFirst);
                Console.WriteLine();
                WriteToFile(partyFirst, filePath, writer);

                writer.Close();
                file.Close();

                partyFirst.Message();   //non-static method
                //partySecond.Message();

                Party.SaySomething();  //static method


            } //else
        }//Main()
        static string GetCake()
        {
            string cake;
            Console.WriteLine("Cake theme:\n(C) Cats and dogs\n(M) Little Mermaid\n(Enter) Batman");
            cake = Console.ReadLine();
            if (cake.ToUpper() == "C")
            {
                cake = "Cats and dogs cake";
            }
            else
            {
                if (cake.ToUpper() == "M")
                {
                    cake = "Little Mermaid cake";
                }
                else
                {
                    cake = "Batman cake";
                }
            }
            return cake;
        }
        static string GetCandle()
        {
            string candle;
            Console.WriteLine("Candle types:\n(T) Trick\n(N) Big Numbers\n(Enter) Regular");
            candle = Console.ReadLine();
            if (candle.ToUpper() == "T")
            {
                candle = "Trick candles";
            }
            else
            {
                if (candle.ToUpper() == "N")
                {
                    candle = "Big number candles";
                }
                else
                {
                    candle = "Regular candles";
                }
            }
            return candle;
        }

        static int GetAge()
        {
            int age;
            Console.Write("What age is the birthday person?  ");
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                age = 0;
            }
            return age;
        }
        static string GetColor()
        {
            string color;
            Console.Write("What is the school's color, or Enter for N/A:  ");
            color = Console.ReadLine();
            if (color == "")
            {
                color = "N/A";
            }
            return color;
        }
        static string GetCity()
        {
            string city;
            Console.Write("Name of school's city, or Enter for N/A:  ");
            city = Console.ReadLine();
            if (city == "")
            {
                city = "N/A";
            }
            return city;
        }
        static string GetSchool()
        {
            string school;
            Console.Write("Name of school, or Enter for N/A:  ");
            school = Console.ReadLine();
            if (school == "")
            {
                school = "N/A";
            }
            return school;
        }
        static void Display(Grad theParty)
        {
            Console.WriteLine("\n\nParty ID {0} for first name: {1} last name: {2}:", theParty.IdNumber, theParty.FirstName, theParty.LastName);
            Console.WriteLine("Quantity of people attending: {0} and {1} balloons ordered", theParty.PeopleQuan, theParty.BalloonsQuan);
            Console.WriteLine("Quantity of hours: {0} and cost per hour: {1}", theParty.PartyHours, theParty.CostPerHour);
            Console.WriteLine("School name: {0}, school's city: {1} and main color: {2}\n", theParty.School, theParty.SchoolCity, theParty. MainColor);

        }
        static void WriteToFile(Grad theParty, string filePath, StreamWriter writer)
        {
            writer.WriteLine("\n\nParty ID {0} for first name: {1} last name: {2}:", theParty.IdNumber, theParty.FirstName, theParty.LastName);
            writer.WriteLine("Quantity of people attending: {0} and {1} balloons ordered", theParty.PeopleQuan, theParty.BalloonsQuan);
            writer.WriteLine("Quantity of hours: {0} and cost per hour: {1}", theParty.PartyHours, theParty.CostPerHour);
            writer.WriteLine("School name: {0}, school's city: {1} and main color: {2}\n", theParty.School, theParty.SchoolCity, theParty.MainColor);

        }
        static void WriteToFile(Birthday theParty, string filePath, StreamWriter writer)
        {
            writer.WriteLine("\n\nParty ID {0} for first name: {1} last name: {2}:", theParty.IdNumber, theParty.FirstName, theParty.LastName);
            writer.WriteLine("Quantity of people attending: {0} and {1} balloons ordered", theParty.PeopleQuan, theParty.BalloonsQuan);
            writer.WriteLine("Quantity of hours: {0} and cost per hour: {1}", theParty.PartyHours, theParty.CostPerHour);
            writer.WriteLine("Age of person: {0} cake theme: {1} candle type: {2}:", theParty.Age, theParty.CakeTheme, theParty.CandleType);
        }
        static void Display(Birthday theParty)
        {
           Console.WriteLine("\n\nParty ID {0} for first name: {1} last name: {2}:", theParty.IdNumber, theParty.FirstName, theParty.LastName);
            Console.WriteLine("Quantity of people attending: {0} and {1} balloons ordered", theParty.PeopleQuan, theParty.BalloonsQuan);
            Console.WriteLine("Quantity of hours: {0} and cost per hour: {1}", theParty.PartyHours, theParty.CostPerHour);
            Console.WriteLine("Age of person: {0} cake theme: {1} candle type: {2}:", theParty.Age, theParty.CakeTheme, theParty.CandleType);
        }
        static double GetCost()
        {
            double cost;
            Console.Write("What is the base cost per hour for the party (at least $50)?  ");
            try
            {
                cost = Convert.ToDouble(Console.ReadLine());
                if (cost < 50)
                {
                    cost = 50;
                }
                Console.WriteLine("Base cost = {0}", cost.ToString("C"));
            }
            catch (Exception)
            {
                cost = 50;
                Console.WriteLine("Base cost = {0}", cost.ToString("C"));
            }
            finally
            {
                Console.WriteLine();
            }
            return cost;
        }
        static int GetPeople()
        {
            int people;
            Console.Write("How many people will participate?  ");
            try
            {
                people = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                people = 1;
            }
            return people;
        }
        static int GetHours()
        {
            int hours;
            Console.Write("How many hours (at least 2 required)?  ");
            try
            {
                hours = Convert.ToInt32(Console.ReadLine());
                if (hours < 2)
                {
                    hours = 2;
                }
                Console.WriteLine("Hours = {0}", hours);
            }
            catch (Exception)
            {
                Console.WriteLine("Hours = 2");
                hours = 2;
                
            }
            finally
            {
                Console.WriteLine();
            }
            return hours;
        }
        static int GetBalloons()
        {
            int balloons;
            Console.Write("How many balloons?  ");
            try
            {
                balloons = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                balloons = 0;
            }
            return balloons;
        }
        static string GetLast()
        {
            string last;
            Console.Write("Last name of contact person, or Enter for N/A:  ");
            last = Console.ReadLine();
            if (last == "")
            {
                last = "N/A";
            }
            return last;
        }
        static string GetFirst()
        {
            string first;
            Console.Write("First name of contact person, or Enter for N/A:  ");
            first = Console.ReadLine();
            if (first == "")
            {
                first = "N/A";
            }
            return first;
        }
        static int GetID()
        {
            int id;
            Console.Write("Type in the ID number not less than 1000  ");
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                id = 1000;
            }
            return id;
        }








    } //Program

    class Party
    {
        private int idNumber = 1000;
        private int partyHours = 2;
        private double costPerHour = 50;

        public const string COMPANY = "Minneapolis Custom Parties";

        public int IdNumber  //silently set ID number to 1000 if less than 1001
        {                   //so min is enforced by accessor
            get
            {
                return idNumber;
            }
            set
            {
                if (value < 1001)
                {
                    idNumber = 1000;
                }
                else
                {
                    idNumber = value;
                }
            }
        }//idNumber
        public int PartyHours
        {
            get
            {
                return partyHours;
            }
            set
            {
                partyHours = value;  //calling class will make sure value >= 2
            }
        }//PartyHOUrs
        public string FirstName { get; set; }      //don't declare backing field - compiler will generate it
        public string LastName { get; set; }        //if using auto-implemented accessors
        public int BalloonsQuan { get; set; }
        public int PeopleQuan { get; set; }

        public double CostPerHour
        {
            get
            {
                return costPerHour;
            }
            set   //accessor provides restrictions
            {
                costPerHour = GetCost(value);

            }
        } //CostPerHour                             
        private double GetCost(double value)
        {
            double cost = 50;  //needs an initial value, so chose the minimum
            if (value < 75)
            {
                cost = value + (this.PeopleQuan * 10); //$75 plus $10 per person per hour
            }
            else
            {
                cost = value + (this.PeopleQuan * 20); //$75 plus $20 per person per hour
            }
            return cost;
        }
        //public method that can be called on an instance of this class (so non-static)

        public void Message()
        {
            Console.WriteLine("\n\nParty number {0} will cost {1}", idNumber, costPerHour.ToString("C"));
        }

        //public method - that applies to the class, not an instance (so static)
        public static void SaySomething()
        {
            Console.WriteLine("\n\nCreating party objects was finished by: {0}", DateTime.Now.TimeOfDay);
        }       



    }//Party

    class Birthday : Party
    {
        private int age;
        public string CandleType {get; set;}
        public string CakeTheme;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                if (age < 1)
                {
                    age = 1;
                }
                
            }
        } //Age
    } //Birthday : Party
    class Grad : Party
    {
        public string School { get; set; }
        public string SchoolCity { get; set; }
        public string MainColor { get; set; }
        
    } //Grad : Party

} //namespace
