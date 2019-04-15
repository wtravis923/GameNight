using GameNight.Data;
using GameNight.Models;
using GameNight.Models.GameModels;
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

        public GameDetail GetGameById(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.GameId == gameId);

                return
                    new GameDetail
                    {
                        GameId = entity.GameId,
                        Title = entity.Title,
                        Genre = entity.Genre,
                        PlayerCount = entity.PlayerCount
                    };
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.GameId == model.GameId && e.OwnerId == _gameId);

                entity.Title = model.Title;
                entity.Genre = model.Genre;
                entity.PlayerCount = model.PlayerCount;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.GameId == gameId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }


}
