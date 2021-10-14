using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameSimulator
{
    class GameBoard
    {
        public static readonly Tile[] Board = new Tile[] { 
            Tile.Empty, Tile.Empty, Tile.Empty, Tile.Event, Tile.Empty, Tile.Empty, Tile.Event, Tile.Empty, Tile.Empty, Tile.Project,
            Tile.Empty, Tile.Empty, Tile.Event, Tile.Project, Tile.Empty, Tile.Event, Tile.Empty, Tile.Empty, Tile.Project,
            Tile.Empty, Tile.Event, Tile.Project, Tile.Empty, Tile.Event, Tile.Project, Tile.Empty, Tile.Empty, Tile.Project, 
            Tile.Empty, Tile.Event, Tile.Project, Tile.Empty, Tile.Project, Tile.Event, Tile.Project, Tile.Project 
        };
        public List<Card> Projects = new List<Card>();
        public List<Card> Events = new List<Card>();

        public static void initCards(GameBoard board)
        {
            board.Projects = new List<Card> 
            {
                new Card(Role.Programmer, Card.normalProject),
                new Card(Role.Programmer, Card.normalProject),
                new Card(Role.Programmer, Card.normalProject),
                new Card(Role.Programmer, Card.normalProject),
                new Card(Role.Analyst, Card.normalProject),
                new Card(Role.Analyst, Card.normalProject),
                new Card(Role.Analyst, Card.normalProject),
                new Card(Role.Analyst, Card.normalProject),
                new Card(Role.Artist, Card.normalProject),
                new Card(Role.Artist, Card.normalProject),
                new Card(Role.Artist, Card.normalProject),
                new Card(Role.Artist, Card.normalProject),
                new Card(Role.Designer, Card.normalProject),
                new Card(Role.Designer, Card.normalProject),
                new Card(Role.Designer, Card.normalProject),
                new Card(Role.Designer, Card.normalProject),
                new Card(Role.Analyst, Card.specialProject),
                new Card(Role.Artist, Card.specialProject),
                new Card(Role.Programmer, Card.specialProject),
                new Card(Role.Designer, Card.specialProject),
                new Card(Role.Programmer, Card.normalProject),
                new Card(Role.Programmer, Card.normalProject),
                new Card(Role.Programmer, Card.normalProject),
                new Card(Role.Programmer, Card.normalProject),
                new Card(Role.Analyst, Card.normalProject),
                new Card(Role.Analyst, Card.normalProject),
                new Card(Role.Analyst, Card.normalProject),
                new Card(Role.Analyst, Card.normalProject),
                new Card(Role.Artist, Card.normalProject),
                new Card(Role.Artist, Card.normalProject),
                new Card(Role.Artist, Card.normalProject),
                new Card(Role.Artist, Card.normalProject),
                new Card(Role.Designer, Card.normalProject),
                new Card(Role.Designer, Card.normalProject),
                new Card(Role.Designer, Card.normalProject),
                new Card(Role.Designer, Card.normalProject),
                new Card(Role.Analyst, Card.specialProject),
                new Card(Role.Artist, Card.specialProject),
                new Card(Role.Programmer, Card.specialProject),
                new Card(Role.Designer, Card.specialProject)
            };

            board.Events = new List<Card>
            {
                new Card(Role.none, Card.FailedCourse),
                new Card(Role.none, Card.NetworkingEvent),
                new Card(Role.none, Card.GameTesting),
                new Card(Role.none, Card.Sabotage),
                new Card(Role.none, Card.AmbitiousProject),
                new Card(Role.none, Card.HelpAFriend),
                new Card(Role.none, Card.Plagiarism),
                new Card(Role.none, Card.PrepCourse),
                new Card(Role.none, Card.GameTesting),
                new Card(Role.none, Card.FailedCourse),
                new Card(Role.none, Card.Accreditation),
                new Card(Role.none, Card.Hangover),
                new Card(Role.none, Card.SuddenAssignment),
                new Card(Role.none, Card.TeamChemistry),
                new Card(Role.none, Card.WellRested),
                new Card(Role.none, Card.WellRested),
                new Card(Role.none, Card.GreatSuccess),
                new Card(Role.none, Card.MandatorySwedish),
                new Card(Role.none, Card.DivineIntervention),
                new Card(Role.none, Card.DivineIntervention),
                new Card(Role.none, Card.FailedCourse),
                new Card(Role.none, Card.NetworkingEvent),
                new Card(Role.none, Card.GameTesting),
                new Card(Role.none, Card.Sabotage),
                new Card(Role.none, Card.AmbitiousProject),
                new Card(Role.none, Card.HelpAFriend),
                new Card(Role.none, Card.Plagiarism),
                new Card(Role.none, Card.PrepCourse),
                new Card(Role.none, Card.GameTesting),
                new Card(Role.none, Card.FailedCourse),
                new Card(Role.none, Card.Accreditation),
                new Card(Role.none, Card.Hangover),
                new Card(Role.none, Card.SuddenAssignment),
                new Card(Role.none, Card.TeamChemistry),
                new Card(Role.none, Card.WellRested),
                new Card(Role.none, Card.WellRested),
                new Card(Role.none, Card.GreatSuccess),
                new Card(Role.none, Card.MandatorySwedish),
                new Card(Role.none, Card.DivineIntervention),
                new Card(Role.none, Card.DivineIntervention)
            };
        }
    }
}
