NameGeneration
==============

Random name generator for C#. Names are generated with a probability close to their real-world frequency.


To use
------

Build the project and add NameGeneration.dll as a reference.

Basic usage:

    // using NameGeneration;
    var nameGenerator = new NameGenerator();
    
    // A full name object contains a first name, last name, composite full name, and gender indicator.
    FullName newName = nameGenerator.New();
    Console.WriteLine(newName.Full);
    //-> William Richardson
    
    string girl = nameGenerator.NewFirst(NameGender.Female);
    Console.WriteLine(girl);
    //-> Barbara


Code
----

Text files with names & number of occurences are converted into source code using a T4 template.
