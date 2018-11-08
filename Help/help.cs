/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteDB.Help
{
    public class help
    {
    }
}
WPF aplication code

using BazaDanych.Klasy;
using System;
using System.Collections.Generic;
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
using System.Data;
using MySql.Data.MySqlClient;


namespace BazaDanych
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DB();
            
           
        }
        #region FirstDataWindow

        public void DB()
        {

            Person person = new Person();
            person.id = 1;
            person.name = "Jan";
            person.surname = "Kowaslki";
            person.DateOfBirth = new DateTime (1991,05,03);
            person.PhonNumber = "792333814";
            person.email = "jankowalski@test.pl";

            Person person2 = new Person();
            person2.id = 2;
            person2.name = "Adam";
            person2.surname = "Nowak";
            person2.DateOfBirth = new DateTime(1981, 05, 03);
            person2.PhonNumber = "722333814";
            person2.email = "adamnowak@test.pl";

            Person person3 = new Person();

            List<Person> ListOfPerson = new List<Person>();
            ListOfPerson.Add(person);
            ListOfPerson.Add(person2);
           
            listView.ItemsSource = ListOfPerson;

            }
        #endregion 

        #region WindowGetData

        public void GetData()

         {
             string MyConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;;database=person;SslMode=none";
             MySqlConnection connection = new MySqlConnection(MyConnectionString);
             connection.Open();
             try
             {
            
                 
                 MySqlCommand cmd = connection.CreateCommand();
                 cmd.CommandText = "Select * FROM clients";
                 
                 MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                 DataSet ds = new DataSet();
                 adap.Fill(ds);
                 listView1.ItemsSource = ds.Tables[0].DefaultView;

                


    }
             catch (Exception)
             {
              throw;
             }

             finally
             {
                 if (connection.State == ConnectionState.Open)
                 {
                     connection.Clone();
                 } 
             }
    }
        #endregion

        #region SendData   

        /// <summary>
        /// nie dziala
        /// </summary>
        public void SendData()
        {
            string MyConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;;database=test2;SslMode=none";
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                //string @imie = imie.Text;
                
                string Query = "INSERT INTO test2.test22 ('imie','nazwisko') VALUES ('dfdf','fdfd)";
                
                MySqlCommand cmdSend = new MySqlCommand(Query, connection);
                
                ///cmdSend.Parameters.AddWithValue("@imie", this.imie.Text);
                /*cmdSend.Parameters.AddWithValue("@surname", Surname.Text);
                cmdSend.Parameters.AddWithValue("@DateOfBirth", DateOfBirth.Text);
                cmdSend.Parameters.AddWithValue("@PhonNumber", PhonNumber.Text);
                cmdSend.Parameters.AddWithValue("@AdressEmail", AdressEmail.Text);
            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    ///string messageBoxText = "Poprawne polaczenie";
                    ///MessageBox.Show(messageBoxText);
                    connection.Close();
                   /// GetData();


                }
            }
        }
       
        
        #endregion

        #region ButtonGetData

        private void download_Click(object sender, RoutedEventArgs e)
{
    GetData();
}
#endregion

#region ButtonClearData

private void Clear_Click(object sender, RoutedEventArgs e)
{
    listView1.ItemsSource = null;

}

#endregion

private void send_Click(object sender, RoutedEventArgs e)
{
    SendData();
}
    }


}

*****************************LookLikeWindow***************************************

<Window x:Class="BazaDanych.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:BazaDanych"
        mc:Ignorable="d"
        Title="MainWindow" Height="560" Width="800">

    <Grid>
        
        <ListView x:Name="listView" HorizontalAlignment="Left" Height="125" VerticalAlignment="Top" Width="400" Margin="60,82,0,0">
            <ListView.View>
                <GridView>
                    <GridViewColumn DisplayMemberBinding="{Binding id}"/>
                    <GridViewColumn DisplayMemberBinding="{Binding name}"/>
                    <GridViewColumn DisplayMemberBinding="{Binding surname}"/>
                    <GridViewColumn DisplayMemberBinding="{Binding DateOfBirth}"/>
                    <GridViewColumn DisplayMemberBinding="{Binding PhonNumber}"/>
                    <GridViewColumn DisplayMemberBinding="{Binding email}"/>
                </GridView>
            </ListView.View>
        </ListView>
        <TextBlock x:Name="textBlock" HorizontalAlignment="Left" Margin="210,44,0,0" TextWrapping="Wrap" Text="Aplikacja" VerticalAlignment="Top" FontSize="24"/>
        <ListView x:Name="listView1" HorizontalAlignment="Left" Height="200" Margin="60,222,0,0" VerticalAlignment="Top" Width="400">
            <ListView.View>
                <GridView>
                    <GridViewColumn DisplayMemberBinding="{Binding id}"/>
                    <GridViewColumn DisplayMemberBinding="{Binding name}"/>
                    <GridViewColumn DisplayMemberBinding="{Binding surname}"/>
                    <GridViewColumn DisplayMemberBinding="{Binding DateOfBirth}"/>
                    <GridViewColumn DisplayMemberBinding="{Binding PhonNumber}"/>
                    <GridViewColumn DisplayMemberBinding="{Binding email}"/>
                </GridView>
            </ListView.View>
        </ListView>
        <Button x:Name="download" Content="Pobierz z bazy" HorizontalAlignment="Left" Margin="62,453,0,0" VerticalAlignment="Top" Width="80" Height="23" Click="download_Click"/>
        <Button x:Name="send" Content="Wyślij do bazy" HorizontalAlignment="Left" Margin="223,453,0,0" VerticalAlignment="Top" Width="80" Height="23" Click="send_Click"/>
        <Button x:Name="email" Content="Wyslij Email" HorizontalAlignment="Left" Margin="384,453,0,0" VerticalAlignment="Top" Width="80" Height="23"/>
        <Button x:Name="Clear" Content="Wyczyść" HorizontalAlignment="Left" Margin="62,485,0,0" VerticalAlignment="Top" Width="80"  Height="23" Click="Clear_Click"/>
        <Grid>
            <TextBox x:Name="imie" HorizontalAlignment="Left" Height="22" Margin="520,224,0,0" TextWrapping="Wrap" Text="Imię" VerticalAlignment="Top" Width="219"/>
            <TextBox x:Name="Surname" HorizontalAlignment="Left" Height="23" Margin="520,251,0,0" TextWrapping="Wrap" Text="Nazwisko" VerticalAlignment="Top" Width="219"/>
            <TextBox x:Name="DateOfBirth" HorizontalAlignment="Left" Height="23" Margin="520,279,0,0" TextWrapping="Wrap" Text="Data urodzenia" VerticalAlignment="Top" Width="219"/>
            <TextBox x:Name="PhonNumber" HorizontalAlignment="Left" Height="23" Margin="520,307,0,0" TextWrapping="Wrap" Text="Numer telefonu" VerticalAlignment="Top" Width="219"/>
            <TextBox x:Name="AdressEmail" HorizontalAlignment="Left" Height="23" Margin="520,335,0,0" TextWrapping="Wrap" Text="Adres email" VerticalAlignment="Top" Width="219"/>
        </Grid>
        <Image x:Name="Logo" HorizontalAlignment="Left" Height="125" Margin="520,82,0,0" VerticalAlignment="Top" Width="219" Source="Images/logoTest.jpg"/>


    </Grid>
</Window>





*/