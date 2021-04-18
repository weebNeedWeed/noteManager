using System;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace noteManager
{
    public class Note
    {
        private string Filename { get; set; }
        public Note(string filename)
        {
            this.Filename = $"./{filename}.json";
            if (!File.Exists(this.Filename))
            {
                Hashtable data = new Hashtable();
                string jsonData = JsonSerializer.Serialize(data);
                File.WriteAllText(this.Filename, jsonData);
            }
        }

        public Hashtable GetAllNotes()
        {
            string jsonData = File.ReadAllText(this.Filename);
            Hashtable notes = JsonSerializer.Deserialize<Hashtable>(jsonData);

            return notes;
        }
    }
}
