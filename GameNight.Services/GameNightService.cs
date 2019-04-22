using GameNight.Data;
using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Services
{
    public class GameNightService
    {
        private readonly Guid _userId;

        public GameNightService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGameTime(GameNightCreate model)
        {
            var entity =
                new GameTime()
                {
                    GameId = model.GameId,
                    OwnerId = _userId,
                    DateTime = model.DateTime,
                    Location = model.Location,
                    NoobsAllowed = model.NoobsAllowed,
                    Description = model.Description,
                    TutorialVideo = model.TutorialVideo,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameTimes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameNightListItem> GetGameTimes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .GameTimes
                    .Select(
                     e =>
                        new GameNightListItem
                        {
                            GameId = e.GameId,
                            Title = e.Game.Title,
                            Genre = e.Game.Genre,
                            PlayerCount = e.Game.PlayerCount,
                            GameTimeId = e.GameTimeId,
                            DateTime = e.DateTime,
                            Location = e.Location,
                            NoobsAllowed = e.NoobsAllowed,
                            Description = e.Description,
                            TutorialVideo = e.TutorialVideo,
                        }
                        ).ToArray();

                return query;
            }
        }

        public GameNightDetail GetGameNightById(int gameTimeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GameTimes
                    .Single(e => e.GameTimeId == gameTimeId);
                return
                    new GameNightDetail
                    {
                        GameTimeId = entity.GameTimeId,
                        GameId = entity.Game.GameId,
                        Title = entity.Game.Title,
                        Genre = entity.Game.Genre,
                        PlayerCount = entity.Game.PlayerCount,
                        DateTime = entity.DateTime,
                        Location = entity.Location,
                        NoobsAllowed = entity.NoobsAllowed,
                        Description = entity.Description,
                        TutorialVideo = entity.TutorialVideo,
                    };
            }
        }

        public bool UpdateGameNight(GameNightEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GameTimes
                    .Single(e => e.GameTimeId == model.GameTimeId && e.OwnerId == _userId);

                entity.GameId = model.GameId;
                entity.DateTime = model.DateTime;
                entity.Location = model.Location;
                entity.NoobsAllowed = model.NoobsAllowed;
                entity.Description = model.Description;
                entity.TutorialVideo = model.TutorialVideo;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGameTime (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GameTimes
                    .Single(e => e.GameTimeId == id && e.OwnerId == _userId);

                ctx.GameTimes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
