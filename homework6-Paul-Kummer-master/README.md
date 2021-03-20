# Homework 6

### Due: Monday 5/4/2020 3:00PM

### Chapters covered: 21-23

## Instructions:

**Download Book Text Application** (30 pts) - Modify an application to asynchronously download book text and count words.

Open solution `DownloadBookText.sln`.

The `Main()` method in `Program.cs` downloads the first 20 chapters of the text of Moby Dick and generates a dictionary of all words with a word count.  It then merges all dictionaries together and reports the top 200 words in the first 20 chapters.  It calls a helper method to download the text called `textProcessor.ProcessText(uri)`.

Modify this process to use tasks to dowload all text asynchronously using `textProcessor.ProcessTextAsync(uri)` instead.  Wait for all tasks to finish and then merge the results into `masterWordList`.  

Hint: Your tasks will be of type `Task<Dictionary<string, int>>`.
 
**Books / Authors Querying App** (60 pts) - Write an app that manages books and authors.

Open solution `BooksExample.sln`. 

IMPORTANT: You may need to right-click on the `BooksExamples` project and select *Build* to initially build the project.

In the `BooksSearch` project, write a command line app that allows searching and modifying the data in the `BooksModel`.
The model is created and referenced for you.  Used the `BooksEntities` context to manipulate the data.  Provide the following commands for your app:

    Create commands:
        ca <firstName> <lastName> - Add an author with the given name
        cb <ISBN> "<Title>" <EditionNumber> <Copyright> <authorId> - Add a book with the given information 
        aa <ISBN> <AuthorId> - Assign an author to a book

    Read commands:
        ra <term> - Search for an author containing the given term
        rb <term> - Search for a book containing the givent term

    Update commands:
        ua/<old text>/<new text> - Modify author replacing old text with new text
        ub/<old text>/<new text> - Modify book replacing old text with new text

    Delete commands:
        da <term> - Delete an author containing the given term
        db <term> - Delete a book containing the given term

    Misc commands:
        lc - List commands
        q - Quit

For each of the commands, validate the data and provide an appropriate error if the data isn't correct.  Show the results of each command.

Notes:

  - Searches are case insensitive except for the update command.  Update is case sensitive.
  - Searches search all string fields in the data.
  - All data in the tables are strings except for AuthorID and EditionNumber.
  - When adding an Author, the AuthorID doesn't need to be specified, since it is an identity column an is automatically updated by the database.
  - When entering information for a book, the Title needs to be entered in quotes to allow for spaces in the title. 
