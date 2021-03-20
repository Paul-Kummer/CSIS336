using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * **Mammals Classification Application** (35 pts.) - Inside the `Mammals` project, there is a spreadsheet which catalogs all species in the class mammals, by order, family, genus and species.  There is an object model of each categorization with one to many relationships between the classes as follows:

            Order -> Family -> Genus -> Species   

  The code to read the spreadsheet into the object model is already present and the `MammalsForm_Load()` method of the Mammals form already contains a list of the top-level orders of the object graph. 

  The tasks for this exercise are:

  - [ ] Add a tree view to the form and write code to display the hierarchy of all species.
  - [ ] Add a `Name` textbox with label to the form and write code to display the name of the selected item in the tree.
  - [ ] Add a text box and label for `CommonName`, `Author` and `Date` and write code to display the properties of a species if one is selected in the tree view.
  - [ ] (Bonus Points) Add a search box to allow searching for any of the items in the tree by name and search for species by any of the species properties.
 */

namespace Mammals
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MammalsForm());
        }
    }
}
