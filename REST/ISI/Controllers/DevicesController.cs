using DeviceReference;
using ISI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ISI.Controllers
{
    /// <summary>
    /// Controller for managing devices.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Create, read, update and delete of Devices")]
    public class DevicesController : ControllerBase
    {
        // Create an instance of the SOAP client for DeviceWS
        DeviceWSSoapClient _deviceWSClient = new DeviceWSSoapClient(new ());

        #region GET

        /// <summary>
        /// Gets all devices.
        /// </summary>
        /// <returns>An ActionResult containing a list of all devices.</returns>
        /// <remarks>
        /// Sample Request:
        ///     
        ///     GET /api/Devices
        ///     {
        ///         // No body
        ///     }
        ///     
        /// </remarks>
        [Authorize(Roles = "Esp")]
        [HttpGet]
        [SwaggerResponse(200, "Returns an ActionResult containing a list of all devices.")]
        [SwaggerResponse(400, "If the list is null")]
        [SwaggerResponse(401, "Unauthorized access to execute the method.")]
        public IActionResult GetAllDevices()
        {
            try
            {
                var devices = _deviceWSClient.GetAllDevices();

                return Ok(devices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets all device by the given userId.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve devices for.</param>
        /// <returns>An ActionResult containing the device information.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     GET /api/Devices/{userId}
        ///     {
        ///         "userId": 1
        ///     }
        ///     
        /// </remarks>
        [Authorize(Roles = "Esp, User")]
        [HttpGet("{userId}")]
        [SwaggerResponse(200, "Returns an ActionResult containing the device information.")]
        [SwaggerResponse(400, "If the device is null.")]
        [SwaggerResponse(401, "Unauthorized access to execute the method.")]
        public IActionResult GetDeviceById(int userId)
        {
            try
            {
                var device = _deviceWSClient.GetDeviceByUserId(userId);

                if (device != null)
                {
                    return Ok(device);
                }
                else
                {
                    return NotFound($"Device with ID {userId} not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #endregion

        #region POST

        /// <summary>
        /// Inserts a new device.
        /// </summary>
        /// <param name="device">The device information to insert.</param>
        /// <returns>An IActionResult indicating the result of the insertion.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /api/Devices
        ///     {
        ///         "id": 1,
        ///         "name": "Devicetest",
        ///         "state": false,
        ///         "value": 30.0,
        ///         "houseId": 1
        ///     }
        ///     
        /// </remarks>
        [Authorize(Roles = "User")]
        [HttpPost]
        [SwaggerResponse(200, "Returns an IActionResult indicating the result of the insertion.")]
        [SwaggerResponse(400, "If there was a parameter invalid.")]
        [SwaggerResponse(401, "Unauthorized access to execute the method.")]
        public IActionResult PostDevice([FromBody] Models.Device device)
        {
            try
            {
                int rowsAffected = _deviceWSClient.InsertDevice(device.Name, device.State, device.Value, device.HouseId);

                if (rowsAffected > 0)
                {
                    return Ok($"Device inserted successfully. Rows affected: {rowsAffected}");
                }
                else
                {
                    return BadRequest("Failed to insert device.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Inserts a new device via Async.
        /// </summary>
        /// <param name="device">The device information to insert.</param>
        /// <returns>An IActionResult indicating the result of the insertion.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /api/Devices/async
        ///     {
        ///         "id": 1,
        ///         "name": "Devicetest",
        ///         "state": false,
        ///         "value": 30.0,
        ///         "houseId": 1
        ///     }
        ///     
        /// </remarks>
        [Authorize(Roles = "User")]
        [HttpPost("async")]
        [SwaggerResponse(200, "Returns an IActionResult indicating the result of the insertion.")]
        [SwaggerResponse(400, "If there was a parameter invalid.")]
        [SwaggerResponse(401, "Unauthorized access to execute the method.")]
        public async Task<IActionResult> PostDeviceAsync([FromBody] Models.Device device)
        {
            try
            {
                int rowsAffected = (await _deviceWSClient.InsertDeviceAsync(device.Name, device.State, device.Value, device.HouseId)).Body.InsertDeviceResult;

                if (rowsAffected > 0)
                {
                    return Ok($"Device inserted successfully. Rows affected: {rowsAffected}");
                }
                else
                {
                    return BadRequest("Failed to insert device.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #endregion

        #region PUT

        /// <summary>
        /// Updates a device by its ID.
        /// </summary>
        /// <param name="id">The ID of the device to update.</param>
        /// <param name="device">The updated device information.</param>
        /// <returns>An IActionResult indicating the result of the update.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     PUT /api/Devices/{id}
        ///     {
        ///         "id": 1,
        ///         "name": "test",
        ///         "state": false,
        ///         "value": 25.0,
        ///         "houseId": 1
        ///     }
        ///     
        /// </remarks>
        [Authorize(Roles = "User")]
        [HttpPut("{id}")]
        [SwaggerResponse(200, "Returns an IActionResult indicating the result of the update.")]
        [SwaggerResponse(400, "If the device is null.")]
        [SwaggerResponse(401, "Unauthorized access to execute the method.")]
        public IActionResult UpdateDevice(int id, [FromBody] Models.Device device)
        {
            try
            {
                double value = (double)(device.Value is null ? 0.0 : device.Value);

                int rowsAffected = _deviceWSClient.UpdateDevice(device.Id, value);

                if (rowsAffected > 0)
                {
                    return Ok($"Device updated successfully. Rows affected: {rowsAffected}");
                }
                else
                {
                    return NotFound($"Device with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Deletes a device by its ID.
        /// </summary>
        /// <param name="id">The ID of the device to delete.</param>
        /// <returns>An IActionResult indicating the result of the deletion.</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     DELETE /api/Devices/{id}
        ///     {
        ///         "id": 1
        ///     }
        ///     
        /// </remarks>
        [Authorize(Roles = "User")]
        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Returns an IActionResult indicating the result of the deletion.")]
        [SwaggerResponse(400, "If the device is null.")]
        [SwaggerResponse(401, "Unauthorized access to execute the method.")]
        public IActionResult DeleteDevice(int id)
        {
            try
            {
                int rowsAffected = _deviceWSClient.DeleteDevice(id);

                if (rowsAffected > 0)
                {
                    return Ok($"Device deleted successfully. Rows affected: {rowsAffected}");
                }
                else
                {
                    return NotFound($"Device with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #endregion
    }
}
