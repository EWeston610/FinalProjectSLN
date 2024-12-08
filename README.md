My plan for my project is to make a program that allows you to play the card game "Hand and Foot" against other players. 
To do this I will need to be able to make a program that will draw cards and put them into a deck for each player, allow the user to draw or place cards into piles (melds).
The program should calculate the scores automatically, and not permit the users to perform illegal moves. 
I will use files to store the cards.
I will use methods to sort the cards.
I will use arrays for the scores and for storing cards.
I will use conditionals in the sorting methods. (for loops and while loops)
I will use a list for storing piles of cards for ALL players;
I will use a dictionary to let the players look up their individual scores at the end of the game.
I will create an algorithm for sorting cards and scoring.
I will use a variety of data types for cards and in the methods that I use to distribute the cards; (ints for card numbers, strings for card names, doubles for finding averages at the end of the game, bools for telling the player if they are in their hand or foot deck, char for dictionary key).

Check point #2: The main currently creates a random deck of 11 cards, prints it out, and calculates the number of points all those cards are worth.

Report:
This program allows you play the playing card game Hand and Foot. I wanted to do this because I couldn't think of something practical, and it seemed challenging enough to make a good final project. 

Files: 
1. I used files to store the names of each rank of card. 
2. I considered just adding all the names to an array instead.
3. I chose to use files instead because I needed to use files somewhere in this project.

Methods: 
1. I used recursive methods in the PlayCard method, and in methods involved in calculating scoring, as well as in several methods that I didn't end up using because I forgot why I made them.
2. In scoring, for example, I could have just calculated it all in one longer method, 
3. but dividing it up made it easier to understand the calculations.

Arrays:
1. I used a lot of arrays, mostly to sort cards into piles while keeping track of what rank of card it is.
2. I considered using dictionaries for this instead, 
3. but I figured that as long as I kept track of their position that using a simple array would be easier.

Loops:
1. I used lots of loops. For example I used while loops to catch parsing errors when collecting user input, and for loops for writing out the arrays.
2. I could have used do while loops in several spots (and probably should have), and for for loops I could have written a big long interpolated string when printing.
3. But I couldn't remember how to do do-while loops and my regular while loops were working just fine, and writing a long string like that would have been impractical.

Ternary operators:
1. I used these when figuring out which deck the player is in (hand or foot)
2. I could have just had the hand deck switch to the foot deck after the hand deck reached zero, 
3. but using ternary operators made it simpler to keep track of, and made it easier for printing. 

if/else:
1. I used if/else when determining what to do with user input.
2. I could have decided to only use switch statements,
3. but if/else was simpler.

Switch statements:
1. I used switch statements when converting between card rank names and their position on the array.
2. I could have use if/else statements,
3. but it was easier to use switches for long lists.

Algorithms:
1. I made an algorithm for figuring out where to put which cards in which situations, and when to ask the player rather than doing it automatically, and also for calculating scoring.
2. Alternatively I could have asked the player each and every time and had them calculate their own score, 
3. but that would have been a pain and also make the program pointless.

Lists:
1. I used lists to store arrays so that the user can choose how many players can join.
2. I could have used a 2D array,
3. but then the number of players would not be able to grow.

Dictionary:
1. I used dictionary to allow each player to look up their score at the end of the game.
2. This is pointless because I could have just printed it out anyway,
3. but I was required to use another collection type for this project.

Ints:
1. I used ints for storing scores.
2. I could have converted to a string before storing instead, 
3. but that would just be me intentionally making my life more difficult.

Doubles:
1. I used doubles to calculate the average player score at the end of the game.
2. Alternatively I could have not done this at all,
3. But I needed to use doubles at least once in my project.

Bools:
1. I used bools in a list to keep track of which deck each player is in.
2. I could have used conditionals with ints (0-1),
3. but bools are more intuitive.

Strings:
1. I used strings to write to console and keep track of rank types.
2. Alternatively, I could have used an array of chars,
3. but I do not have mental illness.

Chars:
1. I used chars in my dicionary as a key for the values of each players score at the end of the game.
2. Alteratively I could have used literally any other data type,
3. But I was required to use another primative type somewhere in this project.

