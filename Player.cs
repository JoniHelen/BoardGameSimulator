using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameSimulator
{
    class Player
    {
        public int Points;
        public int PointsPerRoundThisGame;
        public int TurnsPlayed;
        public int Position;
        public int Projects;
        public int Rolls = 0;

        public bool Engineer;
        public bool turnBlocked;

        public int[] turnsPerGame = new int[1000];
        public int[] pointsPerGame = new int[1000];
        public int[] projectsPerGame = new int[1000];
        public float[] pointsPerRoundPerGame = new float[1000];

        public float avgProjects = 0;
        public float avgTurns = 0;
        public float avgPoints = 0;
        public float avgPointsPerRound = 0;

        public Role Role;

        public List<Card> HeldCards = new List<Card>();

        public Player(Role role)
        {
            Role = role;
        }
    }
}
