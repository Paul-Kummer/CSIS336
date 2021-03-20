using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BooksExamples;

namespace BooksSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t[ Sample Command Args ]");
            Console.WriteLine("ca Paul Kummer cb 0 \"I am a new book\" 1 2020 0 aa 0 2 ra kUmmE rb \"how To\" ua \"paul/luap remmuk\" ub \"new book/i am old book\" da purple da remmuk db \"how to\"");

            while (!ExecCmds(args)) // reads any command line arguments first before asking for additional input
            {
                Console.WriteLine("\nPlease Enter New Command");
                string userIn = Console.ReadLine();

                args = userIn.Split('"')
                     .Select((element, index) => index % 2 == 0  // If even index
                        ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  // Split the item
                        : new string[] { element })  // Keep the entire item
                     .SelectMany(element => element).ToArray();
            }
        }

        static bool ExecCmds(string[] args)
        {
            var commandDict = new Dictionary<string, string>()
            {
                {"ca", "create <firstName> <lastName> - Add an author with the given name" },
                {"cb", "create <ISBN> \"<Title>\" <EditionNumber> <Copyright> <authorId> - Add a book with the given information " },
                {"aa", "create <ISBN> <AuthorId> - Assign an author to a book" },
                {"ra", "read <term> - Search for an author containing the given term" },
                {"rb", "read <term> - Search for a book containing the givent term" },
                {"ua", "update <old text>/<new text> - Modify author replacing old text with new text" },
                {"ub", "update <old text>/<new text> - Modify book replacing old text with new text" },
                {"da", "delete <term> - Delete an author containing the given term" },
                {"db", "delete <term> - Delete a book containing the given term" },
                {"lc", "list commands" },
                {"?", "list commands" },
                {"show", "show books and authors in DB" },
                {"q", "quit" }
            };

            BooksEntities bkEnts = new BooksEntities();
            Book book = new Book();
            Author author = new Author();
            bool shouldExit = false;


            for (int curIndex = 0; curIndex < args.Length; curIndex++)
            {
                try
                {
                    string lowerArg = args[curIndex].ToLower();
                    string cmdTerm = "", cmdTermTwo = "", cmdTermThree = "", cmdTermFour = "", cmdTermFive = "" ;
                    int editionNum = 0, authID = 0;

                    switch (lowerArg)
                    {
                        case "ca": // create <firstName> <lastName> - Add an author with the given name
                            curIndex++;
                            cmdTerm = args[curIndex];// firstName
                            curIndex++;
                            cmdTermTwo = args[curIndex]; // lastName

                            Author newAuth = new Author();
                            newAuth.FirstName = cmdTerm;
                            newAuth.LastName = cmdTermTwo;

                            bkEnts.Authors.Add(newAuth);
                            bkEnts.SaveChanges();

                            bkEnts.Authors
                                .Where(a => a.AuthorID == newAuth.AuthorID)
                                .Select(a => new { a.LastName, a.FirstName})
                                .Display("Author Added:");
                            break;

                        case "cb": //create <ISBN> "<Title>" <EditionNumber> <Copyright> <authorId> - Add a book with the given information
                            curIndex++;
                            cmdTerm = args[curIndex]; // ISBN
                            curIndex++;
                            cmdTermTwo = args[curIndex]; // Title
                            curIndex++;
                            cmdTermThree = args[curIndex]; // EditionNum
                            int.TryParse(cmdTermThree, out editionNum);
                            curIndex++;
                            cmdTermFour = args[curIndex]; // Copyright
                            curIndex++;
                            cmdTermFive = args[curIndex]; // authorID, could make this an IEnumerable to add multiple authors
                            int.TryParse(cmdTermFive, out authID);

                            var authToAdd = (from auth in bkEnts.Authors
                                             where authID == auth.AuthorID
                                             select auth).ToArray();

                            Book newBook = new Book();
                            newBook.ISBN = cmdTerm;
                            newBook.Title = cmdTermTwo;
                            newBook.EditionNumber = editionNum;
                            newBook.Copyright = cmdTermFour;
                            newBook.Authors = authToAdd;

                            bkEnts.Books.Add(newBook);
                            bkEnts.SaveChanges();

                            bkEnts.Books
                                .Where(bk => bk.ISBN == newBook.ISBN)
                                .Select(x => new { x.ISBN, x.Title, x.EditionNumber, x.Copyright })
                                .Display("Book Added:");
                            break;

                        case "aa": // create <ISBN> <AuthorId> - Assign an author to a book
                            curIndex++;
                            cmdTerm = args[curIndex]; // ISBN
                            curIndex++;
                            cmdTermTwo = args[curIndex]; // AuthorID
                            int.TryParse(cmdTermTwo, out authID);

                            Author[] getAuth = (from auth in bkEnts.Authors
                                             where authID == auth.AuthorID
                                             select auth).ToArray();

                            var bookToAddAuth = bkEnts.Books.Where(bk => bk.ISBN == cmdTerm).First();

                            bookToAddAuth.Authors = getAuth;
                            bkEnts.SaveChanges();

                            bkEnts.Books.Where(bk => bk.ISBN == bookToAddAuth.ISBN)
                                .Select(bk => new { bk.Title , bk.ISBN})
                                .Display($"{getAuth.Single().FirstName} {getAuth.Single().LastName} Added to: ");
                            break;

                        case "ra": // read <term> - Search for an author containing the given term
                            curIndex++;
                            cmdTerm = args[curIndex]; // author name search term

                            bkEnts.Authors
                                .Where(auth => auth.FirstName.ToLower().Contains(cmdTerm.ToLower()) | auth.LastName.ToLower().Contains(cmdTerm.ToLower()))
                                .OrderBy(auth => auth.LastName)
                                .Select(bk => new { bk.LastName, bk.FirstName, bk.AuthorID })
                                .Display($"Search For Author: {cmdTerm}");
                            break;

                        case "rb": // read <term> - Search for a book containing the given term
                            curIndex++;
                            cmdTerm = args[curIndex]; // book title search term

                            bkEnts.Books
                                .Where(tmpBook => tmpBook.Title.ToLower().Contains(cmdTerm.ToLower()))
                                .OrderBy(tmpBook => tmpBook.Title)
                                .Select(tmpBook => new { tmpBook.Title, tmpBook.ISBN })
                                .Display($"Search For Title: {cmdTerm}");
                            break;

                        case "ua": // update <old text>/<new text> - Modify author replacing old text with new text
                            curIndex++;
                            var splitArg = args[curIndex].Split('/');
                            cmdTerm = splitArg[0]; // old text for author name
                            var splitArgTwo = splitArg[1].Split(' ');
                            string authorFName = splitArgTwo[0]; // new first name
                            string authorLName = splitArgTwo[1]; // new last name

                            Author chgAuth = bkEnts.Authors
                                .Where(auth =>  string.Concat(auth.FirstName.ToLower(), " ", auth.LastName.ToLower()).Contains(cmdTerm.ToLower()))
                                .Select(auth => auth)
                                .FirstOrDefault();

                            chgAuth.FirstName = authorFName;
                            chgAuth.LastName = authorLName;

                            bkEnts.SaveChanges();

                            bkEnts.Authors
                                .Where(auth => chgAuth.AuthorID == auth.AuthorID)
                                .Select(x => new { x.LastName, x.FirstName, x.AuthorID })
                                .Display($"{cmdTerm} Author Name Changed");
                            break;

                        case "ub": // update <old text>/<new text> - Modify book replacing old text with new text
                            curIndex++;
                            cmdTerm = args[curIndex].Split('/')[0]; // old text for book title
                            cmdTermTwo = args[curIndex].Split('/')[1]; // new text for book title

                            Book updateBook = bkEnts.Books
                                .Where(bk => bk.Title.ToLower().Contains(cmdTerm.ToLower()))
                                .Select(bk => bk).FirstOrDefault();

                            updateBook.Title = cmdTermTwo;

                            bkEnts.SaveChanges();

                            bkEnts.Books
                                .Where(bk => bk.ISBN == updateBook.ISBN)
                                .Select(x => new { x.Title, x.ISBN })
                                .Display($"{cmdTerm} Book Title Changed");

                            break;

                        case "da": // delete <term> - Delete an author containing the given term
                            curIndex++;
                            cmdTerm = args[curIndex].ToLower(); // author name of author to delete
                            var booksToDelAuth = new List<Book>();

                            Author rmAuth = bkEnts.Authors
                                .Where(auth => string.Concat(auth.FirstName.ToLower(), " ",auth.LastName.ToLower()).Contains(cmdTerm))
                                .Select(a => a)
                                .FirstOrDefault();

                            if (rmAuth != null)
                            {
                                
                                
                                foreach (Book tmpBk in bkEnts.Books)
                                {
                                    foreach(Author tmpA in tmpBk.Authors)
                                    {
                                        if (tmpA.AuthorID == rmAuth.AuthorID)
                                        {
                                            booksToDelAuth.Add(tmpBk);
                                        }
                                    }
                                }

                                foreach(Book bk in booksToDelAuth)
                                {
                                    // doesn't work
                                    bk.Authors.Remove(bkEnts.Authors.Where(a => a.AuthorID == rmAuth.AuthorID).Select(a => a).Single());
                                }
                                
                                //bkEnts.Authors.Remove(rmAuth); doesn't work
                                //bkEnts.Authors.Remove(bkEnts.Authors.Where(a => a.AuthorID == rmAuth).Single()); doesn't work

                                bkEnts.SaveChanges();
                            }
                            
                            bkEnts.Authors
                                .OrderBy(a => a.LastName)
                                .Select(a => new { a.LastName, a.FirstName, a.AuthorID})
                                .Display($"Author \"{cmdTerm}\" Removed:");
                            break;

                        case "db": // delete <term> - Delete a book containing the given term
                            curIndex++;
                            cmdTerm = args[curIndex].ToLower().Replace("\"", string.Empty); // book title of book to delete 

                            var rmBook = bkEnts.Books
                                .Where(bk => bk.Title.ToLower().Contains(cmdTerm))
                                .Select(bk => bk)
                                .FirstOrDefault();

                            if(rmBook != null)
                            {
                                bkEnts.Books.Remove(rmBook); // not working
                                bkEnts.SaveChanges();
                            }

                            bkEnts.Books
                                .Select(b => new { b.Title, b.ISBN})
                                .Display($"Book \"{cmdTerm}\" Removed:");
                            break;

                        case "?":
                        case "lc": // list commands
                            commandDict.Select(cmds => $"{cmds.Key} : {cmds.Value}").Display("\t[ Commands ]");
                            break;

                        case "q": // quit
                            shouldExit = true;
                            break;

                        case "show": // show the books and titles in db
                            WhatsInTheDB();
                            break;

                        default:
                            break;
                    }
                }

                catch (IndexOutOfRangeException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t--- ERROR ---\nNothing at this index! Most likely a parameter for a command wasn't entered or no command was entered.");
                    Console.WriteLine("\n", e.StackTrace);
                    Console.ResetColor();
                }
            }

            return shouldExit;
        }


        public static void WhatsInTheDB()
        {
            var bookDB = new BooksEntities();

            foreach (var bkEnt in bookDB.Books)
            {
                Console.WriteLine($"Book Title: {bkEnt.Title}");
                Console.Write("Book Authors: ");
                foreach (var auth in bkEnt.Authors)
                {
                    Console.Write($"{auth.FirstName} {auth.LastName}, ");
                }
                Console.Write("\n\n");
            }
        }
    } 
    
    public static class EnumerableExt
    {
        public static void Display(this IEnumerable list, string header)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{header}");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ResetColor();
        }
    }
}

/*
For each of the commands, validate the data and provide an appropriate error if the data isn't correct.  Show the results of each command.

Notes:

  - Searches are case insensitive except for the update command.  Update is case sensitive.
  - Searches search all string fields in the data.
  - All data in the tables are strings except for AuthorID and EditionNumber.
  - When adding an Author, the AuthorID doesn't need to be specified, since it is an identity column an is automatically updated by the database.
  - When entering information for a book, the Title needs to be entered in quotes to allow for spaces in the title. 
  */
