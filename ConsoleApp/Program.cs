using System;
using System.Text;
using static System.Console;

var p1 = new Person()
{
    FirstName = "Denis",
    LastName = "Bittencourt",
    Age = 30
};

var p2 = new Person()
{
    FirstName = "Denis",
    LastName = "Bittencourt",
    Age = 30
};

var p3 = new
{
    FirstName = "Denis",
    LastName = "Bittencourt",
    Age = 30
};

Print(p1, '\n', p2, '\n', p3);
Print("p1 == p2?", p1 == p2);
Print("p1 Equals p2?", p1.Equals(p2));
Print("p2 Equals p3?", p2.Equals(p3));
Print();

Print("Changing person", nameof(p2));
(p2.FirstName, p2.Age) = ("Diego", 27);
Print(p2);
Print("p1 == p2?", p1 == p2);
Print("p1 Equals p2?", p1.Equals(p2));
Print();

var p4 = new Person()
{
    FirstName = "Denis",
    LastName = "Bittencourt",
    Age = 30
};

var p5 = new Worker()
{
    FirstName = "Denis",
    LastName = "Bittencourt",
    Age = 30,
    JobTitle = "Software Developer"
};

var p6 = p5 with { UseHacking = true };

Print(p4, p5);
Print("Person == Worker?", p4 == p5);
Print("Person == Worker? (Using hacking)", p4 == p6);
Print(nameof(p6), "is", p6);
Print();

var a1 = new Alien("RX-65965-PQ", "Grey", "Pluto");
var a2 = new Sayajin("Goku", "Vegeta");
var (name, planet) = a2;
Print(a1);
Print("Alien", name, "from planet", planet);
Print();

ReadKey(intercept: true);

static void Print(params object[] args)
{
    for (int i = 0; i < args?.Length; i++)
    {
        Write(args[i]);

        if (i < args?.Length - 1 && !'\n'.Equals(args[i]))
            Write(" ");
    }
    
    WriteLine();
}

public record Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

public record Worker : Person
{
    public bool UseHacking { get; init; }
    public string JobTitle { get; init; }

    protected override Type EqualityContract => UseHacking ? base.EqualityContract : typeof(Worker);

    protected override bool PrintMembers(StringBuilder builder)
    {
        builder.Append($"Hi! My name is {FirstName} {LastName}. I'm {Age} and my job title is {JobTitle}");
        return true;
    }
}

public record Alien(string Name, string Race, string Planet);

public record Sayajin(string Name, string Planet) : Alien(Name, "Sayajin", Planet);

public record InvisibleAlien;