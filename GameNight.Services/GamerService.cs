﻿using GameNight.Data;
using GameNight.Models;
using GameNight.Models.GamerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Services
{
    public class GamerService
    {
        private readonly Guid _gamerId;

        public GamerService(Guid gamerId)
        {
            _gamerId = gamerId;
        }

        public bool CreateGamer(GamerCreate model)
        {
            var entity =
                new Gamer()
                {
                    PlayerId = _gamerId,
                    GamerTag = model.GamerTag,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    Location = model.Location,
                    Bio = model.Bio
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Gamers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GamerListItem> GetGamers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Gamers
                    .Where(e => e.PlayerId == _gamerId)
                    .Select(
                        e =>
                        new GamerListItem
                        {
                            GamerId = e.GamerId,
                            GamerTag = e.GamerTag,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            EmailAddress = e.EmailAddress,
                            Location = e.Location,
                            Bio = e.Bio,
                        }
                        );
                return query.ToArray();
            }
        }

        public GamerDetail GetGamerById (int gamerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Gamers
                    .Single(e => e.GamerId == gamerId);

                return
                    new GamerDetail
                    {
                        GamerId = entity.GamerId,
                        GamerTag = entity.GamerTag,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        EmailAddress = entity.EmailAddress,
                        Location = entity.Location,
                        Bio = entity.Bio,
                    };
            }
        }

        public bool UpdateGamer(GamerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Gamers
                    .Single(e => e.GamerId == model.GamerId && e.PlayerId == _gamerId);

                entity.GamerTag = model.GamerTag;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.EmailAddress = model.EmailAddress;
                entity.Location = model.Location;
                entity.Bio = model.Bio;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGamer(int gamerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Gamers
                    .Single(e => e.GamerId == gamerId);

                ctx.Gamers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
