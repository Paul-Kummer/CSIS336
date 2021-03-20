# Homework 3

### Due: Wednesday 3/4/2020 3:00PM

### Chapters covered: 9-12

## Instructions:

Open solution `Homework3.sln`.  
In the corresponding projects, complete the following exercises:
- [ ] 9.5 Sorting Letters and Removing Duplicates
- [ ] 10.4 Modifying the Internal Data Representation of a Class
- [ ] 10.8 Rational Numbers
- [ ] 10.11 Extension Methods for Class Time2 (Add one test each using the new extension method for letters a-b)
- [ ] 10.13 Project: Replacing Rational Methods with Overloaded Operators (Copy your solution for Exercise 10.8 as a starting point for this exercise and rename it `Exercise10_13`)
- [ ] 11.9 Account Inheritance Hierarchy
- [ ] 12.10 Shape Hierarchy
- [ ] Student Grades Exercise - In the `StudentGradesExercise` project write an app that performs the following tasks:
  - [ ] Read in file of students `(AllStudents.csv)` with the following format:
  
    `StudentFirstName,StudentLastName,YearInSchool,Grade1,Grade2,Grade3,.....,GradeN`

    Example:

    `Dan,Seefeldt,4,89,98,78,65,99,100`

  - [ ] Create a list of Student objects (one per line of the file) that contain FirstName, LastName, YearInSchoolEnum (Freshman=1, Sophomore=2, Junior=3, Senior=4), Calculated Average Grade as a `decimal` and Letter Grade based on the following scale:

    | Average Grade | Letter Grade |
    | :-----------: | :----------: |
    |  >=90 | A |
    | >=80 && <90 | B |
    | >=70 && <80 | C |
    | >=60 && <70 | D |
    | <60 | F|

  - [ ] Generate 2 output files using LINQ and File.WriteAllLines():
    
    - [ ] 1.`StudentLastNames.txt` Students by Last Name with space separated fields including:

        `StudentLastName StudentFirstName YearInSchoolEnumString LetterGrade`

        Example:

        `Seefeldt Dan Senior B`
    
    - [ ] 2.`PassingStudentsByYearByGrade.txt` - Students with grades A-D by year in school (Seniors first, Freshman last) and then grade average (higher graded first) with space separated fields including:

        `YearInSchoolEnumString LetterGrade AverageGrade* StudentLastName StudentFirstName`

        Note: AverageGrade should be formatted as percent with 2 decimal places

        Example:

        `Senior B 88.17% Seefeldt Dan`

  - [ ] Add the 2 generated files above to the project under `Output` and commit with your code.



Notes:

You can switch the active project by right-clicking on a project and choosing *Set as Startup Project*.

Commit all of your changes and push them to the remote repo before the due date.
