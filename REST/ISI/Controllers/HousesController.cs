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

        #region GET

        /// <summary>
        /// This Method Gets all the Houses
        /// </summary>
        /// <returns>An List of Houses</returns>
        /// <remarks>
        /// Sample Request:
        ///     GET /api/Houses
        ///     {
        ///         // No request body for this endpoint.
        ///     }
        /// </remarks>
        /// <response code="200">Returns an list of houses</response>
        /// <response code="400">If the list is null</response>
        /// <response code="401">No permission to execute the method</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        ///     GET /api/Houses/{idUser}
        ///     {
        ///        "id": 1,
        ///        "name": "HouseTest",
        ///        "userId": 1
        ///     }
        /// </remarks>
        /// <response code="200">Returns a list of houses associated with a specific user.</response>
        /// <response code="400">If the list of houses is null.</response>
        /// <response code="401">Unauthorized access to execute the method.</response>
        [HttpGet("{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        ///     POST /api/Houses/{idUser}
        ///     {
        ///        "id": 1,
        ///        "name": "HouseTest",
        ///        "userId": 1
        ///     }
        /// </remarks>
        /// <response code="200">Returns a ActionResult with appropriate HTTP status.</response>
        /// <response code="400">If the input house is null or creation fails.</response>
        /// <response code="401">Unauthorized access to execute the method.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        ///     PUT /api/Houses/{id}
        ///     {
        ///        "id": 1,
        ///        "name": "HouseTest",
        ///        "userId": 1
        ///     }
        /// </remarks>
        /// <response code="200">Returns a list of houses.</response>
        /// <response code="400">If the input house is null or if IDs do not match.</response>
        /// <response code="401">Unauthorized access to execute the method.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
        ///     DELETE /api/Houses/{id}
        ///     {
        ///        "id": 1
        ///     }
        /// </remarks>
        /// <response code="200">Returns a list of houses.</response>
        /// <response code="400">If the list is null or deletion fails.</response>
        /// <response code="401">Unauthorized access to execute the method.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult Delete(int id)
        {
            // Try to delete
            if (!_repository.DeleteHouse(id)) return BadRequest();

            return Ok();
        }

        #endregion
    }
}
