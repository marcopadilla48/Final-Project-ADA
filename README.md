int option; // Stores the menu option selected by the user
int fighter1 = -1;   //Position of player 1's character (-1 = not chosen)
int fighter2 = -1;   //Position of player 2's character (-1 = not chosen)
Random rnd = new Random();   //Only once, before the loop


Character[] roster =// Initializes the roster of available characters with their stats, abilities, and catchphrases
{
    new Character { Name = "OSO BIMBO", Hp = 130, MaxHp = 130, Attack = 11, Hability = "AGRESIVITY", Level = 1, Catchphrase = "Nunca se confíen del más tierno!!"},
    new Character { Name = "DOCTOR SIMI", Hp = 100, MaxHp = 100, Attack = 13, Hability = "INVISIBILITY", Level = 1, Catchphrase = "Una victoria más para el ahorro"},
    new Character { Name = "Mamá Lucha", Hp = 110, MaxHp = 110, Attack = 14, Hability = "SUPER VELOCITY", Level = 1, Catchphrase = "Julio regresame a mis hijos"},
    new Character { Name = "Vaquita Alpura", Hp = 120, MaxHp = 120, Attack = 12, Hability = "INVISIBILITY", Level = 1, Catchphrase = "La leche se toma entera como la victoria"},
    new Character { Name = "Reno Telcel", Hp = 95, MaxHp = 95, Attack = 16, Hability = "LASER RAYS", Level = 1, Catchphrase = "Acaso te ovlidaste de mi?" },
    new Character { Name = "Pantera UP", Hp = 105, MaxHp = 105, Attack = 17, Hability = "AGRESIVITY", Level = 1, Catchphrase = "Pantera no cualquiera"},
    new Character { Name = "Borrego TEC", Hp = 90, MaxHp = 90, Attack = 11, Hability = "LASER RAYS", Level = 1, Catchphrase = "Fer Mayen, Running back mexicano"},
    new Character { Name = "Winnieh Poh Matrix", Hp = 100, MaxHp = 100, Attack = 15, Hability = "SUPER VELOCITY", Level = 1, Catchphrase = "Que pildora elegiras: la roja o la azul" },
    
};

