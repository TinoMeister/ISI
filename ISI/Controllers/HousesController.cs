using ISI.Data;
using ISI.Enums;
using ISI.Models;
using ISI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISI.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly HouseRepositoryDB _repository;

        public HousesController(IConfiguration configuration)
        {
            _config = configuration;
            _repository = new HouseRepositoryDB(_config["ConnectionStrings:DbConnection"]!);
        }

        /// <summary>
        /// This Method Gets all the Houses
        /// </summary>
        /// <returns>An List of Houses</returns>
        [HttpGet]
        public IEnumerable<House> Get()
        {
            return _repository.GetAllHouses();
        }

        /// <summary>
        /// This Method Gets all the houses from 
        /// </summary>
        /// <param name="idUser">User's Id</param>
        /// <returns>List of Houses</returns>
        [HttpGet("{idUser}")]
        public IEnumerable<House> Get(int idUser)
        {
            return _repository.GetHousesByUser(idUser);
        }

        /// <summary>
        /// This Method Creates an House
        /// </summary>
        /// <param name="house">Object type House</param>
        /// <returns>Response</returns>
        [HttpPost]
        public ActionResult Post([FromBody] House house)
        {
            // Verify if the house is null
            if (house is null) return BadRequest();

            // Try to inserto into the database
            if (!_repository.CreateHouse(house))  return BadRequest();
                
            return Ok();
        }

        /// <summary>
        /// This Method Updates an House
        /// </summary>
        /// <param name="id">House Id</param>
        /// <param name="house">Object type House</param>
        /// <returns>Response</returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] House house)
        {
            // Verify if the house is null and if the id's are equal
            if (house is null || !house.Id.Equals(id)) return BadRequest();

            // Try to update
            if (_repository.UpdateHouse(house)) return BadRequest();

            return Ok();
        }

        /// <summary>
        /// This Method deletes an House
        /// </summary>
        /// <param name="id">House Id</param>
        /// <returns>Response</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Try to delete
            if (_repository.DeleteHouse(id)) return BadRequest();

            return Ok();
        }
    }
}
