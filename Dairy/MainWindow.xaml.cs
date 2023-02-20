using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using System.Xml.Linq;

namespace Dairy
{
    public partial class MainWindow : Window
    {
        string name;
        string description;
        BindingList<Note> All_Notes;

        public MainWindow()
        {
            InitializeComponent();
            All_Notes = Note.Deserialize();

            if (All_Notes == null)
            {
                All_Notes = new BindingList<Note>();
            }

            Select_Date.SelectedDate= DateTime.Now;
            Note.Serialize(All_Notes);
            Show();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            
            All_Notes = Note.Deserialize();
            name = Note_Name.Text;
            description = Note_Description.Text;

            Note New_Note = new Note() { Name = name, Description = description, Date = Select_Date.SelectedDate.Value};
            if (All_Notes == null)
            {
                All_Notes = new BindingList<Note> { New_Note };
            }
            else
            {
                All_Notes.Add(New_Note);
            }
            Note.Serialize(All_Notes);
            Show();
        }

        private void Show()
        {
            All_Notes = Note.Deserialize();
            BindingList<Note> Dayly_Notes = new BindingList<Note>();
            foreach (Note note in All_Notes)
            {
                if (note.Date == Select_Date.SelectedDate)
                {
                    Dayly_Notes.Add(note);
                }
            }

            Note.Serialize(All_Notes);

            View_Notes.ItemsSource = Dayly_Notes;
        }



        private void Save(object sender, RoutedEventArgs e)
        {
            foreach (Note note in All_Notes)
            {
                if (View_Notes.SelectedItem == note)
                {
                    note.Name = Note_Name.Text;
                    note.Description = Note_Description.Text;
                    break;
                }
            }
            Note.Serialize(All_Notes);
            Show();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            foreach (Note note in All_Notes)
            {
                if (View_Notes.SelectedItem == note)
                {
                    All_Notes.Remove(note);
                    break;
                }
            }
            
            Note.Serialize(All_Notes);
            Show();
        }

        private void Selected_Date_Chaneged(object sender, SelectionChangedEventArgs e)
        {
            Show();
        }
    }
}
