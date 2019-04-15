﻿using GameNight.Data;
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
                    //.Where(e => e.OwnerId == _userId)
                    .Select(

                     e =>
                        new GameNightListItem
                        {
                            GameTimeId = e.GameTimeId,
                            DateTime = e.DateTime,
                            Location = e.Location,
                            NoobsAllowed = e.NoobsAllowed,
                            Description = e.Description,
                            TutorialVideo = e.TutorialVideo,
                        }
                        );

                return query.ToArray();
            }
        }

        public GameNightDetail GetGameNightById(int gameTimeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .GameTimes
                    .Single(e => e.GameTimeId == gameTimeId && e.OwnerId == _userId);
                return
                    new GameNightDetail
                    {
                        GameTimeId = entity.GameTimeId,
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
