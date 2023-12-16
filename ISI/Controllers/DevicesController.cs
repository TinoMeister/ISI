using ISI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOAP_DeviceWS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ISI.Controllers
{
    /// <summary>
    /// Controller for managing devices.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        DeviceWSSoapClient _deviceWSClient = new DeviceWSSoapClient();

        /// <summary>
        /// Gets all devices.
        /// </summary>
        /// <returns>An ActionResult containing a list of all devices.</returns>
        [HttpGet]
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
        /// Gets a device by its ID.
        /// </summary>
        /// <param name="id">The ID of the device to retrieve.</param>
        /// <returns>An ActionResult containing the device information.</returns>
        [HttpGet("{id}")]
        public IActionResult GetDeviceById(int id)
        {
            try
            {
                var device = _deviceWSClient.GetDeviceById(id);

                if (device != null)
                {
                    return Ok(device);
                }
                else
                {
                    return NotFound($"Device with ID {id} not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Inserts a new device.
        /// </summary>
        /// <param name="device">The device information to insert.</param>
        /// <returns>An IActionResult indicating the result of the insertion.</returns>
        [HttpPost]
        public IActionResult PostDevice([FromBody] Device device)
        {
            try
            {
                int rowsAffected = _deviceWSClient.InsertDevice(device.Id, device.Name, device.State, device.Value, device.HouseId);

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
        /// Updates a device by its ID.
        /// </summary>
        /// <param name="id">The ID of the device to update.</param>
        /// <param name="device">The updated device information.</param>
        /// <returns>An IActionResult indicating the result of the update.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateDevice(int id, [FromBody] Device device)
        {
            try
            {
                int rowsAffected = _deviceWSClient.UpdateDevice(device.Id, device.Value);

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

        /// <summary>
        /// Deletes a device by its ID.
        /// </summary>
        /// <param name="id">The ID of the device to delete.</param>
        /// <returns>An IActionResult indicating the result of the deletion.</returns>
        [HttpDelete("{id}")]
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
    }
}
