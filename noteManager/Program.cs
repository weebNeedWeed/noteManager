using System;
using System.Collections;
namespace noteManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Program app = new Program();
            Note noteManager = new Note("notes1");
            app.ShowMainMenu();
            int mode = Convert.ToInt32(Console.ReadLine());

            switch (mode)
            {
                // Exit mode
                case 5:
                default: 
                    {
                        return;
                    }

                // show all notes
                case 1:
                    {
                        Console.Clear();
                        app.ShowHR();
                        int index = 1;

                        foreach(DictionaryEntry note in noteManager.GetAllNotes())
                        {
                            Console.WriteLine($"{index}. {note.Key} - {note.Value}");
                            index++;
                        }

                        break;
                    }
            }

            Console.ReadLine();
        }

        private void ShowHR()
        {
            Console.WriteLine("----------------------------------");
        }
        private void ShowMainMenu()
        {
            Console.WriteLine("1. List all notes \n" +
                "2. Add new note \n" +
                "3. Edit note(with id) \n" +
                "4. Delete note(with id) \n" +
                "5. Exit");
        }
    }
}
