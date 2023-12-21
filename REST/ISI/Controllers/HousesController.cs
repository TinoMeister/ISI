using ISI.Data;
using ISI.Enums;
using ISI.Models;
using ISI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ISI.Controllers
{
    [SwaggerTag("Create, read, update and delete of Houses")]
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

        #region GET

        /// <summary>
        /// Gets all the Houses
        /// </summary>
        /// <returns>An List of Houses</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/Houses
        ///     {
        ///         // No request body for this endpoint.
        ///     }
        ///     
        /// </remarks>
        [HttpGet]
        [SwaggerResponse(200, "Returns an list of houses.")]
        [SwaggerResponse(400, "If the list is null.")]
        [SwaggerResponse(401, "No permission to execute the method.")]
        public IEnumerable<House> Get()
        {
            return _repository.GetAllHouses();
        }

        /// <summary>
        /// Gets all houses associated with a user.
        /// </summary>
        /// <param name="idUser">User's ID.</param>
        /// <returns>List of houses.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/Houses/{idUser}
        ///     {
        ///        "id": 1,
        ///        "name": "HouseTest",
        ///        "userId": 1
        ///     }
        ///     
        /// </remarks>
        [HttpGet("{idUser}")]
        [SwaggerResponse(200, "Returns a list of houses associated with a specific user.")]
        [SwaggerResponse(400, "If the list of houses is null.")]
        [SwaggerResponse(401, "Unauthorized access to execute the method.")]
        public IEnumerable<House> Get(int idUser)
        {
            return _repository.GetHousesByUser(idUser);
        }

        #endregion

        #region POST

        /// <summary>
        /// Creates a new house.
        /// </summary>
        /// <param name="house">The house object to be created.</param>
        /// <returns>ActionResult with appropriate HTTP status.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /api/Houses/{idUser}
        ///     {
        ///        "id": 1,
        ///        "name": "HouseTest",
        ///        "userId": 1
        ///     }
        ///     
        /// </remarks>
        [HttpPost]
        [SwaggerResponse(200, "Returns a ActionResult with appropriate HTTP status.")]
        [SwaggerResponse(400, "If the input house is null or creation fails.")]
        [SwaggerResponse(401, "Unauthorized access to execute the method.")]
        public ActionResult Post([FromBody] House house)
        {
            // Verify if the house is null
            if (house is null) return BadRequest();

            // Try to insert into the database
            if (!_repository.CreateHouse(house)) return BadRequest();

            return Ok();
        }

        #endregion

        #region PUT

        /// <summary>
        /// Updates a house.
        /// </summary>
        /// <param name="id">The ID of the house to update.</param>
        /// <param name="house">The updated house object.</param>
        /// <returns>ActionResult with appropriate HTTP status.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     PUT /api/Houses/{id}
        ///     {
        ///        "id": 1,
        ///        "name": "HouseTest",
        ///        "userId": 1
        ///     }
        ///     
        /// </remarks>
        [HttpPut("{id}")]
        [SwaggerResponse(200, "Returns a list of houses.")]
        [SwaggerResponse(400, "If the input house is null or if IDs do not match.")]
        [SwaggerResponse(401, "Unauthorized access to execute the method.")]
        public ActionResult Put(int id, [FromBody] House house)
        {
            // Verify if the house is null and if the IDs are equal
            if (house is null || !house.Id.Equals(id)) return BadRequest();

            // Try to update
            if (!_repository.UpdateHouse(house)) return BadRequest();

            return Ok();
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Deletes a house.
        /// </summary>
        /// <param name="id">The ID of the house to delete.</param>
        /// <returns>ActionResult with appropriate HTTP status.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     DELETE /api/Houses/{id}
        ///     {
        ///        "id": 1
        ///     }
        ///     
        /// </remarks>
        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Returns a list of houses.")]
        [SwaggerResponse(400, "If the list is null or deletion fails.")]
        [SwaggerResponse(401, "Unauthorized access to execute the method.")]
        public ActionResult Delete(int id)
        {
            // Try to delete
            if (!_repository.DeleteHouse(id)) return BadRequest();

            return Ok();
        }

        #endregion
    }
}
