using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace DMWGUI_AJ
{
    public partial class Form1 : Form
    {

        MotorVehicle[] vehicles = new MotorVehicle[20];

        String lastUsedFileName = "";
        
        int count = 0;       
        public static string fileName = "log_"+(int)(DateTime.Today.Subtract(new DateTime(1970, 1, 1)).TotalSeconds)+".txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            file.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Model_Click(object sender, EventArgs e)
        {

        }

      
       

        //  When we select bus type

        private void radioButtonBus_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label1.Text = "Company name";
            textBox1.Visible = true;

            ComboBoxMake.Items.Clear();
            ComboBoxMake.Items.Add("Bus - 1");
            ComboBoxMake.Items.Add("Bus - 2");
            ComboBoxMake.Items.Add("Bus - 3");
            ComboBoxMake.Items.Add("Bus - 4");
            ComboBoxMake.Items.Add("Bus - 5");

            ComboBoxMake.Sorted = true;
            ComboBoxMake.SelectedIndex = 0;
        }

        // This part is called if we select truck as vehicle type


        private void radioButtonTruck_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label1.Text = "Max. Weight";
            textBox1.Visible = true;

            ComboBoxMake.Items.Clear();
            ComboBoxMake.Items.Add("Truck - 1");
            ComboBoxMake.Items.Add("Truck - 2");
            ComboBoxMake.Items.Add("Truck - 3");
            ComboBoxMake.Items.Add("Truck - 4");
            ComboBoxMake.Items.Add("Truck - 5");
            ComboBoxMake.Sorted = true;

            ComboBoxMake.SelectedIndex = 0;
        }

            // This part here is called when we click on register button 

        private void buttonRegVeh_Click(object sender, EventArgs e)
        {
            MotorVehicle mv = null;
            if(radioButtonTruck.Checked) // if radio button for truck is checked
            {            
                // This calls for boxes, what to input if truck is selected
                                                     
                mv = new Truck(textBoxVIN.Text, ComboBoxMake.Text, textBoxModel.Text, (int)NoOfWheels.Value, (int)NoOfSeats.Value, dateTimePicker1.Value, Convert.ToDouble(textBox1.Text));
            }
            if(radioButtonBus.Checked)
            {

                // If bus is selected..
                mv = new Bus(textBoxVIN.Text, ComboBoxMake.Text, textBoxModel.Text, (int)NoOfSeats.Value, (int)NoOfWheels.Value, dateTimePicker1.Value, textBox1.Text);
            }
            if(radioButtonTaxi.Checked)
            {

                // Taxi selected
                mv = new Taxi(textBoxVIN.Text, ComboBoxMake.Text, textBoxModel.Text, (int)NoOfSeats.Value, (int)NoOfWheels.Value, dateTimePicker1.Value, textBox1.Text,true,Convert.ToInt32(textBox2.Text),radioButtonYes.Checked);
            }
            if(radioButtonCar.Checked)
            {
                mv = new Car(textBoxVIN.Text, ComboBoxMake.Text, textBoxModel.Text, (int)NoOfSeats.Value, (int)NoOfWheels.Value, dateTimePicker1.Value, textBox1.Text,radioButtonYes.Checked,Convert.ToInt32(textBox2.Text));
            }
            if(radioButtonMotorcycle.Checked)
            {
                MessageBox.Show("Not implemented to do");
                return;
            }

            // This checks if you have or haven't choose type of vehicle. If it's null, or not selected anything
            // it shows message box to choose one type of vehicle.
            if(mv==null)
            {

                MessageBox.Show("Please choose type of vehicle!");
                return;

            }
            richTextBox1.Text = mv.show();

            FileStream file = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            
            writer.WriteLine(mv.show());
            writer.Close();
            file.Close(); 

                // Checks if file exists

            if (!File.Exists("RegisteredVehicles.txt"))
            {
                File.Create("RegisteredVehicles.txt").Close();
            }

                // Checks if directory exists

            if (!Directory.Exists("C:\\DVM\\BACKUP"))
            {

                Directory.CreateDirectory("C:\\DVM\\BACKUP"); // If it doesn't exist, it creates it
            }

            // Moves file to backup Registered Vehicles
            File.Move("RegisteredVehicles.txt", "C:\\DVM\\Backup\\RegisteredVehicles.txt");

            // adding date to it's name
            String name = "C:\\DVM\\Backup\\RegisteredVehicles" + DateTime.Now.ToString("HH-mm-ss dd-MM-yyyy") + ".txt";
            File.Move("C:\\DVM\\Backup\\RegisteredVehicles.txt", name);
            file = new FileStream(name, FileMode.Append, FileAccess.Write);
            writer = new StreamWriter(file);
            StringBuilder sb = new StringBuilder();
            writer.WriteLine(mv.show());
            writer.Close();
            file.Close();
            lastUsedFileName = name;
        }

        // This calls if car is seleted as a type of vehicle
        private void radioButtonCar_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label1.Text = "Color of the car";
            textBox1.Visible = true;
            label2.Visible = true;
            label2.Text = "Number of airbags in it";
            textBox2.Visible = true;
            label3.Visible = true;
            label3.Text = "Does the car have AC?";
            radioButtonYes.Visible = true;
            radioButtonNo.Visible = true;


            ComboBoxMake.Items.Clear();
            ComboBoxMake.Items.Add("Car - 1");
            ComboBoxMake.Items.Add("Car - 2");
            ComboBoxMake.Items.Add("Car - 3");
            ComboBoxMake.Items.Add("Car - 4");
            ComboBoxMake.Items.Add("Car - 5");
            ComboBoxMake.Sorted = true;
            ComboBoxMake.SelectedIndex = 0;
        }

        //  When taxi is selected for type of vehicle

        private void radioButtonTaxi_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label1.Text = "Color of the car";
            textBox1.Visible = true;
            label2.Visible = true;
            label2.Text = "Number of airbags in it";
            textBox2.Visible = true;
            label3.Visible = true;
            label3.Text = "Does driver have a licence?";
            radioButtonYes.Visible = true;
            radioButtonNo.Visible = true;


            ComboBoxMake.Items.Clear();
            ComboBoxMake.Items.Add("Taxi - 1");
            ComboBoxMake.Items.Add("Taxi - 2");
            ComboBoxMake.Items.Add("Taxi - 3");
            ComboBoxMake.Items.Add("Taxi - 4");

            ComboBoxMake.Sorted = true;
            ComboBoxMake.SelectedIndex = 0;
        }
        



        private void radioButtonYes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LastVehicleButton_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream file = new FileStream(lastUsedFileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                String[] values = reader.ReadLine().Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
                textBoxVIN.Text = values[0];
                ComboBoxMake.Text = values[1];
                textBoxModel.Text = values[2];
                dateTimePicker1.Value = DateTime.ParseExact(values[5], "MMddyy", CultureInfo.InvariantCulture);
                NoOfWheels.Value = int.Parse(values[6]);
                NoOfSeats.Value = int.Parse(values[7]);
                reader.Close();
                file.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No file in " + lastUsedFileName + " in C:\\DVM\\Backup");
            }
        }

        private void vehicleTypeGroupBox_Enter(object sender, EventArgs e)
        {

        }

    }
}
