using GameNight.Data;
using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Services
{
    public class GameService
    {
        private readonly Guid _gameId;

        public GameService(Guid gameId)
        {
            _gameId = gameId;
        }

        public bool CreateGame (GameCreate model)
        {
            var entity =
                new Game()
                {
                    OwnerId = _gameId,
                    Title = model.Title,
                    Genre = model.Genre,
                    PlayerCount = model.PlayerCount
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Select(
                        e =>
                        new GameListItem
                        {
                            GameId = e.GameId,
                            Title = e.Title,
                            Genre = e.Genre,
                            PlayerCount = e.PlayerCount
                        }
                        );
                return query.ToArray();
            }
        }
    }


}
