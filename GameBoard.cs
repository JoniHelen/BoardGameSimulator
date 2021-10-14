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
                new Card(Role.Programmer, Card.FailedCourse),
                new Card(Role.Programmer, Card.NetworkingEvent),
                new Card(Role.Programmer, Card.GameTesting),
                new Card(Role.Programmer, Card.Sabotage),
                new Card(Role.Analyst, Card.AmbitiousProject),
                new Card(Role.Analyst, Card.HelpAFriend),
                new Card(Role.Analyst, Card.Plagiarism),
                new Card(Role.Analyst, Card.PrepCourse),
                new Card(Role.Artist, Card.GameTesting),
                new Card(Role.Artist, Card.FailedCourse),
                new Card(Role.Artist, Card.Accreditation),
                new Card(Role.Artist, Card.Hangover),
                new Card(Role.Designer, Card.SuddenAssignment),
                new Card(Role.Designer, Card.TeamChemistry),
                new Card(Role.Designer, Card.WellRested),
                new Card(Role.Designer, Card.WellRested),
                new Card(Role.Analyst, Card.GreatSuccess),
                new Card(Role.Artist, Card.MandatorySwedish),
                new Card(Role.Programmer, Card.DivineIntervention),
                new Card(Role.Designer, Card.DivineIntervention),
                new Card(Role.Programmer, Card.FailedCourse),
                new Card(Role.Programmer, Card.NetworkingEvent),
                new Card(Role.Programmer, Card.GameTesting),
                new Card(Role.Programmer, Card.Sabotage),
                new Card(Role.Analyst, Card.AmbitiousProject),
                new Card(Role.Analyst, Card.HelpAFriend),
                new Card(Role.Analyst, Card.Plagiarism),
                new Card(Role.Analyst, Card.PrepCourse),
                new Card(Role.Artist, Card.GameTesting),
                new Card(Role.Artist, Card.FailedCourse),
                new Card(Role.Artist, Card.Accreditation),
                new Card(Role.Artist, Card.Hangover),
                new Card(Role.Designer, Card.SuddenAssignment),
                new Card(Role.Designer, Card.TeamChemistry),
                new Card(Role.Designer, Card.WellRested),
                new Card(Role.Designer, Card.WellRested),
                new Card(Role.Analyst, Card.GreatSuccess),
                new Card(Role.Artist, Card.MandatorySwedish),
                new Card(Role.Programmer, Card.DivineIntervention),
                new Card(Role.Designer, Card.DivineIntervention)
            };
        }
    }
}
