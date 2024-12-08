//Eric Weston - Final Project - Hand and Foot Card Game

//To do: 

//Create decks
using System.Security.Principal;
using System.Xml.Serialization;

Console.Clear();
List<int[]> playerDecks = new List<int[]>();
List<int[]> incompleteCleanMelds = new List<int[]>();
List<int[]> incompleteDirtyMelds = new List<int[]>();
List<int[]> playerDirtyMelds = new List<int[]>();
List<int[]> playerCleanMelds = new List<int[]>();
List<int[]> playerDirtyTwosCount = new List<int[]>();
List<int[]> playerDirtyJokersCount = new List<int[]>();
List<bool> openFoot = new List<bool>();

int[] dirtyTwosCount = new int[14];
int[] dirtyJokersCount = new int[14];
char cardInit = 'a';
for (int i = 0; i < 14; i++)
{
    incompleteCleanMelds.Add(new int[14]);
}
Console.WriteLine("Enter the number of players: ");
string playerNumString = Console.ReadLine();
while (!int.TryParse(playerNumString, out int number))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Unable to parse, please enter a valid number: ");
    playerNumString = Console.ReadLine();
    Console.ResetColor();
}
int playerNum = int.Parse(playerNumString);
int[] playerScores = new int[playerNum - 1];
bool[] canStartRound = new bool[playerNum];
for (int i = 0; i < playerNum; i++)
{
    playerDecks.Add(Library.CreateDeck());
    incompleteCleanMelds.Add(new int[14]);
    incompleteDirtyMelds.Add(new int[14]);
    playerDirtyMelds.Add(new int[14]);
    playerCleanMelds.Add(new int[14]);
    playerDirtyTwosCount.Add(new int[14]);
    playerDirtyJokersCount.Add(new int[14]);
    openFoot.Add(false);
}
int playerTurn = 0;
//Begin play

while (true)
{
    Console.Clear();
    playerTurn++;
    int[] playerDeck = playerDecks[playerTurn - 1];
    int[] incompleteClean = incompleteCleanMelds[playerTurn - 1];
    int[] incompleteDirty = incompleteDirtyMelds[playerTurn - 1];
    int[] playerDirty = playerDirtyMelds[playerTurn - 1];
    int[] playerClean = playerCleanMelds[playerTurn - 1];
    int[] playerWildJokers = playerDirtyJokersCount[playerTurn - 1];
    int[] playerWildTwos = playerDirtyTwosCount[playerTurn - 1];
    bool openFeet = openFoot[playerTurn - 1];
    string handOrFoot = "Hand";
    Library.DrawTwo(ref playerDeck);

    Console.ResetColor();
    if (Library.playCardsV2(ref playerDeck, playerTurn, ref incompleteClean, ref incompleteDirty, ref playerDirty, ref playerClean, ref playerWildTwos, ref playerWildJokers, ref openFeet))
    {
        break;
    }
    playerDecks[playerTurn - 1] = playerDeck;
    incompleteCleanMelds[playerTurn - 1] = incompleteClean;
    incompleteDirtyMelds[playerTurn - 1] = incompleteDirty;
    playerDirtyMelds[playerTurn - 1] = playerDirty;
    playerCleanMelds[playerTurn - 1] = playerClean;
    playerDirtyJokersCount[playerTurn - 1] = playerWildJokers;
    playerDirtyTwosCount[playerTurn - 1] = playerWildTwos;
    openFoot[playerTurn - 1] = openFeet;

    Console.Write("Player: ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(playerTurn);
    Console.ResetColor();

    if (openFoot[playerTurn - 1])
    {
        handOrFoot = "Foot";
    }
    Console.WriteLine($"\t[{handOrFoot}]");
    Library.PrintDeck(playerDeck, incompleteClean, incompleteDirty, playerDirty, playerClean);
    Console.WriteLine($"Score:\t{Library.CountCardScore(playerDeck)}\t{Library.CountCardScore(incompleteClean)}\t\t\t{Library.CountCardScore(incompleteDirty)}\t\t\t{Library.SecondPointCount(playerCleanMelds[playerTurn - 1], new int[14], dirtyJokersCount, dirtyTwosCount)}\t\t{Library.SecondPointCount(new int[14], playerDirtyMelds[playerTurn - 1], dirtyJokersCount, dirtyTwosCount)}");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();

    if (playerTurn == playerNum)
    {
        playerTurn = 0;
    }
}
int winner = 0;
int score = 0;
int winnerNum = 0;
double average = 0;
Dictionary<char, int> playerDictionary = new Dictionary<char, int>(playerNum);
for (int i = 0; i < playerNum; i++)
{
    score = Library.CalculateTotalPlayerScore(playerDecks[i], incompleteCleanMelds[i], incompleteDirtyMelds[i], playerDirtyMelds[i], playerCleanMelds[i], playerDirtyTwosCount[i], playerDirtyJokersCount[i], openFoot[i]);
    score += Library.SecondPointCount(playerCleanMelds[i], playerDirtyMelds[i], playerDirtyJokersCount[i], playerDirtyTwosCount[i]);
    Console.WriteLine($"Player {i + 1} Score: {score}");
    if (score > winner)
    {
        winner = score;
        winnerNum = i + 1;
    }
    average += score;
    playerDictionary.Add((char)i, score);

}
Console.WriteLine();
Console.WriteLine($"Game Over! Player {winnerNum} wins!");
Console.WriteLine($"The average score was: {average / playerNum}");
string playerID = "";
char playerIDChar = '0';
while (true)
{
    Console.WriteLine("Enter player number to see their score: ");
    playerID = Console.ReadLine();
    playerIDChar = '0';
    while (char.TryParse(playerID, out char a))
    {
        if (char.TryParse(playerID, out a))
        {
            playerIDChar = a;
        }
    }
    Console.WriteLine($"Player {(int)playerIDChar + 1} score: {playerDictionary[playerIDChar]}");
}