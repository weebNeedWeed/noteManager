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

                data.Add("test", "test2");
                data.Add("test2", "test3");

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

        public void AddNote(string noteId, string noteContent)
        {
            Hashtable notes = this.GetAllNotes();
            notes.Add(noteId, noteContent);

            string jsonData = JsonSerializer.Serialize(notes);

            File.WriteAllText(this.Filename, jsonData);
        }

        public void RemoveNote(string noteId)
        {
            Hashtable notes = this.GetAllNotes();
            notes.Remove(noteId);

            string jsonData = JsonSerializer.Serialize(notes);

            File.WriteAllText(this.Filename, jsonData);
        }
        public void EditNote(string noteId, string noteContent)
        {
            Hashtable notes = this.GetAllNotes();
            if (notes.ContainsKey(noteId))
            {
                notes[noteId] = noteContent;
                string jsonData = JsonSerializer.Serialize(notes);

                File.WriteAllText(this.Filename, jsonData);
            }
        }
    }
}
