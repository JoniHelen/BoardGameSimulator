using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameSimulator
{
    class Card
    {
        public Role Role;
        public Action<Role, Player, Player> Effect;

        public Card(Role role, Action<Role, Player, Player> effect)
        {
            Role = role;
            Effect = effect;
        }
        public static void normalProject(Role cardRole, Player invoker, Player affected)
        {
            if (invoker.HeldCards.Exists(x => x.Effect == Card.GreatSuccess))
            {
                if (cardRole == invoker.Role || (cardRole != invoker.Role && cardRole != affected.Role))
                {
                    if (!invoker.Engineer)
                    {
                        invoker.Points += 60;
                    }

                    if (!affected.Engineer)
                    {
                        affected.Points += 60;
                    }

                    invoker.PointsPerRoundThisGame += 60;
                    affected.PointsPerRoundThisGame += 60;
                }
                else
                {
                    if (!invoker.Engineer)
                    {
                        invoker.Points += 70;
                    }

                    if (!affected.Engineer)
                    {
                        affected.Points += 70;
                    }

                    invoker.PointsPerRoundThisGame += 70;
                    affected.PointsPerRoundThisGame += 70;
                }
                invoker.HeldCards.RemoveAll(x => x.Effect == Card.GreatSuccess);
            }
            else
            {
                if (cardRole == invoker.Role || (cardRole != invoker.Role && cardRole != affected.Role))
                {
                    if (!invoker.Engineer)
                    {
                        invoker.Points += 30;

                    }

                    if (!affected.Engineer)
                    {
                        affected.Points += 30;

                    }

                    invoker.PointsPerRoundThisGame += 30;
                    affected.PointsPerRoundThisGame += 30;
                }
                else
                {
                    if (!invoker.Engineer)
                    {
                        invoker.Points += 40;

                    }

                    if (!affected.Engineer)
                    {
                        affected.Points += 40;

                    }

                    invoker.PointsPerRoundThisGame += 40;
                    affected.PointsPerRoundThisGame += 40;
                }
            }
            
        }

        public static void specialProject(Role cardRole, Player invoker, Player affected)
        {
            if (invoker.HeldCards.Exists(x => x.Effect == Card.GreatSuccess))
            {
                if (cardRole == invoker.Role || (cardRole != invoker.Role && cardRole != affected.Role))
                {
                    if (!invoker.Engineer)
                    {
                        invoker.Points += 70;
                    }

                    if (!affected.Engineer)
                    {
                        affected.Points += 70;
                    }

                    invoker.PointsPerRoundThisGame += 70;
                    affected.PointsPerRoundThisGame += 70;
                }
                else
                {
                    if (!invoker.Engineer)
                    {
                        invoker.Points += 90;
                    }

                    if (!affected.Engineer)
                    {
                        affected.Points += 90;
                    }

                    invoker.PointsPerRoundThisGame += 90;
                    affected.PointsPerRoundThisGame += 90;
                }
                invoker.HeldCards.RemoveAll(x => x.Effect == Card.GreatSuccess);
            }
            else
            {
                if (cardRole == invoker.Role || (cardRole != invoker.Role && cardRole != affected.Role))
                {
                    if (!invoker.Engineer)
                    {
                        invoker.Points += 40;

                    }

                    if (!affected.Engineer)
                    {
                        affected.Points += 40;

                    }

                    invoker.PointsPerRoundThisGame += 40;
                    affected.PointsPerRoundThisGame += 40;
                }
                else
                {
                    if (!invoker.Engineer)
                    {
                        invoker.Points += 60;

                    }

                    if (!affected.Engineer)
                    {
                        affected.Points += 60;

                    }

                    invoker.PointsPerRoundThisGame += 60;
                    affected.PointsPerRoundThisGame += 60;
                }
            }
        }

        public static void Hangover(Role cardRole, Player invoker, Player affected)
        {
            invoker.turnBlocked = true;
        }

        public static void GreatSuccess(Role cardRole, Player invoker, Player affected)
        {
            invoker.HeldCards.Add(new Card(cardRole, Card.GreatSuccess));
        }

        public static void Accreditation(Role cardRole, Player invoker, Player affected)
        {
            if (invoker.TurnsPlayed < 5)
            {
                if (!invoker.Engineer)
                    invoker.Points += 20;

                invoker.PointsPerRoundThisGame += 20;
            }
            else
            {
                invoker.turnBlocked = true;
            }
        }

        public static void FailedCourse(Role cardRole, Player invoker, Player affected)
        {
                invoker.Points -= 20;
            invoker.PointsPerRoundThisGame -= 20;
        }

        public static void MandatorySwedish(Role cardRole, Player invoker, Player affected)
        {
            //SCRAPPED
            invoker.HeldCards.Add(new Card(cardRole, Card.MandatorySwedish));
        }

        public static void DivineIntervention(Role cardRole, Player invoker, Player affected)
        {
            invoker.HeldCards.Add(new Card(cardRole, Card.DivineIntervention));
        }

        public static void GameTesting(Role cardRole, Player invoker, Player affected)
        {
            if (!invoker.Engineer)
                invoker.Points += 20;

            invoker.PointsPerRoundThisGame += 20;
        }

        public static void PrepCourse(Role cardRole, Player invoker, Player affected)
        {
            if (invoker.TurnsPlayed < 5)
            {
                invoker.turnBlocked = true;
            } 
            else
            {
                if (!invoker.Engineer)
                    invoker.Points += 20;

                invoker.PointsPerRoundThisGame += 20;
            }
        }

        public static void Plagiarism(Role cardRole, Player invoker, Player affected)
        {
            invoker.Points /= 2;
        }

        public static void HelpAFriend(Role cardRole, Player invoker, Player affected)
        {
            invoker.Points -= 30;
            invoker.PointsPerRoundThisGame -= 30;

            if (!affected.Engineer)
                affected.Points += 30;

            affected.PointsPerRoundThisGame += 30;
        }

        public static void SuddenAssignment(Role cardRole, Player invoker, Player affected)
        {
            invoker.Position = (GameBoard.Board.Length - 1 != invoker.Position) ? Array.FindIndex(GameBoard.Board, invoker.Position, x => x == Tile.Project) : Array.FindIndex(GameBoard.Board, 0, x => x == Tile.Project);
        }

        public static void AmbitiousProject(Role cardRole, Player invoker, Player affected)
        {
            Random rand = new Random();
            int dice = rand.Next(1, 6);

            if (dice <= 3)
            {
                affected.Points -= 30;
                affected.PointsPerRoundThisGame -= 30;
            }
            else
            {
                if (!affected.Engineer)
                    affected.Points += 30;

                affected.PointsPerRoundThisGame += 30;
            }
        }

        public static void Sabotage(Role cardRole, Player invoker, Player affected)
        {
            affected.turnBlocked = true;
        }

        public static void NetworkingEvent(Role cardRole, Player invoker, Player affected)
        {
            invoker.turnBlocked = true;
            affected.turnBlocked = true;
        }

        public static void TeamChemistry(Role cardRole, Player invoker, Player affected)
        {
            invoker.Rolls++;
            affected.Rolls++;
        }

        public static void WellRested(Role cardRole, Player invoker, Player affected)
        {
            invoker.Rolls++;
        }
    }
}
