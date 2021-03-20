# Homework 4

### Due: Monday 4/13/2020 3:00PM

### Chapters covered: 13-15

## Instructions:

Open solution `Homework4.sln`. 

**Exercise 13.10** (15 pts) - Format Exceptions.  Open project `Exercise_13_10` and complete the exercise from the book.  In addition to handling `FormatException`, handle `DivideByZeroException` in cases when zero is entered as number of gallons.

**Mouse reporting application** (20 pts.) - Create a WinForms app that tracks and reports mouse movement over an object.

  - [ ] Create a new WinForms project in Homework4 named `MouseReporting`.  (Right-click on the Homework4 solution and choose *Add->New Project*.)
  - [ ] Add a picture box to the form containing any picture of your choice.
  - [ ] Add 2 labels to the form and add code to perform the following: 

  - one reports whether the mouse is inside or outside the picture box. 
          
            Reported Values: Mouse In / Mouse Out
          
  - the other reports whether a mouse button is pressed when over the picture box and which button is selected. 
        
            Reported Values: Button Up / Button Down Left / Button Down Middle / Button Down Right

**Mammals Classification Application** (35 pts.) - Inside the `Mammals` project, there is a spreadsheet which catalogs all species in the class mammals, by order, family, genus and species.  
        There is an object model of each categorization with one to many relationships between the classes as follows:

            Order -> Family -> Genus -> Species   

  The code to read the spreadsheet into the object model is already present and the `MammalsForm_Load()` method of the Mammals form already contains a list of the top-level orders of the object graph. 

  The tasks for this exercise are:

  - [ ] Add a tree view to the form and write code to display the hierarchy of all species.
  - [ ] Add a `Name` textbox with label to the form and write code to display the name of the selected item in the tree.
  - [ ] Add a text box and label for `CommonName`, `Author` and `Date` and write code to display the properties of a species if one is selected in the tree view.
  - [ ] (Bonus Points) Add a search box to allow searching for any of the items in the tree by name and search for species by any of the species properties.

**File Viewer Application** (20 pts.) - Create a Winforms app that provides selection of a text file and displays the contents.

  - [ ] Create a new WinForms project in Homework4 named `FileViewer`. (Right-click on the Homework4 solution and choose *Add->New Project*.)
  - [ ] Add a text box to the form and make it a) multi line b) read only and c) containing scrollbars
  - [ ] Add a button to the form that uses the open file dialog to select a text file and display the contents in the text box added above. (Note: The open file dialog should be filtered to only select text (*.txt) files)
  - [ ] Exercise the new form by selecting different sized text files.  Ensure the scrollbar allows all text to be visible.
  - [ ] (Bonus Points) Allow multiple files to be selected and provide buttons on the form to navigate between selected text.

Notes:

You can switch the active project by right-clicking on a project and choosing *Set as Startup Project*.

Commit all of your changes and push them to the remote repo before the due date.
