using SchaebigeSchaetzungen.Model;
using System.Collections.Generic;

namespace SchaebigeSchaetzungen.Persistence
{
    public interface IDBPlayer
    {
        void Insert(Player player);
        Player Read(Player p);
        void Update(Player player);
        void UpdateCrowns(Player player);
        void Delete(Player player);
        List<Player> ReadAll();
    }
}