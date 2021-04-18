using System;
using System.Collections;
namespace noteManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            (new Program()).showMainMenu();
            Note noteManager = new Note("test");
            foreach (DictionaryEntry note in noteManager.GetAllNotes())
            {
                Console.WriteLine(note.Value + " " + note.Key);
            }
            Console.ReadLine();
        }

        private void showMainMenu()
        {
            Console.WriteLine("1. List all notes \n" +
                "2. Add new note \n" +
                "3. Edit note(with id) \n" +
                "4. Delete note(with id)");
        }
    }
}
