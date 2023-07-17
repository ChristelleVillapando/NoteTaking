using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteTaking
{
    public class NotebookManager
    {
        
        public object? newTitle;
        public object? noteToEdit;
        public string? newNotebookTitle;
        public object? title;
        public string? NotebookTitle;
        public object? notebookTitle { get; set; }
        #pragma warning disable CS8600

        public List<Notebook> notebooks;
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
           
            return notebooks; 
        }
        
        public string? GetNotebookTitle(string Notebooktitle)
        {
           Notebook notebook = notebooks.Find(notebook => string.Equals(notebook.NotebookTitle, (string)notebookTitle, StringComparison.OrdinalIgnoreCase));
            return notebook?.NotebookTitle;
        }
        public void EditNotebookTitle(string? Notebooktitle, string? newNotebookTitle)
        {
      
          Notebook notebookToEdit = notebooks.Find(notebook => string.Equals((string)notebook.NotebookTitle, 
          Notebooktitle, StringComparison.OrdinalIgnoreCase));
            if (notebookToEdit != null)
                {
                  notebookToEdit.NotebookTitle = newNotebookTitle;
                }    
        }

        public bool DeleteNotebook(string Notebooktitle)
        {

    
            
            Notebook notebookToDelete = notebooks.Find(notebook => string.Equals((string)notebook.NotebookTitle, 
            Notebooktitle, StringComparison.OrdinalIgnoreCase));
                if (notebookToDelete != null)
                        {
                              notebooks.Remove(notebookToDelete);
                        }
                         return false; 

                         
        }
                

         public List<Notebook> SearchNotebooks(string searchTermTitle)
        {
            string searchNotebookTerm = searchTermTitle.ToLower();
            List<Notebook> searchNotebookResults = notebooks.FindAll(notebook => notebook.NotebookTitle.ToLower().Contains(searchNotebookTerm));
           
            return searchNotebookResults;
        }

        
    }
}