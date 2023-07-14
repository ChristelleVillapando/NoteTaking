using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteTaking
{
    public class NotebookManager
    {
        private List<Notebook>? notebooks;
        private object newTitle;
        private object noteToEdit;
        private string newNotebookTitle;
        private object? title;
        private string? oldNotebookTitle;

        public object? notebookTitle { get; private set; }
        #pragma warning disable CS8600

        public NotebookManager()
        {
            notebooks = new List<Notebook>();          
        }

        public void AddNotebook(string Notebooktitle)
        {
            Notebook notebook = new Notebook()
            {
                 NotebookTitle = Notebooktitle,
            };
            notebooks.Add(notebook);
        }

        public List<Notebook>? GetAllNotebooks()
        {
            return notebooks?.ToList();
        }
        
        public string? GetNotebookTitle(string Notebooktitle)
        {
           Notebook notebook = notebooks.Find(notebook => string.Equals(notebook.NotebookTitle, (string?)notebookTitle, StringComparison.OrdinalIgnoreCase));
            return notebook?.NotebookTitle;
        }

        public void EditNotebookTitle(string oldNotebooktitle, string? newNotebookTitle)
        {
        //    Note notebookToEdit = notebooks.Find(notebook => string.Equals(notebook.Title, Notebooktitle, StringComparison.OrdinalIgnoreCase));
        //     if (noteToEdit != null)
        //     {

        //         notebookToEdit.Title = newNotebookTitle;
        //         }
                
        //     }  
          Notebook notebookToEdit = notebooks.Find(notebook => string.Equals((string?)notebook.Title, oldNotebookTitle, StringComparison.OrdinalIgnoreCase));
            if (notebookToEdit != null)
                {
                  notebookToEdit.Title = newNotebookTitle;
                }
            else
                {
                    Console.WriteLine("Notebook not found!");
                }


        }



        public bool DeleteNotebook(string Notebooktitle)
        {

            // Notebook notebookToDelete = notebooks.Find(notebook => string.Equals((string?)notebook.Title, (string?)title, StringComparison.OrdinalIgnoreCase));
            // if (notebookToDelete != null)
            //     {
            //          notebooks.Remove(notebookToDelete);
            //     }
                //second edit
                Notebook notebookToDelete = notebooks.Find(notebook => string.Equals((string?)(notebook?.Title), (string?)title, StringComparison.OrdinalIgnoreCase));
                if (notebookToDelete != null)
                        {
                              notebooks.Remove(notebookToDelete);
                        }
                         return false; // Notebook not found   
        }
                

         public List<Notebook> SearchNotes(string searchTermTitle)
        {
            string searchNotebookTerm = searchTermTitle.ToLower();
            List<Notebook> searchNotebookResults = notebooks.FindAll(notebook => notebook.NotebookTitle.ToLower().Contains(searchNotebookTerm));
           
            return searchNotebookResults;
        }

        internal List<Notebook> SearchNotebooks(string? searchNotebookTerm)
        {
            throw new NotImplementedException();
        }
    }
}