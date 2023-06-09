﻿using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows;
using System.Collections;

using System.Collections.ObjectModel;
namespace Project1
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        private Samochod selectedSamochod;

        public ViewModel()
        {
            this.Samochody = new ObservableCollection<Samochod>()
            {
                //new Samochod { Name = "Kiko", Age = 23, Department = "Production" },
                //new Person { Name = "Jerry", Age = 23, Department = "Accounting and Finance"},
                //new Person { Name = "Ethan", Age = 51, Department = "Marketing" },
                //new Person { Name = "Isabella", Age = 25, Department = "Marketing" },
                //new Person { Name = "Joshua", Age = 45, Department = "Production" },
                //new Person { Name = "Logan", Age = 26, Department = "Production"},
                //new Person { Name = "Aaron", Age = 32, Department = "Production" },
                //new Person { Name = "Elena", Age = 37, Department = "Accounting and Finance"},
                //new Person { Name = "Ross", Age = 30, Department = "Marketing" },
            };
        }

        public ObservableCollection<Samochod> Samochody { get; set; }

        public Samochod SelectedSamochod
        {
            get { return this.selectedSamochod; }
            set
            {
                if (this.selectedSamochod != value)
                {
                    this.selectedSamochod = value;
                    //this.OnPropertyChanged();
                }
            }
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
    }
    public partial class Window2 : Window
    {
        private System.Data.DataTable table;
        public Window2()
        {

            InitializeComponent();
            string queryString = "SELECT MarkaSamochodu  FROM  Samochod";

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ateor\\source\\repos\\Project1\\Project1\\Data\\Wypozyczalnia2.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        SamochodyInfo.Items.Add((reader["MarkaSamochodu"]));// etc
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }

        }

        private void MakeDataTableAndDisplay()
        {
            // Create new DataTable and DataSource objects.
            DataTable table = new DataTable();

            // Declare DataColumn and DataRow variables.
            DataColumn column;
            DataRow row;
            DataView view;

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "item";
            table.Columns.Add(column);

            // Create new DataRow objects and add to DataTable.
            for (int i = 0; i < 10; i++)
            {
                row = table.NewRow();
                row["id"] = i;
                row["item"] = "item " + i.ToString();
                table.Rows.Add(row);
            }

            // Create a DataView using the DataTable.
            view = new DataView(table);

            // Set a DataGrid control's DataSource to the DataView.
            //  this.adresyGrid.DataSource = view;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string queryString = "Select MarkaSamochodu, ModelSamochodu, CenaZaDzien From Samochod";
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ateor\\source\\repos\\Project1\\Project1\\Data\\Wypozyczalnia2.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    table = new DataTable();
                    table.Load(reader);


                    Modele1.ItemsSource = table.DefaultView;

                    // Włącz automatyczne generowanie kolumn
                    Modele1.AutoGenerateColumns = true;

                    // Wyłącz możliwość dodawania nowych wierszy ręcznie
                    Modele1.CanUserAddRows = false;
                }
                finally
                {
                    reader.Close();
                }
            }
        }
        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;// get the Row Index
            DataRow selectedRow = table.Rows[index];
            string r = selectedRow.ToString();
            System.Windows.Forms.MessageBox.Show(r);
            //textBoxID.Text = selectedRow.Cells[0].Value.ToString();
            //textBoxFN.Text = selectedRow.Cells[1].Value.ToString();
            //textBoxLN.Text = selectedRow.Cells[2].Value.ToString();
            //textBoxAGE.Text = selectedRow.Cells[3].Value.ToString();

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string selected = SamochodyInfo.SelectedItem.ToString();
            string queryString = "Select ModelSamochodu, CenaZaDzien From Samochod Where MarkaSamochodu = @MarkaSamochodu";
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ateor\\source\\repos\\Project1\\Project1\\Data\\Wypozyczalnia2.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@MarkaSamochodu", selected);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    table = new DataTable();
                    table.Load(reader);

                    // Ustaw źródło danych DataGrid na DataTable
                    Modele1.ItemsSource = table.DefaultView;

                    // Włącz automatyczne generowanie kolumn
                    Modele1.AutoGenerateColumns = true;

                    // Wyłącz możliwość dodawania nowych wierszy ręcznie
                    Modele1.CanUserAddRows = false;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (Modele1.SelectedItems.Count > 0)
            {
                string selected = ((DataRowView)Modele1.SelectedItems[0]).Row["ModelSamochodu"].ToString();
                string queryString = "SELECT MarkaSamochodu, ModelSamochodu, CenaZaDzien FROM Samochod WHERE ModelSamochodu = @ModelSamochodu";
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ateor\\source\\repos\\Project1\\Project1\\Data\\Wypozyczalnia2.mdf;Integrated Security=True;Connect Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@ModelSamochodu", selected);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    try
                    {
                        table = new DataTable();
                        table.Load(reader);

                        // Ustaw źródło danych DataGrid na DataTable
                        Modele1.ItemsSource = table.DefaultView;

                        // Włącz automatyczne generowanie kolumn
                        Modele1.AutoGenerateColumns = true;

                        // Wyłącz możliwość dodawania nowych wierszy ręcznie
                        Modele1.CanUserAddRows = false;

                        //try
                        //{
                        //    var row_list = GetDataGridRows(Modele1);
                        //    foreach (DataGridRow single_row in row_list)
                        //    {
                        //        //if (single_row.IsSelected == true)
                        //        //{
                        //            System.Windows.Forms.MessageBox.Show("the row no." + single_row.GetIndex().ToString() + " is selected!");
                        //        //}
                        //    }

                        //}
                        //catch { }
                        //Samochod samochod = (Samochod)Modele1.SelectedItems;
                        //System.Windows.Forms.MessageBox.Show(samochod.ModelSamochodu);

                    }
                    finally
                    {
                        reader.Close();
                    }

                }
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ////string s = iloscDni.GetLineText(0);
            ////int sIint = Convert.ToInt32(s);
            ////string queryString = "Select CenaZaDzien FROM Samochod";
            ////string connectionString = "Data Source=DESKTOP-CVD8VKU;Initial Catalog=Wypozyczalnia2;Integrated Security=True";



            ////string queryString = "SELECT CenaZaDzien FROM Samochod "; wybor modeli

            //// pobrac wynik z readera
            //// int Wynik = wartosc z readera *sINt
            //// label lub messagebox.show(Wynik)

            ////MessageBox.Show(s);
            //Samochod samochod = (Samochod)Modele1.SelectedIndex;
            DataRowView row = Modele1.SelectedItem as DataRowView;
            System.Windows.Forms.MessageBox.Show(row["ModelSamochodu"].ToString());
            if (row == null)
                System.Windows.Forms.MessageBox.Show("nulll");
            else
            {
                System.Windows.Forms.MessageBox.Show(row.Row.ItemArray[1].ToString());
            }
            int samochod = Modele1.SelectedIndex;
            System.Windows.Forms.MessageBox.Show(samochod.ToString());
            int liczba;
            if (int.TryParse(iloscDni.Text, out liczba))
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ateor\\source\\repos\\Project1\\Project1\\Data\\Wypozyczalnia2.mdf;Integrated Security=True;Connect Timeout=30";
                string queryString = "SELECT CenaZaDzien FROM Samochod WHERE ModelSamochodu = @ModelSamochodu";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand(queryString, connection);
                    if (Modele1.SelectedItem != null)
                    {
                        command.Parameters.AddWithValue("@CenaZaDzien", Modele1.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@ModelSamochodu", Modele1.SelectedItem.ToString());

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        try
                        {
                            if (reader.Read())
                            {
                                int cena = (int)reader["CenaZaDzien"];
                                int wynik = liczba * cena;
                                System.Windows.MessageBox.Show("Wynik: " + wynik.ToString());
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Wybierz model samochodu.");
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Podaj poprawną liczbę.");
            }
        }
        //public IEnumerable<DataGridRow> GetDataGridRows(System.Windows.Controls.DataGrid grid)
        //{
        //    var itemsSource = grid.ItemsSource as IEnumerable;
        //    if (null == itemsSource) yield return null;
        //    foreach (var item in itemsSource)
        //    {
        //        var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
        //        if (null != row) yield return row;
        //    }
        //}

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            string selected = Modele1.SelectedItem.ToString();
            string queryString = "SELECT CenaZaDzien FROM Samochod ";
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ateor\\source\\repos\\Project1\\Project1\\Data\\Wypozyczalnia2.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@CenaZaDzien", selected);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    table = new DataTable();
                    table.Load(reader);

                    // Ustaw źródło danych DataGrid na DataTable
                    Models.ItemsSource = table.DefaultView;

                    // Włącz automatyczne generowanie kolumn
                    Models.AutoGenerateColumns = true;

                    // Wyłącz możliwość dodawania nowych wierszy ręcznie
                    Models.CanUserAddRows = false;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        private void ComboBox_SelectionChanged12(object sender, SelectionChangedEventArgs e)
        {


            string selected = SamochodyInfo1.SelectedItem.ToString();
            string queryString = "Select ModelSamochodu From Samochod Where MarkaSamochodu = @MarkaSamochodu";
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ateor\\source\\repos\\Project1\\Project1\\Data\\Wypozyczalnia2.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@MarkaSamochodu", selected);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    table = new DataTable();
                    table.Load(reader);

                    // Ustaw źródło danych DataGrid na DataTable
                    Modele1.ItemsSource = table.DefaultView;

                    // Włącz automatyczne generowanie kolumn
                    Modele1.AutoGenerateColumns = true;

                    // Wyłącz możliwość dodawania nowych wierszy ręcznie
                    Modele1.CanUserAddRows = false;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

    }

}
