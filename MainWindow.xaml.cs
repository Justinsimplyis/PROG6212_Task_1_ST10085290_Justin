using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLibrary;

namespace Task_1_Draft_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            ReadFromFile();
            WriteToFile();
            
            filePath = "Information.txt";
        }
        //file path
        public static string filePath;

        List<string> Display = new List<string>();
        //Starting data , does not matter if its in a text file 
        List<Information> info = new List<Information>();

        public void WriteToFile()
        {
            // Write file using StreamWriter  
            using (StreamWriter write = new StreamWriter(filePath))
            {
                try
                {
                    write.WriteLine("MODULE CODE: " + txtCode.Text);
                    write.WriteLine("MODULE NAME: " + txtModule.Text);
                    write.WriteLine("MODULE CREDIT: " + txtCredits.Text);
                    write.WriteLine("CLASS HOURS PER WEEK: " + txtHours.Text);


                    //clear the textboxes
                    txtCode.Text = "";
                    txtModule.Text = "";
                    txtHours.Text = "";
                    txtCredits.Text = "";
                    write.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                string readText = File.ReadAllText(filePath);
                Console.WriteLine(readText);
            }

        }
        public void WriteToFileAgain(Information[] inputInfo)
        {
            Display.Clear();
            List<Information> Sortme = inputInfo.OrderBy(e => e.code).ToList();
            info = Sortme;
            foreach (Information info in Sortme)
            {
                String strOutput = "MODULE CODE: " + info.code + " " +
                    "\n  MODULE NAME: " + info.module +
                    "\n MODULE CREDIT: " + info.credits + 
                    "\n CLASS HOURS PER WEEK: " + info.hours;
                Display.Add(strOutput);
            }

            lstDisplay.ItemsSource = null;
            lstDisplay.ItemsSource = Display;
        }

        private void ReadFromFile()
        {

            try
            {

                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();

                foreach (String line in lines)
                {
                    Console.WriteLine(line);
                }

                File.WriteAllLines(filePath, lines);

            }
            catch (Exception)
            {

            }
            ReadFromFile();
        }



        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //call method to add information to txt file and read from file
            WriteToFile();
            

        }

        private void lstDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();

                foreach(String line in lines)
                {
                    Console.WriteLine(line);
                }

                File.WriteAllLines(filePath, lines);
               
            }
            catch (Exception)
            {

            }

        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public void CalcTime(Dictionary<string,int> check)
        {
            int credits = check[txtCredits.Text];
            int hours = check[txtHours.Text];
            int weeks = check[txtWeeks.Text];

            Calc c = new Calc();
            c.CalculateTime(credits, hours, weeks);//return interger 

            //calulate
            Calculated = c.CalculateTime(credits, hours, weeks).ToString();

        }
    }
}
