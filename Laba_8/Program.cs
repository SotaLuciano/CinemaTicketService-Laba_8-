using System;
using System.IO;
using System.Collections.Generic;

namespace Laba_8
{
    class TicketService
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Are you regular viewer? Y/N");
            char choise = Convert.ToChar(Console.ReadLine());
            bool Allow = false;
            if (choise == 'Y' || choise == 'y')
            {
                Regular_Viewer User = new Regular_Viewer();
                User.Authorization();
                User.Points++;
                Allow = true;

            }
            else
            {
                Console.WriteLine("Do you want to create regular account? Y/N");
                choise = Convert.ToChar(Console.ReadLine());
                if (choise == 'Y' || choise == 'y')
                {
                    Regular_Viewer User = new Regular_Viewer();
                    User.AddInfo();
                    User.Points++;
                    Allow = true;
                }
                else { Viewer User = new Viewer(); }

            }
            TimeTable Time = new TimeTable();
            Console.WriteLine();
            Console.WriteLine("\tTime Table:");
            Time.Show_Time_Table();
            Time.Create_Sold_Reserved_Files();
            Console.WriteLine("Enter number of session: ");
            int Session = Convert.ToInt32(Console.ReadLine());
            Session--;
            Cinema cinema = new Cinema();
            Time.Show_Number_Seat(Time.StartFilm[Session], Time.Name_Of_Cinema[Session]);
            Console.WriteLine("Enter number of ticket, you want: ");
            int Num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter seat of ticket, you want: ");
            int Seat_ = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Press 1, if you want to buy!");
            Console.WriteLine("Press 2, if you want to reserv!");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 1:
                    {
                        cinema.Sale(Time.StartFilm[Session], Time.EndFilm[Session], Time.Name_Of_Cinema[Session], Num, Seat_, Time.Name_Film[Session]);
                        break;
                    }
                case 2:
                    {
                        if (Allow)
                        {
                            cinema.Reserv(Time.StartFilm[Session], Time.EndFilm[Session], Time.Name_Of_Cinema[Session], Num, Seat_, Time.Name_Film[Session]);
                        }
                        else
                        { Console.WriteLine("Your are not regular viewer!");
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong number!");
                        break;
                    }
            }
            Console.WriteLine("Main program successfully ended!");
            Console.WriteLine("Do you want to test 'List'?Y/N");
            choise = Convert.ToChar(Console.ReadLine());
            if (choise == 'Y' || choise == 'y')
            {
                Cinema A = new Cinema();
                A.Name = "AA";
                Cinema B = new Cinema();
                B.Name = "BB";
                Cinema C = new Cinema();
                C.Name = "CC";
                Cinema D = new Cinema();
                D.Name = "DD";
            Time[0] = A;
            Time[1] = B;
            Time[2] = C;
            Time[3] = D;
          
              Console.WriteLine(Time[C].ToString());
            }

        }

        interface IInterface
        {
            string Name { get; set; }
            int Number { get; set; }
            int Seat { get; set; }
            void Write_Sold_Number_Seat(double Start_F, string Name_Cinema, int _Number, int _Seat);
        }

        class Cinema : IInterface
        {
            public string Name { get; set; }
            public int Max_Number = 15; // Ряд
            public int Max_Seat = 18;   //Місце
            public int Number { get; set; }
            public int Seat { get; set; }

            public Cinema()
            {
                Name = "";
                Number = 0;
                Seat = 0;
            }

            public void Write_Sold_Number_Seat(double Start_F, string Name_Cinema, int _Number, int _Seat)
            {
                if (_Number > 0 && _Number <= Max_Number && _Seat > 0 && _Seat <= Max_Seat)
                {
                    string text = "\n" + _Number.ToString() + " " + _Seat.ToString();
                    string name = Start_F.ToString() + "_" + Name_Cinema;
                    string road = @"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\TimeTable\" + name + "_Sold.txt";
                    StreamWriter sw = new StreamWriter(road, true);
                    sw.Write(text);
                    sw.Close();
                }
                else { Console.WriteLine("Wrong number/seat!"); return; }
            }

            public void Write_Reserv_Number_Seat(double Start_F, string Name_Cinema, int _Number, int _Seat)
            {
                if (_Number > 0 && _Number <= Max_Number && _Seat > 0 && _Seat <= Max_Seat)
                {
                    string text = "\n" + _Number.ToString() + " " + _Seat.ToString();
                    string name = Start_F.ToString() + "_" + Name_Cinema;
                    string road = @"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\TimeTable\" + name + "_Reserved.txt";
                    StreamWriter sw = new StreamWriter(road, true);
                    sw.Write(text);
                    sw.Close();
                }
                else { Console.WriteLine("Wrong number/seat!"); return; }
            }

            public void Sale(double Start_F, double End_F, string Name_Cinema, int _Number, int _Seat, string Name_Of_Film)
            {
                Film B = new Film();
                B.Read_Film(@"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\" + Name_Of_Film + ".txt");
                Console.Clear();
                Console.WriteLine("Here is your ticket: ");
                Console.WriteLine("Film: " + Name_Of_Film);
                Console.WriteLine("Start: " + Start_F + ".00");
                Console.WriteLine("End: " + End_F);
                Console.WriteLine("Cinema: " + Name_Cinema);
                Console.WriteLine("Your number: " + _Number);
                Console.WriteLine("Your seat: " + _Seat);
                Console.WriteLine("Duration: " + B.Duration_Film);
                Console.WriteLine("Age limit: " + B.Age_Limit + "+");
                Console.WriteLine("Description: " + B.Description_Film);
                Write_Sold_Number_Seat(Start_F, Name_Cinema, _Number, _Seat);
            }

            public void Reserv(double Start_F, double End_F, string Name_Cinema, int _Number, int _Seat, string Name_Of_Film)
            {
                Film B = new Film();
                B.Read_Film(@"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\" + Name_Of_Film + ".txt");
                Console.Clear();
                Console.WriteLine("Here is your ticket: ");
                Console.WriteLine("Film: " + Name_Of_Film);
                Console.WriteLine("Start: " + Start_F + ".00");
                Console.WriteLine("End: " + End_F);
                Console.WriteLine("Cinema: " + Name_Cinema);
                Console.WriteLine("Your number: " + _Number);
                Console.WriteLine("Your seat: " + _Seat);
                Console.WriteLine("Duration: " + B.Duration_Film);
                Console.WriteLine("Age limit: " + B.Age_Limit + "+");
                Console.WriteLine("Description: " + B.Description_Film);
                Write_Reserv_Number_Seat(Start_F, Name_Cinema, _Number, _Seat);
            }

            public override string ToString()
            {
                string Info = "Name: " + Name + " " + "Max Number: " + Max_Number.ToString() + "Max Seat: " + Max_Seat.ToString() + "Number: " + Number.ToString() + "Seat: " + Seat.ToString();
                return Info;
            }

        }

        class Film
        {
            public double Coefficient; // мультиплікативний коефіцієнт 
            public string Duration_Film; // тривалість фільму
            public string Description_Film; // опис фільму
            public int Age_Limit; // вікові обмеження
            public double Price;
            public Film()
            {
                Coefficient = 1;
                Duration_Film = "";
                Description_Film = "";
                Age_Limit = 0;
                Price = 0;
            }

            public void Read_Film(string road)
            {
                StreamReader fs = new StreamReader(road);
                string s = fs.ReadLine();

                double tmp_d = Convert.ToDouble(s);
                Coefficient = tmp_d;

                s = fs.ReadLine();
                Duration_Film = s;

                s = fs.ReadLine();
                Age_Limit = Convert.ToInt32(s);

                s = fs.ReadLine();
                Price = Convert.ToDouble(s);

                s = fs.ReadLine();
                Description_Film = s;
            }

            public override string ToString()
            {
                string Info = "Coefficient: " + Coefficient.ToString() + "Duration film: " + Duration_Film + "Age limit:" + Age_Limit.ToString() + "Price: " + Price.ToString() + "Description: " + Description_Film;
                return Info;
            }
        }

        class TimeTable
        {
            public double[] StartFilm = new double[10];     //РОзклад початку фільмів
            public double[] EndFilm = new double[10];//Кінець фільмів
            public string[] Name_Of_Cinema = new string[10];//Ім'я кінозалу
            public string[] Name_Film = new string[10];//Назва фільму
            private List<Cinema> list_of_cinema;

            public TimeTable()
            {
                for (int i = 0; i < 10; i++)
                {
                    StartFilm[i] = 0.0;
                    EndFilm[i] = 0.0;
                    Name_Of_Cinema[i] = "";
                    Name_Film[i] = "";
                    list_of_cinema = new List<Cinema>();
                }
            }

            public void Show_Time_Table()
            {
                StreamReader fs = new StreamReader(@"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\Time_Table.txt");
                string s = "";
                int j = 0;
                while (s != null)
                {
                    s = fs.ReadLine();
                    Console.WriteLine(s);
                    int i = 0;
                    string Start_Film = "";
                    //Add Start time
                    if (s == null)
                        break;
                    while (s[i] != ' ')
                    {
                        Start_Film += s[i];
                        i++;
                    }
                    i++;
                    double tmp_start = Convert.ToDouble(Start_Film);
                    StartFilm[j] = tmp_start;

                    //Add End Time
                    string End_Film = "";
                    while (s[i] != ' ')
                    {
                        End_Film += s[i];
                        i++;
                    }
                    i++;
                    double tmp_end = Convert.ToDouble(End_Film);
                    EndFilm[j] = tmp_end;

                    //Add Name of Film
                    string Film_Name = "";
                    while (s[i] != ' ')
                    {
                        Film_Name += s[i];
                        i++;
                    }
                    i++;
                    Name_Film[j] = Film_Name;

                    //Add Name Of Cinema
                    string Name_Cinema = "";
                    while (i != s.Length)
                    {
                        Name_Cinema += s[i];
                        i++;
                    }
                    i++;
                    Name_Of_Cinema[j] = Name_Cinema;
                    j++;
                }
                fs.Close();
            }

            public void Create_Sold_Reserved_Files()
            {
                string name = "";
                for (int i = 0; i < 10; i++)
                {
                    name = StartFilm[i].ToString() + "_" + Name_Of_Cinema[i];
                    if (StartFilm[i].ToString() == "" || StartFilm[i] == 0.0)
                        break;
                    string road = @"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\TimeTable\" + name + "_Sold.txt";
                    if (!File.Exists(road))
                    {
                        FileStream fs = File.Create(road);
                        fs.Close();
                    }
                    road = @"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\TimeTable\" + name + "_Reserved.txt";
                    if (!File.Exists(road))
                    {
                        FileStream fs1 = File.Create(road);
                        fs1.Close();
                    }
                }
            }

            public void Show_Number_Seat(double Start, string _Cinema)
            {
                string inf = "";
                bool Need_Reset = false;

                for (int i = 1; i <= 14; i++)
                {
                    for (int j = 1; j <= 18; j++)
                    {
                        inf = i.ToString() + " " + j.ToString();
                        if (Check(inf, Start, _Cinema))
                        {
                            Need_Reset = true;
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(" {0}", j);
                        if (Need_Reset)
                        {
                            Console.ResetColor();
                            Need_Reset = false;
                        }
                    }
                    Console.WriteLine();
                }
            }

            public bool Check(string info, double Start, string _Cinema)
            {
                bool FLAG = false;
                string road = @"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\TimeTable\" + Start.ToString() + "_" + _Cinema + "_Sold.txt";
                StreamReader fs1 = new StreamReader(road);
                road = @"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\TimeTable\" + Start.ToString() + "_" + _Cinema + "_Reserved.txt";
                StreamReader fs2 = new StreamReader(road);
                string read1 = "";
                string read2 = "";
                while (read1 != null)
                {
                    read1 = fs1.ReadLine();
                    if (read1 == info)
                        FLAG = true;
                }
                fs1.Close();
                while (read2 != null)
                {
                    read2 = fs2.ReadLine();
                    if (read2 == info)
                        FLAG = true;
                }
                fs2.Close();
                return FLAG;
            }

            public override string ToString()
            {
                string Info = "";
                for (int i = 0; i < 10; i++)
                {
                    if (StartFilm[i].ToString() == "" || StartFilm[i] == 0.0)
                        break;
                    Info += "Start " + i + " film: " + StartFilm[i].ToString() + "End " + i + " film: " + EndFilm[i].ToString() + "Name of cinema: " + Name_Of_Cinema[i] + "Name " + i + " film: " + Name_Film[i];
                }
                return Info;
            }

            public Cinema this[int index]
            {
                get
                {
                    return list_of_cinema[index];
                }
                set
                {
                    list_of_cinema.Insert(index, value);
                }
            }

            public int this[Cinema K]
            {
                get
                {
                    return list_of_cinema.IndexOf(K);
                }

            }


        }

        abstract class Aviewer
        {
            public string Name;
            public bool Have_ticket;
            protected bool Authorized;
        }

        class Viewer : Aviewer
        {


            public Viewer()
            {
                Name = "";
                Have_ticket = false;
                Authorized = false;
            }

            public virtual void Print_Viewer_Info()
            {
                Console.WriteLine("Name: ", Name);
                if (Have_ticket)
                    Console.WriteLine("Have a ticket!");
                else
                    Console.WriteLine("Do not have a ticket!");
                if (Authorized)
                    Console.WriteLine("Authorized!");
                else
                    Console.WriteLine("Is not authorized!");
            }

            public override string ToString()
            {
                string Info = "Name: " + Name;
                if (Have_ticket)
                    Info += "have ticket ";
                else
                    Info += "do not have a ticket ";
                if (Authorized)
                    Info += "and authorized.";
                else
                    Info += "and is not authorized!";
                return Info;
            }

        }

        sealed class Regular_Viewer : Viewer
        {
            public int Age;
            public string Phone_Number;
            public string Email;
            public string Number_Card;
            public string Password;
            public int Points;


            public Regular_Viewer() : base()
            {
                Age = 0;
                Phone_Number = "";
                Email = "";
                Number_Card = "";
                Password = "";
                Points = 0;
            }

            public Regular_Viewer(string _Name, int _Age, string _Phone_Number, string _Email, string _Number_Card, string pass)
            {
                Name = _Name;
                Age = _Age;
                Phone_Number = _Phone_Number;
                Email = _Email;
                Number_Card = _Number_Card;
                Password = pass;
                string way = @"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\User_Data.txt";
                StreamWriter sw = new StreamWriter(way);
                string text = "Email: " + _Email;
                sw.WriteLine(text);
                text = "Name: " + _Name;
                sw.WriteLine(text);
                text = "Age: " + _Age.ToString();
                sw.WriteLine(text);
                text = "Phone Number: " + _Phone_Number;
                sw.WriteLine(text);
                text = "Number Card: " + _Number_Card;
                sw.WriteLine(text);
                text = "Password: " + pass;
                sw.WriteLine(text);
                text = "Points: 0";
                sw.WriteLine(text);
                text = "***************************************************";
                sw.WriteLine(text);
                sw.Close();
            }

            public void AddInfo()
            {
                string way = @"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\User_Data.txt";
                StreamWriter sw = new StreamWriter(way,true);
                string text = "***************************************************";
                sw.WriteLine(text);
                Console.WriteLine("Enter your Email: ");
                Email = Console.ReadLine();
                text = "Email: " + Email;
                sw.WriteLine(text);
                Console.WriteLine("Enter your Name: ");
                Name = Console.ReadLine();
                text = "Name: " + Name;
                sw.WriteLine(text);
                Console.WriteLine("Enter your Age: ");
                Age = Convert.ToInt32(Console.ReadLine());
                text = "Age: " + Age.ToString();
                sw.WriteLine(text);
                Console.WriteLine("Enter your phone number: ");
                Phone_Number = Console.ReadLine();
                text = "Phone Number: " + Phone_Number;
                sw.WriteLine(text);
                Console.WriteLine("Enter your number card: ");
                Number_Card = Console.ReadLine();
                text = "Number Card: " + Number_Card;
                sw.WriteLine(text);
                Console.WriteLine("Enter your password: ");
                Password = Console.ReadLine();
                text = "Password: " + Password;
                sw.WriteLine(text);
                text = "Points: 0";
                sw.WriteLine(text);
                text = "***************************************************";
                sw.WriteLine(text);
                sw.Close();
            }

            public void Authorization()
            {
                Console.WriteLine("Enter your email: ");
                string em = Console.ReadLine();
                string email = "Email: " + em;
                bool Email_Flag = false;
                Console.WriteLine("Enter your password: ");
                string pas = Console.ReadLine();
                string Pass = "Password: " + pas;
                bool Pas_Flag = false;
                StreamReader fs = new StreamReader(@"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\User_Data.txt");
                string s = "";
                while (s != null)
                {
                    s = fs.ReadLine();
                    if (s == email)
                        Email_Flag = true;
                    if (s == Pass)
                        Pas_Flag = true;
                }
                if (Email_Flag && Pas_Flag)
                    Console.WriteLine("You have successfully logged in!");
                else { Console.WriteLine("Wrong password or email!"); return; }
                fs.Close();
                StreamReader fs1 = new StreamReader(@"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\User_Data.txt");
                while (s != null)
                {
                    s = fs1.ReadLine();
                    if (s == email)
                    {
                        this.Email = email;
                        s = fs1.ReadLine();
                        s = s.Substring(6);
                        this.Name = s;
                        s = fs1.ReadLine();
                        s = s.Substring(5);
                        int k = Convert.ToInt32(s);
                        this.Age = k;
                        s = fs1.ReadLine();
                        s = s.Substring(14);
                        this.Phone_Number = s;
                        s = fs1.ReadLine();
                        s = s.Substring(13);
                        this.Number_Card = s;
                        this.Password = pas;
                        s = fs1.ReadLine();
                        s = s.Substring(8);
                        k = Convert.ToInt32(s);
                        this.Points = k++;
                        break;
                    }
                    Authorized = true;
                }
                fs1.Close(); ;
            }

            public override void Print_Viewer_Info()
            {
                base.Print_Viewer_Info();
                Console.WriteLine("Age: ", Age);
                Console.WriteLine("Email: ", Email);
                Console.WriteLine("Points: ", Points);
            }



            public static bool operator >(Regular_Viewer A, Regular_Viewer B)
            {
                if (A.Points > B.Points)
                    return true;
                else return false;
            }

            public static bool operator <(Regular_Viewer A, Regular_Viewer B)
            {
                if (A.Points < B.Points)
                    return true;
                else return false;
            }
            
            public static int operator +(Regular_Viewer A,Regular_Viewer B)
            {
                return (A.Points + B.Points);
            }

            public static int operator -(Regular_Viewer A, Regular_Viewer B)
            {
                return (A.Points - B.Points);
            }

            public static int operator *(Regular_Viewer A, Regular_Viewer B)
            {
                return (A.Points * B.Points);
            }

            public static double operator /(Regular_Viewer A, Regular_Viewer B)
            {
                return (A.Points / B.Points);
            }

            public override string ToString()
            {
                string Info = "Name: " + Name;
                if (Have_ticket)
                    Info += "have ticket ";
                else
                    Info += "do not have a ticket ";
                if (Authorized)
                    Info += "and authorized.";
                else
                    Info += "and is not authorized!";
                Info += " age: " + Age.ToString() + " phone number: " + Phone_Number + " email: " + Email + " password: " + Password + " points: " + Points.ToString();
                return Info;
            }
            
        }
    }
}