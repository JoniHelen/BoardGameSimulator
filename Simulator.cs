using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameSimulator
{
    public class Simulator
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player> { new Player(Role.Programmer), new Player(Role.Analyst), new Player(Role.Artist), new Player(Role.Designer) };
            
            List<Player> others = new List<Player>();
            
            Random rand = new Random();
            
            GameBoard gameBoard = new GameBoard();
            
            GameBoard.initCards(gameBoard);

            int dice;
            int finish = 0;
            int[] finishes = new int[1000];

            // play 1000 Games
            for (int i = 0; i < 1000; i++)
            {
                // Clean slate
                foreach (Player p in players)
                {
                    p.TurnsPlayed = 0;
                    p.Points = 0;
                    p.Projects = 0;
                    p.Engineer = false;
                    p.PointsPerRoundThisGame = 0;
                    p.HeldCards = new List<Card>();
                    p.turnBlocked = false;
                    p.Rolls = 0;
                }
                finish = 0;
                
                // Turn limit
                for (int j = 0; j < 12; j++)
                {
                    // Each player's turn
                    for (int index = 0; index < players.Count; index++)
                    {
                        foreach (Player p in players)
                        {
                            if (p.Points >= 240 && !p.Engineer)
                            {
                                p.Points = 240;
                                p.Engineer = true;
                            }

                            if (p.Engineer && p.Points < 240)
                            {
                                p.Engineer = false;
                            }
                        }

                        others = players.Where(x => x.Role != players[index].Role).ToList();

                        players[index].TurnsPlayed++;

                        if (players[index].turnBlocked)
                        {
                            players[index].turnBlocked = false;
                        }
                        else
                        {
                            players[index].Rolls++;

                            while (players[index].Rolls > 0)
                            {
                                foreach (Player p in players)
                                {
                                    if (p.Points >= 240 && !p.Engineer)
                                    {
                                        p.Points = 240;
                                        p.Engineer = true;
                                    }

                                    if (p.Engineer && p.Points < 240)
                                    {
                                        p.Engineer = false;
                                    }
                                }

                                // Throw dice
                                dice = rand.Next(1, 6);
                                players[index].Rolls--;

                                if (players[index].HeldCards.Any(x => x.Effect == Card.MandatorySwedish))
                                {
                                    if (dice == 6)
                                    {
                                        players[index].HeldCards.RemoveAll(x => x.Effect == Card.MandatorySwedish);
                                        gameBoard.Events.Add(new Card(Role.Programmer, Card.MandatorySwedish));
                                    }
                                }

                                // Move
                                players[index].Position += dice;

                                if (players[index].Position > GameBoard.Board.Length - 1)
                                {
                                    players[index].Position -= GameBoard.Board.Length - 1;
                                }

                                // Check landed tile
                                if (GameBoard.Board[players[index].Position] == Tile.Project)
                                {
                                    players[index].Projects++;

                                    dice = rand.Next(gameBoard.Projects.Count - 1);

                                    if (players[index].HeldCards.Exists(x => x.Effect == Card.GreatSuccess))
                                    {
                                        gameBoard.Events.Add(new Card(Role.Programmer, Card.GreatSuccess));
                                    }

                                    if (players[index].Engineer)
                                    {
                                        if (players.FindIndex(x => x.Role == gameBoard.Projects[dice].Role && !x.Engineer) != -1)
                                        {
                                            gameBoard.Projects[dice].Effect(gameBoard.Projects[dice].Role, players[index], others[others.FindIndex(x => x.Role == gameBoard.Projects[dice].Role && !x.Engineer)]);
                                        }
                                        else
                                        {
                                            gameBoard.Projects[dice].Effect(gameBoard.Projects[dice].Role, players[index], others.MinBy(x => x.Points));
                                        }
                                    }
                                    else
                                    {
                                        if (gameBoard.Projects[dice].Role == players[index].Role)
                                        {
                                            gameBoard.Projects[dice].Effect(gameBoard.Projects[dice].Role, players[index], others.MinBy(x => x.Points));
                                        }
                                        else
                                        {
                                            gameBoard.Projects[dice].Effect(gameBoard.Projects[dice].Role, players[index], others[others.FindIndex(x => x.Role == gameBoard.Projects[dice].Role)]);
                                        }
                                    }
                                }

                                if (GameBoard.Board[players[index].Position] == Tile.Event)
                                {
                                    dice = rand.Next(gameBoard.Events.Count - 1);

                                    if (gameBoard.Events[dice].Effect == Card.NetworkingEvent)
                                    {
                                        bool found = false;
                                        Player holder = new Player(Role.Programmer);
                                        foreach (Player player in players)
                                        {
                                            if (player.HeldCards.Any(x => x.Effect == Card.DivineIntervention))
                                            {
                                                holder = player;
                                                found = true;
                                                break;
                                            }
                                        }

                                        if (found)
                                        {
                                            holder.HeldCards.Remove(holder.HeldCards.Find(x => x.Effect == Card.DivineIntervention));
                                            gameBoard.Events.Add(new Card(Role.Programmer, Card.DivineIntervention));
                                        }
                                        else
                                        {
                                            gameBoard.Events[dice].Effect(gameBoard.Events[dice].Role, players[index], others.MaxBy(x => x.Points));
                                        }
                                    }
                                    else if (gameBoard.Events[dice].Effect == Card.Sabotage)
                                    {
                                        bool found = false;
                                        Player holder = new Player(Role.Programmer);
                                        foreach(Player player in players)
                                        {
                                            if (player.HeldCards.Any(x => x.Effect == Card.DivineIntervention))
                                            {
                                                holder = player;
                                                found = true;
                                                break;
                                            }
                                        }

                                        if (found)
                                        {
                                            holder.HeldCards.Remove(holder.HeldCards.Find(x => x.Effect == Card.DivineIntervention));
                                            gameBoard.Events.Add(new Card(Role.Programmer, Card.DivineIntervention));
                                        }
                                        else
                                        {
                                            gameBoard.Events[dice].Effect(gameBoard.Events[dice].Role, players[index], others.MaxBy(x => x.Points));
                                        }
                                    }
                                    else if (gameBoard.Events[dice].Effect == Card.Plagiarism)
                                    {
                                        bool found = false;
                                        Player holder = new Player(Role.Programmer);
                                        foreach (Player player in players)
                                        {
                                            if (player.HeldCards.Any(x => x.Effect == Card.DivineIntervention))
                                            {
                                                holder = player;
                                                found = true;
                                                break;
                                            }
                                        }

                                        if (found)
                                        {
                                            holder.HeldCards.Remove(holder.HeldCards.Find(x => x.Effect == Card.DivineIntervention));
                                            gameBoard.Events.Add(new Card(Role.Programmer, Card.DivineIntervention));
                                        }
                                        else
                                        {
                                            gameBoard.Events[dice].Effect(gameBoard.Events[dice].Role, players[index], players[index]);
                                        }
                                    }
                                    else if (gameBoard.Events[dice].Effect == Card.AmbitiousProject)
                                    {
                                        gameBoard.Events[dice].Effect(gameBoard.Events[dice].Role, players[index], others.MinBy(x => x.Points));
                                    }
                                    else if (gameBoard.Events[dice].Effect == Card.HelpAFriend)
                                    {
                                        gameBoard.Events[dice].Effect(gameBoard.Events[dice].Role, players[index], others.MinBy(x => x.Points));
                                    }
                                    else if (gameBoard.Events[dice].Effect == Card.TeamChemistry)
                                    {
                                        gameBoard.Events[dice].Effect(gameBoard.Events[dice].Role, players[index], others.MinBy(x => x.Points));
                                    }
                                    else if (gameBoard.Events[dice].Effect == Card.GreatSuccess)
                                    {
                                        gameBoard.Events[dice].Effect(gameBoard.Events[dice].Role, players[index], players[index]);
                                        gameBoard.Events.Remove(gameBoard.Events[dice]);
                                    }
                                    else if (gameBoard.Events[dice].Effect == Card.DivineIntervention)
                                    {
                                        gameBoard.Events[dice].Effect(gameBoard.Events[dice].Role, players[index], players[index]);
                                        gameBoard.Events.Remove(gameBoard.Events[dice]);
                                    }
                                    else if (gameBoard.Events[dice].Effect == Card.MandatorySwedish)
                                    {
                                        if (players[index].TurnsPlayed < 7)
                                        {
                                            gameBoard.Events.Remove(gameBoard.Events[dice]);
                                        }
                                        gameBoard.Events[dice].Effect(gameBoard.Events[dice].Role, players[index], players[index]);

                                    }
                                    else
                                    {
                                        gameBoard.Events[dice].Effect(gameBoard.Events[dice].Role, players[index], players[index]);
                                    }
                                }

                                // If enough points to be an engineer
                                if (players[index].Points >= 240 && !players[index].Engineer)
                                {
                                    players[index].Points = 240;
                                    players[index].Engineer = true;
                                }

                                if (players.All(x => x.Engineer) && players.All(x => !x.HeldCards.Any(y => y.Effect == Card.MandatorySwedish)))
                                {
                                    finish = 4;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (finish != 4)
                {
                    finish = players.Count(x => x.Engineer && !x.HeldCards.Any(x => x.Effect == Card.MandatorySwedish));
                }

                finishes[i] = finish;
                
                foreach(Player player in players)
                {
                    player.projectsPerGame[i] = player.Projects;
                    player.pointsPerGame[i] = player.Points;
                    player.turnsPerGame[i] = player.TurnsPlayed;
                    player.pointsPerRoundPerGame[i] = player.PointsPerRoundThisGame /= 12;
                }
            }

            foreach (Player player in players)
            {
                foreach (int i in player.projectsPerGame)
                {
                    player.avgProjects += i;
                }
                player.avgProjects /= 1000;

                foreach (int i in player.pointsPerGame)
                {
                    player.avgPoints += i;
                }
                player.avgPoints /= 1000;

                foreach (int i in player.turnsPerGame)
                {
                    player.avgTurns += i;
                }
                player.avgTurns /= 1000;

                foreach (float f in player.pointsPerRoundPerGame)
                {
                    player.avgPointsPerRound += f;
                }
                player.avgPointsPerRound /= 1000;
            }

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine("\nPlayer: " + (i + 1) + "\nAverage projects: " + players[i].avgProjects + " \nAverage turns: " + players[i].avgTurns + " \nAverage points: " + players[i].avgPoints + " \nAverage points per round: " + players[i].avgPointsPerRound);
                /*
                for (int j = 0; j < 100; j++)
                {
                    Console.WriteLine("Game: " + (i + 1) + " Projects: " + players[i].projectsPerGame[j] + " Points: " + players[i].pointsPerGame[j] + " Turns: " + players[i].turnsPerGame[j]);
                }*/
            }

            Console.WriteLine("\nNumber of games finished by losing: " + finishes.Count(x => x == 0) 
                + "\nNumber of games finished with 1 engineer: " + finishes.Count(x => x == 1)
                + "\nNumber of games finished with 2 engineers: " + finishes.Count(x => x == 2)
                + "\nNumber of games finished with 3 engineers: " + finishes.Count(x => x == 3)
                + "\nNumber of games finished with 4 engineers: " + finishes.Count(x => x == 4));

            Console.WriteLine("\nWin percentages: \n1 engineer: " + finishes.Count(x => x == 1) / 1000f * 100f + " %"
                + "\n2 engineers: " + finishes.Count(x => x == 2) / 1000f * 100f + " %"
                + "\n3 engineers: " + finishes.Count(x => x == 3) / 1000f * 100f + " %"
                + "\n4 engineers: " + finishes.Count(x => x == 4) / 1000f * 100f + " %");

            Console.Read();
        }
    }

    public enum Role
    {
        Programmer,
        Designer,
        Analyst,
        Artist
    }

    public enum Tile
    {
        Empty,
        Project,
        Event
    }
}
