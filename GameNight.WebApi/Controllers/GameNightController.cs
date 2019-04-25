using GameNight.Models;
using GameNight.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameNight.WebApi.Controllers
{
    [Authorize]
    public class GameNightController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            GameNightService gameNightService = CreateGameNightService();
            var gameNights = gameNightService.GetGameTimes();
            return Ok(gameNights);
        }

        public IHttpActionResult Get (int id)
        {
            GameNightService gameNightService = CreateGameNightService();
            var gameNight = gameNightService.GetGameNightById(id);
            return Ok(gameNight);
        }

        public IHttpActionResult Post(GameNightCreate gameNight)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameNightService();

            if (!service.CreateGameTime(gameNight))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(GameNightEdit gameNight)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameNightService();

            if (!service.UpdateGameNight(gameNight))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete (int id)
        {
            var service = CreateGameNightService();

            if (!service.DeleteGameTime(id))
                return InternalServerError();

            return Ok();
        }

        private GameNightService CreateGameNightService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var gameNightService = new GameNightService(userId);
            return gameNightService;
        }


    }
}
