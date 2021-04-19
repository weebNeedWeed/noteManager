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

                        app.ShowHR();

                        if(Convert.ToInt32(Console.ReadLine()) == 0)
                        {
                            app.RestartProgram();
                        }

                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Note id ?");
                        string noteId = Console.ReadLine();
                        Console.WriteLine("Note content ?");
                        string noteContent = Console.ReadLine();

                        noteManager.AddNote(noteId, noteContent);

                        app.ShowHR();
                        Console.WriteLine("success");

                        if (Convert.ToInt32(Console.ReadLine()) == 0)
                        {
                            app.RestartProgram();
                        }

                        break;
                    }

                case 3:
                    {
                        Console.Clear();

                        int index = 1;

                        foreach (DictionaryEntry note in noteManager.GetAllNotes())
                        {
                            Console.WriteLine($"{index}. {note.Key} - {note.Value}");
                            index++;
                        }

                        Console.WriteLine("Note id ?");
                        string noteId = Console.ReadLine();
                        Console.WriteLine("Note content ?");
                        string noteContent = Console.ReadLine();

                        noteManager.EditNote(noteId, noteContent);

                        app.ShowHR();
                        Console.WriteLine("success");

                        if (Convert.ToInt32(Console.ReadLine()) == 0)
                        {
                            app.RestartProgram();
                        }

                        break;
                    }

                case 4:
                    {
                        Console.Clear();
                        int index = 1;

                        foreach (DictionaryEntry note in noteManager.GetAllNotes())
                        {
                            Console.WriteLine($"{index}. {note.Key} - {note.Value}");
                            index++;
                        }

                        Console.WriteLine("Note id ?");
                        string noteId = Console.ReadLine();

                        noteManager.RemoveNote(noteId);
                        Console.WriteLine("success");

                        if (Convert.ToInt32(Console.ReadLine()) == 0)
                        {
                            app.RestartProgram();
                        }
                        break;
                    }
            }

            Console.ReadLine();
        }

        private void RestartProgram()
        {
            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
            Environment.Exit(0);
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
