using SchaebigeSchaetzungen.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Model
{
    public class Game
    {
        private Player playerOne;
        private Player playerTwo;

        private List<Video> rounds;

        private void loadVideos()
        {
            /*
             TODO
            Load 10 videos into the list both player didn´t played yet
             */

            List<Video> videos = DBVideo.ReadAll();
            List<Estimation> estimations = DBEstimation.ReadAll().Where(x => !x.Player.PlayerID.Equals(playerOne.PlayerID) && !x.Player.PlayerID.Equals(playerTwo.PlayerID)).ToList();

            // estimations aufsteigend nach videoID sortieren
            // duplikate entfernen
            // foreach durch videos laufen und alle entfernen die bereits geschätzt wurden
            // danach 10 random videos raussuchen und der variable rounds hinzufügen

            for (int i = 0; i < 10; i++)
            {
                rounds.Add(new Video());
            }
        }
    }
}
