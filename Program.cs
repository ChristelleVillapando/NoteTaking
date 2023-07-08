using System;
using System.Collections.Generic;
using NoteTaking;


public class Program
{
    public static void Main(string[] args)
    {
        Notebook notebook = new Notebook();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("1. Add Note");
            Console.WriteLine("2. Display Notes");
            Console.WriteLine("3. Edit Note");
            Console.WriteLine("4. Delete Note");
            Console.WriteLine("5. Search Note");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Enter note title:");
                string? title = Console.ReadLine();

                while (string.IsNullOrEmpty(title?.Trim()))
                {
                    Console.WriteLine("Title cannot be empty. Please type your title: ");
                    title = Console.ReadLine();
                }

                Console.WriteLine("Enter note content:");
                string? content = Console.ReadLine();
                while (string.IsNullOrEmpty(content?.Trim()))
                {
                    Console.WriteLine("Content cannot be empty. Please type your content: ");
                    content = Console.ReadLine();
                }

                notebook.AddNote(title, content);
                Console.WriteLine("Note added successfully!");
            }
            else if (choice == "2")
            {
                List<Note> notes = notebook.DisplayNote();

                Console.WriteLine("---- All Notes ----");
                foreach (Note note in notes)
                {
                    Console.WriteLine($"Title: {note.Title}");
                    Console.WriteLine($"Content: {note.Content}");
                    Console.WriteLine($"Created At: {note.CreatedAt}");
                    Console.WriteLine("-------------------");
                }
            }
            else if (choice == "3")
            {
                
                Console.WriteLine("Enter the title of the note to edit:");
                string? title = Console.ReadLine();

                Console.WriteLine("Enter new note content:");
                string? newContent = Console.ReadLine();

                notebook.EditNote(title, newContent);
                Console.WriteLine("Note edited successfully!");
            }
            else if (choice == "4")
            {
                Console.WriteLine("Enter the title of the note to delete:");
                string? title = Console.ReadLine();

                notebook.DeleteNote(title);
                Console.WriteLine("Note deleted successfully!");
            }
            else if (choice == "5")
            {
                Console.WriteLine("Enter the term of the note you want to search");
                string? searchNoteTerm = Console.ReadLine();

                List<Note> searchResults = notebook.SearchNotes(searchNoteTerm);

                if (searchResults.Count > 0)
                {
                    Console.WriteLine($"---- Search Results for '{searchNoteTerm}' ----");
                    foreach (Note note in searchResults)
                    {
                        Console.WriteLine($"Title: {note.Title}");
                        Console.WriteLine($"Content: {note.Content}");
                        Console.WriteLine($"Created At: {note.CreatedAt}");
                        Console.WriteLine("-------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No matching notes found!");
                }
            }
            else if (choice == "6")
            {
                Console.WriteLine("Thanks for using NoteTaking!");
                isRunning = false;
                
            }
            else
            {
                Console.WriteLine("Invalid choice! Try again.");
            }

            Console.WriteLine();
        }
    }
}
