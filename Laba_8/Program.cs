using System;
using System.IO;
namespace Laba_8
{
    class TicketService
    {
        static void Main(string[] args)
        {
            //Film Mat = new Film();
            //Console.WriteLine("Enter film : ");
            //string a = Console.ReadLine();
            //Mat.Read_Film(@"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\" + a + ".txt");
            TimeTable Time = new TimeTable();
            Time.Show_Time_Table();
        }
        public void Sale()
        {

        }
    } 

    class Cinema
    {
        public string Name;
        public int Max_Number = 14; // Ряд
        public int Max_Seat = 18;   //Місце
        public int Max_VIP_seat = 6; 
        public int Number;
        public int Seat;

        public Cinema()
        {
            Name = "";
            Number = 0;
            Seat = 0;
        }

        public void Write_Sold_Number_Seat()
        {
            if(Number > 0 && Number <= Max_Number && Seat > 0 && Seat <= Max_Seat)
            {
                string text = Number.ToString() + " " + Seat.ToString();
                System.IO.File.WriteAllText(@"D:\Visual Studio\Visual Studio C# Projects\Laba_8\Laba_8\Number_And_Seat_Of_Sold_Tickets.txt", text);
            }
            else { Console.WriteLine("Wrong number/seat!"); return; }
        }
    }

    class Film
    {
        public double Coefficient; // мультиплікативний коефіцієнт 
        public string Duration_Film; // тривалість фільму
        public string Description_Film; // опис фільму
        public int Age_Limit; // вікові обмеження
        public Film()
        {
            Coefficient = 1;
            Duration_Film = "";
            Description_Film = "";
            Age_Limit = 0;
        }

        public void Read_Film(string road)
        {
            StreamReader fs = new StreamReader(road);
            string s = fs.ReadLine();
            Console.WriteLine(s);
           
            double tmp_d = Convert.ToDouble(s);
            Coefficient = tmp_d;

            s = fs.ReadLine();
            Duration_Film = s;

            s = fs.ReadLine();
            Age_Limit = Convert.ToInt32(s);

            s = fs.ReadLine();
            Description_Film = s;
        }

    }

    class TimeTable
    {
        public double[] StartFilm = new double [10];
        public double[] EndFilm = new double [10];
        public string[] Name_Of_Cinema = new string [10];

        public TimeTable()
        {
            for (int i = 0; i < 10; i++)
            {
                StartFilm[i] = 0.0;
                EndFilm[i] = 0.0;
                Name_Of_Cinema[i] = "";
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
                while(s[i] != ' ')
                {
                    End_Film += s[i];
                    i++;
                }
                i++;
                double tmp_end = Convert.ToDouble(End_Film);
                EndFilm[j] = tmp_end;

                //Add Name Of Cinema
                string Name_Cinema = "";
                while ( i != s.Length)
                {
                    Name_Cinema += s[i];
                    i++;
                }
                i++;
                Name_Of_Cinema[j] = Name_Cinema;
                j++;
            }
        }
    }
}
