public class Library
{
    public static bool playCardsV2(ref int[] playerDeck, int playerNum, ref int[] incompleteClean, ref int[] incompleteDirty, ref int[] dirtyMelds, ref int[] cleanMelds, ref int[] dirtyTwosCount, ref int[] dirtyJokersCount, ref bool openFoot)
    {
        int rankInt = 0;
        int cardsToPlayInt = 0;
        string numToPlayString = "";
        string handOrFoot = "Hand";
        while (true)
        {
            if (openFoot)
            {
                handOrFoot = "Foot";
            }
            Console.Write("Player: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(playerNum);
            Console.ResetColor();

            Console.WriteLine($"\t[{handOrFoot}]");
            PrintDeck(playerDeck, incompleteClean, incompleteDirty, dirtyMelds, cleanMelds);
            Console.WriteLine($"Score:\t{Library.CountCardScore(playerDeck)}\t{CountCardScore(incompleteClean)}\t\t\t{CountCardScore(incompleteDirty)}\t\t\t{SecondPointCount(cleanMelds, new int[14], dirtyJokersCount, dirtyTwosCount)}\t\t{SecondPointCount(new int[14], dirtyMelds, dirtyJokersCount, dirtyTwosCount)}");
            Console.WriteLine("Enter the number of which rank of cards (1-14) you would like to play (at least 3 needed to start meld), or enter \"0\" to finish your turn. Enter \"/scoring\" for card scoring.");
            string choice = Console.ReadLine();
            if (choice == "/scoring")
            {
                Console.WriteLine("Jokers (Wild Cards) - 50 points");
                Console.WriteLine("Deuces (Wild Cards) - 20 Points");
                Console.WriteLine("Aces - 20 Points");
                Console.WriteLine("Eights through Kings - 10 Points");
                Console.WriteLine("Fours through Sevens - 5 Points");
                Console.WriteLine("Clean meld - 500 Points");
                Console.WriteLine("Dirty meld - 300 Points");
                Console.WriteLine("Leftover cards in hand and foot will be subtracted from final score. Used wild cards give bonus points.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            bool canParse = int.TryParse(choice, out int choiceInt);
            if (canParse)
            {
                rankInt = int.Parse(choice) - 1;
            }
            while (!canParse || rankInt > 13 || rankInt < -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (choice != "/scoring")
                {
                    Console.WriteLine("Invalid input. Try again");
                }
                Console.ResetColor();
                Console.WriteLine("Enter the number of which rank of cards (1-14) you would like to play (at least 3 needed to start meld), or enter \"0\" to finish your turn. Enter \"/scoring\" for card scoring.");
                choice = Console.ReadLine();
                if (choice == "/scoring")
                {
                    Console.WriteLine("Jokers (Wild Cards) - 50 points");
                    Console.WriteLine("Deuces (Wild Cards) - 20 Points");
                    Console.WriteLine("Aces - 20 Points");
                    Console.WriteLine("Eights through Kings - 10 Points");
                    Console.WriteLine("Fours through Sevens - 5 Points");
                    Console.WriteLine("Clean meld - 500 Points");
                    Console.WriteLine("Dirty meld - 300 Points");
                    Console.WriteLine("Leftover cards in hand and foot will be subtracted from final score. Used wild cards give bonus points.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                canParse = int.TryParse(choice, out int c);
                if (canParse)
                {
                    rankInt = int.Parse(choice) - 1;
                }
            }
            if (rankInt < 0)
            {
                break;
            }
            Console.WriteLine("How many would you like to play?");
            numToPlayString = Console.ReadLine();
            canParse = int.TryParse(numToPlayString, out int a);
            if (canParse)
            {
                cardsToPlayInt = int.Parse(numToPlayString);
            }
            while (!canParse || cardsToPlayInt < 0 || cardsToPlayInt > playerDeck[rankInt])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Try again");

                Console.ResetColor();
                Console.WriteLine("How many would you like to play?");
                numToPlayString = Console.ReadLine();
                canParse = int.TryParse(numToPlayString, out int b);
                if (canParse)
                {
                    cardsToPlayInt = int.Parse(numToPlayString);
                }
            }
            int twosToAdd = 0;
            int jokersToAdd = 0;
            if (rankInt == 1)
            {
                playerDeck[1] -= cardsToPlayInt;
            }
            if (playerDeck[1] > 0)
            {
                Console.WriteLine($"Enter the number of 2s you would like to add (0-{playerDeck[1]})");
                canParse = int.TryParse(Console.ReadLine(), out int twos);
                twosToAdd = twos;
                while (!canParse || twosToAdd < 0 || twosToAdd > playerDeck[1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Try again.");
                    Console.ResetColor();
                    canParse = int.TryParse(Console.ReadLine(), out twos);
                    twosToAdd = twos;
                }
                playerDeck[1] -= twosToAdd;
                dirtyTwosCount[rankInt] += twosToAdd;
            }
            if (rankInt == 1)
            {
                playerDeck[1] += cardsToPlayInt;
            }
            if (rankInt == 13)
            {
                playerDeck[13] -= cardsToPlayInt;
            }
            if (playerDeck[13] > 0)
            {
                Console.WriteLine($"Enter the number of Jokers you would like to add (0-{playerDeck[13]})");
                canParse = int.TryParse(Console.ReadLine(), out int jokers);
                jokersToAdd = jokers;
                while (!canParse && jokersToAdd > -1 && jokersToAdd <= playerDeck[13])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Try again.");
                    Console.ResetColor();
                    canParse = int.TryParse(Console.ReadLine(), out jokers);
                    jokersToAdd = jokers;
                }
                playerDeck[13] -= jokersToAdd;
                dirtyJokersCount[rankInt] += jokersToAdd;
            }
            if (rankInt == 13)
            {
                playerDeck[13] += cardsToPlayInt;
            }

            string addToDirtyOrClean = "";
            playerDeck[rankInt] -= cardsToPlayInt;


            if (jokersToAdd != 0 && incompleteClean[rankInt] + incompleteDirty[rankInt] + cardsToPlayInt + jokersToAdd + twosToAdd >= 3 || twosToAdd != 0 && incompleteClean[rankInt] + incompleteDirty[rankInt] + cardsToPlayInt + jokersToAdd + twosToAdd >= 3)
            {
                incompleteDirty[rankInt] += cardsToPlayInt + jokersToAdd + twosToAdd + incompleteClean[rankInt];
                incompleteClean[rankInt] -= incompleteClean[rankInt];

            }
            else if (incompleteClean[rankInt] + incompleteDirty[rankInt] + cardsToPlayInt + jokersToAdd + twosToAdd < 3)
            {
                playerDeck[rankInt] += cardsToPlayInt;
                playerDeck[13] += jokersToAdd;
                playerDeck[1] += twosToAdd;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Unable to create meld");
                Console.ResetColor();
            }
            else if (incompleteDirty[rankInt] > 2 && cardsToPlayInt > 2 || incompleteClean[rankInt] > 2 && incompleteDirty[rankInt] > 2)
            {
                Console.WriteLine("Would you like to add cards to your clean or dirty meld? (\"dirty\"/\"clean\")");
                while (addToDirtyOrClean != "dirty" && addToDirtyOrClean != "clean")
                {
                    addToDirtyOrClean = Console.ReadLine();
                    if (addToDirtyOrClean != "dirty" && addToDirtyOrClean != "clean")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Try again.");
                        Console.ResetColor();
                    }
                }
                if (addToDirtyOrClean == "dirty")
                {
                    incompleteDirty[rankInt] += cardsToPlayInt;
                }
                else if (addToDirtyOrClean == "clean")
                {
                    incompleteClean[rankInt] += cardsToPlayInt;
                }
            }
            else if (incompleteClean[rankInt] < 3 && incompleteDirty[rankInt] > 2)
            {
                incompleteDirty[rankInt] += cardsToPlayInt;
            }
            else if (incompleteClean[rankInt] > 2)
            {
                incompleteClean[rankInt] += cardsToPlayInt;
            }
            else if (jokersToAdd == 0 && twosToAdd == 0 && cardsToPlayInt > 2)
            {
                incompleteClean[rankInt] += cardsToPlayInt;
            }
            else
            {
                playerDeck[rankInt] += cardsToPlayInt;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Unable to create meld");
                Console.ResetColor();
            }
            if (incompleteClean[rankInt] >= 7)
            {
                incompleteClean[rankInt] -= 7;
                cleanMelds[rankInt]++;
            }
            if (incompleteDirty[rankInt] >= 7)
            {
                incompleteDirty[rankInt] -= 7;
                dirtyMelds[rankInt]++;
                if (incompleteDirty[rankInt] > 0)
                {
                    incompleteClean[rankInt] += incompleteDirty[rankInt];
                    incompleteDirty[rankInt] = 0;
                }
            }
        }
        int totalCards = 0;
        for (int i = 0; i < 14; i++)
        {
            totalCards += playerDeck[i];
        }
        string selectedCard = "";
        if (totalCards != 0)
        {
            Console.WriteLine("Select a card (1-14) to discard");
            selectedCard = Console.ReadLine();
            while (!int.TryParse(selectedCard, out int a) || int.Parse(selectedCard) < 1 || playerDeck[int.Parse(selectedCard) - 1] < 1 || a > 14)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error, please try again");
                Console.ResetColor();
                Console.WriteLine("Select a card (1-14) to discard");
                selectedCard = Console.ReadLine();
            }
        }

        
        totalCards = 0;
        for (int i = 0; i < 14; i++)
        {
            totalCards += playerDeck[i];
        }
        if (totalCards != 0)
        {
            int selectedCardInt = int.Parse(selectedCard);
            playerDeck[selectedCardInt - 1]--;
        }
        totalCards = 0;
        for (int i = 0; i < 14; i++)
        {
            totalCards += playerDeck[i];
        }
        if (totalCards == 0 && !openFoot)
        {
            openFoot = true;
            playerDeck = CreateDeck();
        }
        for (int i = 0; i < 14; i++)
        {
            totalCards += playerDeck[i];
        }
        if (openFoot && totalCards == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int CalculateTotalPlayerScore(int[] playerDeck, int[] incompleteClean, int[] intcompleteDirty, int[] dirtyMelds, int[] cleanMelds, int[] dirtyTwosCount, int[] dirtyJokersCount, bool openFoot)
    {
        int totalScore = 0;
        int cleanMeldsNum = 0;
        int dirtyMeldsNum = 0;
        int twosNum = 0;
        int jokersNum = 0;
        for (int i = 0; i < 14; i++)
        {
            cleanMeldsNum += cleanMelds[i];
            dirtyMeldsNum += dirtyMelds[i];
            twosNum += dirtyJokersCount[i];
            jokersNum += dirtyJokersCount[i];
        }
        totalScore += cleanMeldsNum * 500;
        totalScore += dirtyMeldsNum * 300;
        totalScore += twosNum * 20;
        totalScore += jokersNum * 50;
        totalScore -= CountCardScore(playerDeck);
        totalScore -= CountCardScore(incompleteClean);
        totalScore -= CountCardScore(intcompleteDirty);
        if (!openFoot)
        {
            totalScore -= CountCardScore(CreateDeck());
        }
        return totalScore;
    }

    public static int CountMeldScore(int[] cleanMelds, int[] dirtyMelds)
    {
        int meldScore = 0;
        for (int i = 0; i < 14; i++)
        {
            meldScore += cleanMelds[i] * 500;
            meldScore += dirtyMelds[i] * 300;
        }
        return meldScore;
    }

    public static int SecondPointCount(int[] cleanMelds, int[] dirtyMelds, int[] dirtyJokerCount, int[] dirtyTwosCount)
    {
        int secondCount = 0;
        for (int i = 0; i < 14; i++)
        {
            if (i >= 0 && i < 3)
            {
                secondCount += cleanMelds[i] * 7 * 20;
                secondCount += (dirtyMelds[i] * 7 - dirtyJokerCount[i] - dirtyTwosCount[i]) * 20 + (dirtyJokerCount[i] * 50) + (dirtyTwosCount[i] * 20);
            }
            if (i > 2 && i < 8)
            {
                secondCount += cleanMelds[i] * 7 * 5;
                secondCount += (dirtyMelds[i] * 7 - dirtyJokerCount[i] - dirtyTwosCount[i]) * 5 + (dirtyJokerCount[i] * 50) + (dirtyTwosCount[i] * 20);
            }
            if (i > 7 && i < 13)
            {
                secondCount += cleanMelds[i] * 7 * 10;
                secondCount += (dirtyMelds[i] * 7 - dirtyJokerCount[i] - dirtyTwosCount[i]) * 10 + (dirtyJokerCount[i] * 50) + (dirtyTwosCount[i] * 20);
            }
            if (i == 14)
            {
                secondCount += cleanMelds[i] * 7 * 50;
                secondCount += (dirtyMelds[i] * 7 - dirtyJokerCount[i] - dirtyTwosCount[i]) * 50 + (dirtyJokerCount[i] * 50) + (dirtyTwosCount[i] * 20);
            }
        }
        return secondCount;
    }

    public static string[] GiveCardRanks()
    {
        string[] cardRank = File.ReadAllText("CardTypes.txt").Split(",");
        return cardRank;
    }
    public static string[] cardRanks = GiveCardRanks();
    public static int DrawCard()
    {
        int randomCardID = Random.Shared.Next(14);
        return randomCardID;
    }

    public static int[] CreateDeck()
    {
        int[] cardDeck = new int[14];
        for (int i = 0; i < 11; i++)
        {
            int cardDrawn = DrawCard();
            cardDeck[cardDrawn]++;
        }
        return cardDeck;
    }

    public static void DrawTwo(ref int[] cardDeck)
    {
        cardDeck[DrawCard()]++;
        cardDeck[DrawCard()]++;
    }

    public static void PrintDeck(int[] cardDeck, int[] incompleteClean, int[] incompleteDirty, int[] dirtyMelds, int[] cleanMelds)
    {
        Console.WriteLine($"\tDeck:\tIncomplete Clean:\tIncomplete Dirty\tClean Melds:\tDirty Melds:");
        for (int i = 0; i < cardDeck.Length; i++)
        {
            Console.WriteLine($"{cardRanks[i]}:\t{cardDeck[i]}\t{incompleteClean[i]}\t\t\t{incompleteDirty[i]}\t\t\t{cleanMelds[i]}\t\t{dirtyMelds[i]}");
        }
    }

    public static int CountCardScore(int[] cardDeck)
    {
        int score = 0;
        for (int i = 0; i < cardDeck.Length; i++)
        {
            for (int j = 0; j < cardDeck[i]; j++)
            {
                if (i == 0 || i == 1)
                {
                    score += 20;
                }
                if (i == 13)
                {
                    score += 50;
                }
                if (i >= 7 && i <= 12)
                {
                    score += 10;
                }
                if (i >= 2 && i <= 6)
                {
                    score += 5;
                }
            }
        }
        return score;
    }
    public static int GetRankNumber(string rankString)
    {
        switch (rankString)
        {
            case "Ace":
                return 0;
            case "2":
                return 1;
            case "3":
                return 2;
            case "4":
                return 3;
            case "5":
                return 4;
            case "6":
                return 5;
            case "7":
                return 6;
            case "8":
                return 7;
            case "9":
                return 8;
            case "10":
                return 9;
            case "Jack":
                return 10;
            case "King":
                return 11;
            case "Queen":
                return 12;
            case "Joker":
                return 13;
            default:
                return -1;
        }

    }
    public static string GetRankName(int rankNum)
    {
        switch (rankNum)
        {
            case 0:
                return "Ace";
            case 1:
                return "2";
            case 2:
                return "3";
            case 3:
                return "4";
            case 4:
                return "5";
            case 5:
                return "6";
            case 6:
                return "7";
            case 7:
                return "8";
            case 8:
                return "9";
            case 9:
                return "10";
            case 10:
                return "Jack";
            case 11:
                return "King";
            case 12:
                return "Queen";
            case 13:
                return "Joker";
            default:
                return "Error [GetRankName]";
        }

    }
    public static bool CanCreateMeld(int[] meld, int meldType)
    {
        if (meldType == 13 || meldType == 1)
        {
            if (meld[meldType] >= 3 && meld[meldType] <= 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (meld[meldType] + meld[13] + meld[1] >= 3 && meld[meldType] + meld[13] + meld[1] <= 7)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CanPlaceCards(List<int[]> melds, int roundNumber)
    {
        int cardScore = 0;
        for (int i = 0; i < melds.Count; i++)
        {
            cardScore += CountCardScore(melds[i]);
        }
        int firstRound = 0;
        if (roundNumber == 1)
        {
            firstRound = 10;
        }
        if (cardScore >= 30 * roundNumber + 30 - firstRound)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void playCards(ref int[] cardsToChange, int playerNum, ref int[] incompleteClean, ref int[] incompleteDirty, ref int[] dirtyMelds, ref int[] cleanMelds, bool startingPointsMet, int scoreToStartPlay)
    {
        int[] unstartedDeck = new int[14];
        int[] unstartedCleanMeld = new int[14];
        int[] unstartedDirtyMeld = new int[14];
        int[] unstartedWilds = new int[14];
        bool[] isDirty = new bool[14];
        while (true)
        {
            Console.Write("Player: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(playerNum);
            Console.ResetColor();
            Console.WriteLine("\t[HAND OR FOOT]");
            Library.PrintDeck(cardsToChange, incompleteClean, incompleteDirty, dirtyMelds, cleanMelds);
            Console.WriteLine($"Total deck score: {Library.CountCardScore(cardsToChange)}");
            Console.WriteLine("Enter the number of which rank of cards (1-14) you would like to play (at least 3 needed to start meld), or enter \"0\" to finish your turn. Enter \"/score\" for scoring.");
            string choice = Console.ReadLine();
            if (choice == "/scoring")
            {
                Console.WriteLine("Jokers (Wild Cards) - 50 points");
                Console.WriteLine("Deuces (Wild Cards) - 20 Points");
                Console.WriteLine("Aces - 20 Points");
                Console.WriteLine("Eights through Kings - 10 Points");
                Console.WriteLine("Fours through Sevens - 5 Points");
            }
            bool canParse = int.TryParse(choice, out int choiceInt);
            if (canParse)
            {
                if (choiceInt == 0)
                {
                    break;
                }
                bool useWild = false;
                string useWildString = "";
                while (useWildString != "yes" && useWildString != "Yes" && useWildString != "no" && useWildString != "No")
                {
                    Console.WriteLine("Would you like to add wild cards? (yes/no)");
                    useWildString = Console.ReadLine();
                    if (useWildString == "yes" || useWildString == "Yes")
                    {
                        useWild = true;
                    }
                    else if (useWildString == "no" || useWildString == "No")
                    {
                        useWild = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unable to parse. Please try again.");
                        Console.ResetColor();
                    }
                }
                int wildsToAddInt = 0;
                int wildCard = 0;
                if (useWild)
                {
                    Console.WriteLine("Enter \"1\" to use a 2, a \"2\" to use a Joker, or \"0\" to cancel");
                    string wildString = Console.ReadLine();
                    while (!int.TryParse(wildString, out int a) || (a != 0 && a != 1 && a != 2))
                    {
                        Console.WriteLine("Enter \"1\" to use a 2, a \"2\" to use a Joker, or \"0\" to cancel");
                        wildString = Console.ReadLine();
                    }
                    wildCard = int.Parse(wildString);
                    if (wildCard == 1)
                    {
                        wildCard = 1;
                    }
                    else if (wildCard == 2)
                    {
                        wildCard = 13;
                    }
                    if (wildCard != 0)
                    {
                        Console.WriteLine("How many would you like to add?");
                        string wildsToAdd = Console.ReadLine();
                        while (!int.TryParse(wildsToAdd, out int a) || a > cardsToChange[wildCard] || a < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a valid number: ");
                            Console.ResetColor();
                            wildsToAdd = Console.ReadLine();
                        }
                        wildsToAddInt = int.Parse(wildsToAdd);
                    }
                }
                if (cardsToChange[choiceInt - 1] + wildsToAddInt > 2 || incompleteClean[choiceInt - 1] > 2)
                {
                    Console.WriteLine($"How many {GetRankName(choiceInt - 1)}s would you like to play?"); //Fix melding after required starting score is met
                    string numberOfCardsToPlay = Console.ReadLine();
                    while (!int.TryParse(numberOfCardsToPlay, out int intNumberOfCardsToPlay) || int.Parse(numberOfCardsToPlay) < 0 || int.Parse(numberOfCardsToPlay) > cardsToChange[choiceInt - 1])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number: ");
                        Console.ResetColor();
                        numberOfCardsToPlay = Console.ReadLine();
                    }
                    if (startingPointsMet)
                    {
                        incompleteClean[choiceInt - 1] += int.Parse(numberOfCardsToPlay) + wildsToAddInt; //If starting points not met, add and then remove
                        cardsToChange[choiceInt - 1] -= int.Parse(numberOfCardsToPlay);
                        cardsToChange[wildCard] -= wildsToAddInt;
                    }
                    else
                    {
                        incompleteClean[choiceInt - 1] += int.Parse(numberOfCardsToPlay) + wildsToAddInt;
                        unstartedCleanMeld[choiceInt - 1] += int.Parse(numberOfCardsToPlay) + wildsToAddInt;
                        cardsToChange[choiceInt - 1] -= int.Parse(numberOfCardsToPlay);
                        unstartedDeck[choiceInt - 1] += int.Parse(numberOfCardsToPlay);
                        cardsToChange[wildCard] -= wildsToAddInt;
                        unstartedDeck[wildCard] += wildsToAddInt;
                        if (scoreToStartPlay > CountCardScore(unstartedCleanMeld) + CountCardScore(unstartedDirtyMeld))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine($"Required score to start play: {scoreToStartPlay}");
                        Console.WriteLine($"Current meld total: {CountCardScore(unstartedCleanMeld) + CountCardScore(unstartedDirtyMeld)}");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You do not have enough cards. Please try a different action.");
                    Console.ResetColor();
                }
            }
            else if (choice == "/help")
            {
                Console.WriteLine("Enter \"/rules\" for the rules, \"/scoring\" for the card scoring, or \"/melds\" to print your melds");
            }
            else if (choice == "/rules")
            {
                Console.WriteLine("[RULES NOT YET ADDED]");
            }
            else if (choice == "/scoring")
            {
                Console.WriteLine("Jokers (Wild Cards) - 50 points");
                Console.WriteLine("Deuces (Wild Cards) - 20 Points");
                Console.WriteLine("Aces - 20 Points");
                Console.WriteLine("Eights through Kings - 10 Points");
                Console.WriteLine("Fours through Sevens - 5 Points");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error. Please try again.");
                Console.ResetColor();
            }
        }
        Console.WriteLine("Select a card (1-14) to discard");
        string selectedCard = Console.ReadLine();
        while (!int.TryParse(selectedCard, out int selectedCardInt) || int.Parse(selectedCard) < 1 || cardsToChange[int.Parse(selectedCard) - 1] < 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error, please try again");
            Console.ResetColor();
            Console.WriteLine("Select a card (1-14) to discard");
            selectedCard = Console.ReadLine();
        }
        if (CountCardScore(unstartedCleanMeld) + CountCardScore(unstartedDirtyMeld) > scoreToStartPlay)
        {
            startingPointsMet = true;
        }
        if (!startingPointsMet)
        {
            for (int i = 0; i < cardsToChange.Length; i++)
            {
                incompleteClean[i] -= unstartedCleanMeld[i];
                cardsToChange[i] += unstartedDeck[i];
            }
        }

        cardsToChange[int.Parse(selectedCard) - 1]--;
    }
}
