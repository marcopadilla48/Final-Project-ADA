int option;

Character[] roster =
{
    new Character { Name = "OSO BIMBO", Hp = 130, MaxHp = 130, Attack = 11, Hability = "AGRESIVITY", Level = 1 },
    new Character { Name = "DOCTOR SIMI", Hp = 100, MaxHp = 100, Attack = 13, Hability = "INVISIBILITY", Level = 1 },
    new Character { Name = "Mamá Lucha", Hp = 110, MaxHp = 110, Attack = 14, Hability = "SUPER VELOCITY", Level = 1 },
    new Character { Name = "Vaquita Alpura", Hp = 120, MaxHp = 120, Attack = 12, Hability = "INVISIBILITY", Level = 1 },
    new Character { Name = "Reno Telcel", Hp = 95, MaxHp = 95, Attack = 16, Hability = "LASER RAYS", Level = 1 },
    new Character { Name = "Pantera UP", Hp = 105, MaxHp = 105, Attack = 17, Hability = "AGRESIVITY", Level = 1 },
    new Character { Name = "Borrego TEC", Hp = 90, MaxHp = 90, Attack = 11, Hability = "LASER RAYS", Level = 1 },
    new Character { Name = "Winnieh Poh Matrix", Hp = 100, MaxHp = 100, Attack = 15, Hability = "SUPER VELOCITY", Level = 1 },
    
};

do
{
    DisplayMenu();
    if (!int.TryParse(Console.ReadLine(), out option)) //Validate the option that the user puts 
    {
        option = 0; //Here we check that if we put letters its invalid
    }
    
    Console.WriteLine();
    if (option == 1)
    {
        Console.Write(" Characters available ");
        Console.WriteLine();
        Console.WriteLine($"{"#",-3}{"NAME",-20}{"HP",5}{"ATK",6}   {"HABILITY",-16}");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"{1,-3}{"OSO BIMBO",-20}{130,5}{11,6}   {"AGRESIVITY",-16}");
        Console.WriteLine($"{2,-3}{"DOCTOR SIMI",-20}{100,5}{13,6}   {"INVISIBILITY",-16}");
        Console.WriteLine($"{3,-3}{"MAMA LUCHA",-20}{110,5}{14,6}   {"SUPER VELOCITY",-16}");
        Console.WriteLine($"{4,-3}{"VAQUITA ALPURA",-20}{120,5}{12,6}   {"INVISIBILITY",-16}");
        Console.WriteLine($"{5,-3}{"RENO TELCEL",-20}{95,5}{16,6}   {"LASER RAYS",-16}");
        Console.WriteLine($"{6,-3}{"PANTERA UP",-20}{105,5}{17,6}   {"AGRESIVITY",-16}");
        Console.WriteLine($"{7,-3}{"BORREGO TEC",-20}{90,5}{11,6}   {"LASER RAYS",-16}");
        Console.WriteLine($"{8,-3}{"WINNIE POOH MATRIX",-20}{100,5}{15,6}   {"SUPER VELOCITY",-16}");

        Console.WriteLine();
        Console.Write("Habilities ");
        Console.WriteLine();
        Console.WriteLine($"Invisibility- Recupera 25 de vida por turno");
        Console.WriteLine($"Aggresivity- Hace que el siguiente golpe cause el doble de daño");
        Console.WriteLine($"Super velocity- Ataca dos veces seguidas");
        Console.WriteLine($"Laser rays- Hace 35 de daño directo");
    }

    else if (option == 2)
    {
        Console.Write(" Choose fighters ");
    }
    else if (option == 3)
    {
        Console.Write(" Stats/Ranking ");
    }
    else if (option == 4)
    {
        Console.Write(" Exit ");
    }
  else 
    {
    Console.WriteLine("Invalid option");
    }
    if (option != 4)      //The user put other thing that the other options 
    {
        Console.WriteLine();
        Console.WriteLine("PRESS AN KEY TO SATART AGAIN");
        Console.ReadKey();
    }
}while (option != 4);
static void ValidateDouble(out double value)    //Here we value that in the menu options the user only put numbers and the options permitted 
{
    while (!double.TryParse(Console.ReadLine(), out value))
    {
        Console.Write("Invalid input, try again: ");
    }
}

 



 static void DisplayMenu()
{
    Console.Clear();
    Console.WriteLine("=====================================");  //MENU DISPLAY
    Console.WriteLine("|  ATTACK OF THE COSTUME CHARACTERS |");  //MENU DISPLAY
    Console.WriteLine("|   1.Characters available          |");  //MENU DISPLAY
    Console.WriteLine("|   2.Choose fighters               |");  //MENU DISPLAY
    Console.WriteLine("|   3. Fight                        |");  //MENU DISPLAY
    Console.WriteLine("|   4. Stats/Ranking                |");  //MENU 
    Console.WriteLine("|   5.Exit                          |");  //MENU DISPLAY
    Console.WriteLine("=====================================");  //MENU DISPLAY
    Console.WriteLine("Select an option (1-5): ");
}

struct  Character
{
    public string Name;
    public int Hp;
    public int MaxHp;
    public int Attack;
    public string Hability;
    public int Level;
    public int Wins;
    public bool HabilityUsed;
}
