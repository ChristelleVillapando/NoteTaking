using System;
using System.Collections.Generic;
using NoteTaking;

// logic errors:  4 edit NB (notebook not found daw pero edited successfully )
// 6 - DELETE NB , notebook not found deletion failed 
// Logic errors corrections: 3 - display; 5 - search notebook

public class Program
{
    public static void Main(string[] args)

    
    {
        NotebookManager notebookManager = new NotebookManager();
         bool Run = true;
         while (Run){
        Console.WriteLine("Welcome to NoteTaking! ");
        Console.WriteLine("1. Add Notebook");
        Console.WriteLine("2. Choose Notebook");
        Console.WriteLine("3. Display Notebooks");
        Console.WriteLine("4. Edit Notebook Title");
        Console.WriteLine("5. Search Notebook");
        Console.WriteLine("6. Delete Notebook");
        Console.WriteLine("0. Exit");
        Console.WriteLine("Enter your choice");
        string? notebookchoice = Console.ReadLine();
        
        
        if (notebookchoice == "1")
        {
            //add new notebook
            Console.WriteLine("Enter Notebook Title");
            string? Notebooktitle = Console.ReadLine();

            while (string.IsNullOrEmpty(Notebooktitle?.Trim()))
            {
                Console.WriteLine("Notebook title cannot be empty. ");
                Notebooktitle = Console.ReadLine();
            }

            notebookManager.AddNotebook(Notebooktitle);
            Console.WriteLine("Notebook added successfully. ");


        }
        else if (notebookchoice == "2")
        {
        
        // pull out the chosen notebook and add notes in it

       
        
        Console.WriteLine("Enter the title of the notebook you want to add notes in. "); 
        string? chosenNotebook = Console.ReadLine();
        

        if(chosenNotebook != null){

            Console.WriteLine($"Notebook '{chosenNotebook}' chosen successfully. ");
            Notebook notebook = new Notebook();
            bool chosenNotebookRunning = true;
            while (chosenNotebookRunning){
            
            
            Console.WriteLine("1. Add Note");
            Console.WriteLine("2. Display Notes");
            Console.WriteLine("3. Edit Note");
            Console.WriteLine("4. Delete Note");
            Console.WriteLine("5. Search Note");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                //add notes
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
                //display notes
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
                //edit notes
                Console.WriteLine("Enter the title of the note to edit:");
                string? title = Console.ReadLine();

                Console.WriteLine("Enter new note content:");
                string? newContent = Console.ReadLine();

                notebook.EditNote(title, newContent);
                Console.WriteLine("Note edited successfully!");
            }
            else if (choice == "4")
            {
                //delete note
                Console.WriteLine("Enter the title of the note to delete:");
                string? title = Console.ReadLine();

                notebook.DeleteNote(title);
                Console.WriteLine("Note deleted successfully!");
            }
            else if (choice == "5")
            {
                //note search
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
            else if (choice == "0")
             {
                chosenNotebookRunning = false;
                

           }
            else
            {
                Console.WriteLine("Invalid choice! Try again.");
            }

            }

            
        }
        else {
            Console.WriteLine("Notebook not found");
        }

            
     }

       

        else if (notebookchoice == "3")
        {
            //display all notebooks
            List<Notebook> notebooks = notebookManager.GetAllNotebooks();

                 Console.WriteLine("---- All Notebooks ----");
                     foreach (Notebook notebook in notebooks)
                    {
                         Console.WriteLine($"Notebook Title: {notebook.NotebookTitle}");
                    }
                Console.WriteLine("-----------------------");
                    
 

        }
        else if (notebookchoice == "4")
        {
            //edit notebook title
            Console.WriteLine("Enter the title of the notebook you want to edit.");
            string? Notebooktitle = Console.ReadLine();

            Console.WriteLine("Enter new notebook title");
            string? newNotebookTitle = Console.ReadLine();

            notebookManager.EditNotebookTitle(Notebooktitle, newNotebookTitle);
            Console.WriteLine("Notebook title edited successfully. ");


        }
        else if (notebookchoice == "5")
        {
            //search notebooks
                 
        Console.WriteLine("Enter the term of the notebook you want to search");
        string? searchNotebookTerm = Console.ReadLine();

        List<Notebook> searchNotebookResults = notebookManager.SearchNotebooks(searchNotebookTerm);

            if (searchNotebookResults.Count > 0)
                {
                    Console.WriteLine($"---- Search Results for '{searchNotebookTerm}' ----");
                    foreach (Notebook notebook in searchNotebookResults)
                        {
                            Console.WriteLine($"Notebook Title: {notebook.NotebookTitle}");
                        }
                            Console.WriteLine("----------------------------------------------");
                }
            else
                {
                     Console.WriteLine("No matching notebooks found!");
                }


        }
        else if (notebookchoice == "6")
        {
            //delete notebook
        Console.WriteLine("Enter the title of the notebook you want to delete:");
    string? notebookTitleToDelete = Console.ReadLine();

    bool isDeleted = notebookManager.DeleteNotebook(notebookTitleToDelete);

    if (isDeleted)
    {
        Console.WriteLine("Notebook deleted successfully!");
    }
    else
    {
        Console.WriteLine("Notebook not found. Deletion failed.");
    }

        }
        else if (notebookchoice == "0")
        {
            //exit
            Run = false;
        }

        else 
        {
            Console.WriteLine("Invalid choice please try again.");
        }
        
    }
    }
}