do // Main game loop that keeps running until the user chooses to exit or finishes
{
    DisplayMenu(); //shows the main menu options
    if (!int.TryParse(Console.ReadLine(), out option)) //Validate the option that the user puts 
    {
        option = 0; //Here we check that if we put letters its invalid
    }
    
    Console.WriteLine();// Prints an empty line for spacing 
    if (option == 1)// Option 1: Displays the character options and ability descriptions
    {
        Console.WriteLine("Catalog of Characters"); 
        Console.WriteLine();// The next line prints column titles
        Console.WriteLine($"{"#",-3}{"NAME",-20}{"HP",5}{"ATK",6}   {"HABILITY",-16}");   //Uso de la ia para que el espaciado quede perfecto
        Console.WriteLine("------------------------------------------------------");
        
        for (int i = 0; i < roster.Length; i++)   //One row per character
        {// Prints formatted character details
            Console.WriteLine($"{i + 1,-3}{roster[i].Name,-20}{roster[i].MaxHp,5}{roster[i].Attack,6}   {roster[i].Hability,-16}"); //uso de la ia para que el espaciado quede perfecto
        }

        Console.WriteLine();
        Console.Write("Habilities ");//print the explanations for habilities
        Console.WriteLine();
        Console.WriteLine($"Invisibility- Get back 25 of its life per turn");//Explanation for invisibility
        Console.WriteLine($"Aggresivity- Causes the next hit to deal double damage");//Explanation of aggresivity
        Console.WriteLine($"Super velocity- Attacks twice in a row");//Explanation of super velocity
        Console.WriteLine($"Laser rays- Deals 35 direct damage");// Explanation of laser rays.
    }

    else if (option == 2)// Option 2: Selection of fighters for players
    {
        Console.WriteLine(" Choose fighters ");
        Console.WriteLine("Catalog of Characters");
        Console.WriteLine();
        Console.WriteLine(// Structured header for selection catalog
            $"{"#",-3}{"NAME",-20}{"HP",5}{"ATK",6}   {"HABILITY",-16}"); //Uso de la ia para que el espaciado quede perfecto
        Console.WriteLine("------------------------------------------------------");

        for (int i = 0; i < roster.Length; i++) //One row per character
        {
            Console.WriteLine(// Prints row data
                $"{i + 1,-3}{roster[i].Name,-20}{roster[i].MaxHp,5}{roster[i].Attack,6}   {roster[i].Hability,-16}"); //uso de la ia para que el espaciado quede perfecto
        }

        ChooseFighter("Player 1, choose your fighter (1-8): ", out fighter1);// Prompts player 1 to choose
        ChooseFighter("Player 2, choose your fighter (1-8): ", out fighter2);// Prompts player 2 to choose
        while (fighter2 == fighter1)
        {
            Console.Write("That fighter has been chosen previously, choose other");// Loop to ensure player 2 doesn't pick the exact same character as player 1
            ChooseFighter("Player 2, choose your fighter (1-8): ", out fighter2);
        }
        Console.WriteLine($"{roster[fighter1].Name} VS {roster[fighter2].Name}!");// Displays the chosen matchup
    }

    else if (option == 3)// Option 3: Starts the combat between chosen fighters
    {
        Console.WriteLine(" Fight ");
        if (fighter1 == -1 || fighter2 == -1)   //-1 = they have not chosen characters yet
        {
            Console.WriteLine("Choose fighters first (option 2).");
        }
        else
        {
            Fight(ref roster[fighter1], ref roster[fighter2], rnd);// Starts the fight
        }
       
    }
    else if (option == 4)// Option 4: Displays stats, wins, levels, and ranking leader
    {
        Console.WriteLine("STATS / RANKING");
        Console.WriteLine();
        Console.WriteLine($"{"#",-3}{"NAME",-20}{"LVL",5}{"WINS",6}{"HP",6}{"ATK",6}");// Stats header
        Console.WriteLine("----------------------------------------------");

        for (int i = 0; i < roster.Length; i++)   //One row per character
        {
            Console.WriteLine($"{i + 1,-3}{roster[i].Name,-20}{roster[i].Level,5}{roster[i].Wins,6}{roster[i].MaxHp,6}{roster[i].Attack,6}");
        }

        //Searcher: the character with more wins is the leader
        int best = 0;   //The first character is the candidate
        for (int i = 1; i < roster.Length; i++)
        {
            if (roster[i].Wins > roster[best].Wins)   //Found one with more wins
            {
                best = i;// Updates the index of the best character
            }
        }

        Console.WriteLine();
        if (roster[best].Wins == 0)   //Nobody has fought yet
        {
            Console.WriteLine("No fights yet. Go to option 2 to choose fighters!");// Checks if no fights have been played yet
        }
        else
        {
            Console.WriteLine($"LEADER: {roster[best].Name} with {roster[best].Wins} wins (level {roster[best].Level})");// Displays leader info
        }
    }
    
    else if (option == 5)// Option 5: Exits the game 
    {
        Console.Write(" Exit ");
    }
    else if (option == 6)// Option 6: Displays instructions and help guide
    {
        Console.WriteLine("Instructions on how to play ");
        Console.WriteLine("1. Choose your character (p1) and the one your gonna fight (p2)");
        Console.WriteLine("2. Select the option in the menu: Fight");
        Console.WriteLine("3. The battle finishes till one of the players run out of health");
        Console.WriteLine("4. After every combat you can see the rankings in the menu of rank/stats");
        Console.WriteLine();
        Console.WriteLine("Habilities ");
        Console.WriteLine();
        Console.WriteLine($"Invisibility- Regain 25 health per turn");
        Console.WriteLine($"Aggresivity- Causes the next hit to deal double damage");
        Console.WriteLine($"Super velocity- Attacks twice in a row");
        Console.WriteLine($"Laser rays- Deals 35 direct damage");
        Console.WriteLine("°The hability from each character can be only used once in each combat");
        Console.WriteLine();
    }
  else 
    {
    Console.WriteLine("Invalid option");// Handles invalid inputs outside the range 1-6
    }
    if (option != 5)      // Pauses execution unless instruction menu (6) was selected
    {
        Console.WriteLine();
        Console.WriteLine("PRESS ANY KEY TO START AGAIN");
        Console.ReadKey(); // Waits for user key press
    }
}while (option != 5);// Runs a validation 
static void ValidateDouble(out double value)    //Here we value that in the menu options the user only put numbers and the options permitted 
{
    while (!double.TryParse(Console.ReadLine(), out value))// Validates that user enters a valid number
    {
        Console.Write("Invalid input, try again: ");
    }
}
 static void Fight(ref Character p1, ref Character p2, Random rnd)   //ref: changes the real characters
{
    //Start of the fight: full life and habilities available
    p1.Hp = p1.MaxHp;
    p2.Hp = p2.MaxHp;
    p1.HabilityUsed = false;
    p2.HabilityUsed = false;

    bool p1Double = false;   //AGRESIVITY active for player 1
    bool p2Double = false;   //AGRESIVITY active for player 2
    int turn = 1;            //1 = player 1, 2 = player 2
    int option;
    int damage;
    bool turnDone;           //true when the player finished a valid action

    Console.WriteLine($"=== {p1.Name} VS {p2.Name} ===");

    while (p1.Hp > 0 && p2.Hp > 0)   //The fight continues while both are alive
    {
        if (turn == 1)   //Turn of player 1
        {
            Console.WriteLine();
            Console.WriteLine($"Turn of {p1.Name}  HP = {p1.Hp}/{p1.MaxHp}");
            Console.WriteLine("1) Weak attack   (always hits, half damage)");
            Console.WriteLine("2) Strong attack (60% chance to hit, full damage)");
            Console.WriteLine($"3) Use hability ({p1.Hability})");

            turnDone = false;
            while (turnDone == false)   //Repeat until the player makes a valid action
            {
                ValidateInt("Option: ", out option);

                if (option == 1 || option == 2)   //Attack
                {
                    RollDamage(p1.Attack, option == 2, rnd, out damage, out bool hit);// Checks if strong attack missed

                    if (hit == false)   //The strong attack missed
                    {
                        Console.WriteLine($"{p1.Name} missed the attack!");
                    }
                    else
                    {
                        if (p1Double == true)   //AGRESIVITY doubles this hit
                        {
                            damage = damage * 2;
                            p1Double = false;
                            Console.WriteLine("AGRESIVITY: double damage");
                        }

                        p2.Hp = p2.Hp - damage;// Deducts calculated damage from player 2's HP 
                        Console.WriteLine($"{p1.Name} attacks {p2.Name} with {damage}");
                    }
                    turnDone = true;
                }
                else if (option == 3)   //Hability: false if it was already used
                {
                    turnDone = UseHability(ref p1, ref p2, ref p1Double);
                }
                else   //Number outside 1-3
                {
                    Console.WriteLine("Invalid option (1-3)");
                }
            }
            turn = 2;   //Change turn
        }
        else   //Turn of player 2
        {
            Console.WriteLine();
            Console.WriteLine($"Turn of {p2.Name}  HP = {p2.Hp}/{p2.MaxHp}");
            Console.WriteLine("1) Weak attack   (always hits, half damage)");
            Console.WriteLine("2) Strong attack (60% chance to hit, full damage)");
            Console.WriteLine($"3) Use hability ({p2.Hability})");

            turnDone = false;
            while (turnDone == false)   //Repeat until the player makes a valid action
            {
                ValidateInt("Option: ", out option);

                if (option == 1 || option == 2)   //Attack
                {
                    RollDamage(p2.Attack, option == 2, rnd, out damage, out bool hit);

                    if (hit == false)   //The strong attack missed
                    {
                        Console.WriteLine($"{p2.Name} missed the attack!");
                    }
                    else
                    {
                        if (p2Double == true)   //AGRESIVITY doubles this hit
                        {
                            damage = damage * 2;
                            p2Double = false;
                            Console.WriteLine("AGRESIVITY: double damage");
                        }

                        p1.Hp = p1.Hp - damage;// Deducts calculated damage from player 1's HP 
                        Console.WriteLine($"{p2.Name} attacks {p1.Name} with {damage}");
                    }
                    turnDone = true;
                }
                else if (option == 3)   //Hability: false if it was already used
                {
                    turnDone = UseHability(ref p2, ref p1, ref p2Double);
                }
                else   //Number outside 1-3
                {
                    Console.WriteLine("Invalid option (1-3)");
                }
            }
            turn = 1;   // Switches turn back to player 1
        }

        //Life cannot be negative
        if (p1.Hp < 0) p1.Hp = 0;
        if (p2.Hp < 0) p2.Hp = 0;

        Console.WriteLine($"{p1.Name} {p1.Hp}/{p1.MaxHp} | {p2.Name} {p2.Hp}/{p2.MaxHp}");// Displays current health status
    }

    //Winner: the one still alive levels up
    Console.WriteLine();
    if (p1.Hp > 0)
    {
        Console.WriteLine($"{p1.Name} is the winner!");
        Console.WriteLine($"{p1.Catchphrase}");
        LevelUp(ref p1);
    }
    else
    {
        Console.WriteLine($"{p2.Name} is the winner!");
        Console.WriteLine($"{p2.Catchphrase}");
        LevelUp(ref p2);
    }
}

static bool UseHability(ref Character attacker, ref Character defender, ref bool doubleNext)   //ref: changes life of both
{
    if (attacker.HabilityUsed == true)   //Only once per fight
    {
        Console.WriteLine("Hability has been used this fight");
        return false;
    }

    if (attacker.Hability == "INVISIBILITY")   // Invisibility ability: heals 25 HP
    {
        attacker.Hp = attacker.Hp + 25;
        if (attacker.Hp > attacker.MaxHp) attacker.Hp = attacker.MaxHp;   //Not above max life
        Console.WriteLine($"{attacker.Name} recovers 25 HP");
    }
    else if (attacker.Hability == "AGRESIVITY")   //Next hit does double damage
    {
        doubleNext = true;
        Console.WriteLine($"{attacker.Name}'s next attack will be double");
    }
    else if (attacker.Hability == "SUPER VELOCITY")   //Two attacks in a row
    {
        defender.Hp = defender.Hp - attacker.Attack;// First attack hit 
        defender.Hp = defender.Hp - attacker.Attack;// Second attack hit
        Console.WriteLine($"{attacker.Name} double attack: {attacker.Attack * 2} damage");// Displays total damage dealt
    }
    else if (attacker.Hability == "LASER RAYS")   //35 direct damage
    {
        defender.Hp = defender.Hp - 35;// Direct damage deduction 
        Console.WriteLine($"{attacker.Name} LASER RAYS: 35 direct damage");
    }

    attacker.HabilityUsed = true;// Marks ability as used for the rest of the match
    return true;
}

static void RollDamage(int attack, bool strong, Random rnd, out int damage, out bool hit)   //out: two results at once
{
    if (strong)   //Strong attack: full damage, can miss
    {
        hit = rnd.Next(1, 101) <= 60;   //60% chance to hit
        if (hit)
        {
            damage = attack;
        }
        else
        {
            damage = 0;
        }
    }
    else   //Weak attack: half damage, always hits
    {
        hit = true;
        damage = attack / 2;
    }
}

static void ValidateInt(string message, out int result)   //Repeats the message until the user enters an integer
{
    Console.Write(message);
    while (!int.TryParse(Console.ReadLine(), out result))
    {
        Console.WriteLine("Invalid input. You must enter a whole number.");
        Console.Write(message);
    }
}

static void ChooseFighter(string message, out int index)   //out: returns the array position (0-7)
{
    ValidateInt(message, out int number);
    while (number < 1 || number > 8)   //Only characters 1 to 8
    {
        Console.WriteLine("Choose a number from 1 to 8.");
        ValidateInt(message, out number);
    }
    index = number - 1;   //The user writes 1-8, the array goes 0-7
}
static void LevelUp(ref Character winner)   //ref: the real character in the roster levels up
{
    winner.Wins++;
    winner.Level++;
    winner.MaxHp = winner.MaxHp + 10;
    winner.Attack = winner.Attack + 2;
    Console.WriteLine($"{winner.Name} is now level {winner.Level}! (+10 HP, +2 ATK)");
}


 static void DisplayMenu() // Shows the game menu
{
    Console.WriteLine();
    Console.WriteLine("WELCOME TO THE RPG GAME!!");
    Console.WriteLine();
    Console.WriteLine("=====================================");  //MENU DISPLAY
    Console.WriteLine("|  ATTACK OF THE COSTUME CHARACTERS |");  //MENU DISPLAY
    Console.WriteLine("|   1.Characters available          |");  //MENU DISPLAY
    Console.WriteLine("|   2.Choose fighters               |");  //MENU DISPLAY
    Console.WriteLine("|   3. Fight                        |");  //MENU DISPLAY
    Console.WriteLine("|   4. Stats/Ranking                |");  //MENU DISPLAY
    Console.WriteLine("|   5.Exit                          |"); //MENU DISPLAY
    Console.WriteLine("|   6.Intructions                   |"); //MENU DISPLAY
    Console.WriteLine("=====================================");  //MENU DISPLAY
    Console.WriteLine("Select an option (1-6): ");
}

struct  Character
{
    public string Name;        //Character display name
    public int Hp;             //Current health points during battle
    public int MaxHp;          //Maximum health capacity
    public int Attack;         //Base attack damage value
    public string Hability;    //Name of the character's special ability
    public int Level;          //Current character level progression
    public int Wins;           //Total number of matches won
    public bool HabilityUsed;  //Tracks if special ability was already triggered in the current fight
    public string Catchphrase; //Phrase spoken upon winning a match
}


//Aclaraciones importantes-
//Uso de la ia como apoyo para la realización y entendimiento de la función de fight 
//uso de la ia para la lluvia de ideas del esqueleto del proyecto
//El resto del código es propio y con marca registrada 
