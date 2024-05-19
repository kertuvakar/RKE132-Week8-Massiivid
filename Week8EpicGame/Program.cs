

string folderPath = @"C:\Users\Kasutaja\Desktop\Õppematerjalid\2. kursus 2. semester kevad\Programmeerimise algkursus\8. nädal\data\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";
string weaponsFile = "weapons.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapons = File.ReadAllLines(Path.Combine(folderPath, weaponsFile));


//string[] heroes = { "Harry Potter", "Luke Skywalker", "Lara Croft", "Scooby-Doo" };
//string[] villains = { "Voldemort", "Darth Vade", "Dracula", "Joker", "Sauron" };//massiiv kurjategijad
//string[] weapons = { "magic wand", "sword", "stick", "banana", "pan" };


string hero = GetRandomValueFromArray(heroes);//Ma olen välja kutsunud GetRandom funktsiooni ja pakkusin talle heroes massiivi
string heroWeapon = GetRandomValueFromArray(weapons);
int heroHP = GetHitPoints(hero);
int heroStrikeStrength = heroHP;//siin peab heroHP salvestama, et valtida hilisemaid negatiivseid väärtusi
Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroWeapon} saves the day!");

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapons);
int villainHP = GetHitPoints(villain);
int hvillainStrikeStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainWeapon} tries to take over the world!");


static string GetRandomValueFromArray(string[] someArray) //ehitan uue funktsiooni, pakun argumendina massiivi

{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex]; //seda stringi peab vahemälusse tagastama
    return randomStringFromArray; //pean sone vahemälusse tagastama
}//Kui see funktsioon lõpetab, siis jääb vahemälusse ainult lõppväärtus, millega funktsioon peab hakkama saama
//Kõik, mida deklareeritakse jääb kõik ploki sisse. 


while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainHP);
    villainHP = villainHP - Hit(hero, heroHP);
}

Console.WriteLine($"Hero{hero} HP: {heroHP} ");
Console.WriteLine($"Villain{villain} HP: {villainHP} ");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day");
}
else if (villainHP > 0)
{
    Console.WriteLine("Dark ide wins!");
}


static int GetHitPoints(string characterName) //ehitan uue funktsiooni, pakun argumendina massiivi
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
    return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike= rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
       
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit");
    }
    else 
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;  


}