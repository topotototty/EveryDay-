using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dairy
{
    class Note
    {
        private string _Name;
        private string _Description;
        public DateTime Date { get; set; }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public static void Serialize(BindingList<Note> notes)
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText("C://Users//futbo//OneDrive//Рабочий стол//Dairy//About_Notes.json", json);
        }

        public static BindingList<Note> Deserialize()
        {
            string About_Notes = File.ReadAllText("C://Users//futbo//OneDrive//Рабочий стол//Dairy//About_Notes.json");
            BindingList<Note> notes = JsonConvert.DeserializeObject<BindingList<Note>>(About_Notes);
            return notes;
        }
    }
}
