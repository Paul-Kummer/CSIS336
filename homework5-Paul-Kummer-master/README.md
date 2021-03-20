# Homework 5

### Due: Monday 4/27/2020 3:00PM

### Chapters covered: 16-21

## Instructions:

Open solution `FileProcessingApp.sln`. 

**File Processing Application** (50 pts) - Write an app that takes the following arguments as input on the command line (hint: use the `args` array on `Program.Main()`):

1. An input directory path
2. An output directory path

Hint: To use input arguments when debugging, right-click on the project and select *properties*.  Choose the *Debug* section on the left side.  Enter your arguments in the box labeled *Command line arguments:*.

Perform the following actions with the input:

- Validate that the input directory exists and the output directory does not exist.  If validation fails, write out a message and quit.
- Find all text files (*.txt) in the input directory path
- For each text file found, process the file as follows:
  
  - Any line that starts with # in position 1 is a comment.  This should be written directly to the output.
  - For all other lines, create a dictionary of word counts for all non-comment lines in the file.  These word counts should not include punctuation and should be case-insensitive.  The input data is guaranteed to not contain symbols, only words and punctuation.
  - Output should contain all comments first, followed by all words with their count, ordered by highest occurring words and then by the word.
  
- An output directory structure should be created under the output directory path that matches the input directory structure.
- Each output file should be named `\<InputFileNameWithoutExtension\>-info.txt`.

Demonstrate the use of the following Classes/Methods:

- File.OpenText()
- File.ReadText()
- Directory.GetFiles()
- Directory.CreateDirectory()
- Dictionary<TKey,TValue>
- string.ToLower()
- char.IsPunctuation

Sample input has been provided.  Please test using your own input as well.

***Example:***

Given the following file structure:


    c:\temp\
        testFiles1\
            testFile.txt
        testFiles2\
            testFile.txt

Where both instances of testFile.txt contain:
```
# An Initial Comment
This is a test, this is only a test.
# Another comment
Test the File Processing App.
# One last comment
```

Calling `FileProcessingApp.exe c:\temp\ c:\temp2\` should produce the following output file structure:

    c:\temp2\
        testFiles1\
            testFile-info.txt
        testFiles2\
            testFile-info.txt

Where both instances of testFile-info.txt contain:
```
# An Initial Comment
# Another comment
# One last comment
this 3
a 2
is 2
this 2
app 1
file 1
only 1
processing 1
the 1
```