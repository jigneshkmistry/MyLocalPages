using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyLocalPages.Domain;
using MyLocalPages.DTO;
using MyLocalPages.Services;

namespace MyLocalPages.API.Controllers
{
    /// <summary>
    /// Business Directory Controller
    /// </summary>
    [Route("api/v{version:apiVersion}/BusinessDirectories")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BusinessDirectoriesController : ControllerBase
    {

        #region PRIVATE MEMBERS

        private readonly ILogger<BusinessDirectoriesController> _logger;
        private readonly IBusinessDirectoryService _businessDirectoryService;
        private readonly IMapper _mapper;

        #endregion

        #region CONSTRUCTOR

        public BusinessDirectoriesController(ILogger<BusinessDirectoriesController> logger,
            IBusinessDirectoryService businessDirectoryService,
            IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _businessDirectoryService = businessDirectoryService ?? throw new ArgumentNullException(nameof(businessDirectoryService));
        }

        #endregion

        #region HTTPGET

        /// <summary>
        /// Gets the list of BusinessDirectory. 
        /// </summary>
        /// <returns>List of BusinessDirectories</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBusinessDirectories()
        {
            _logger.LogInformation("GetBusinessDirectories called : ");
            return Ok(await _businessDirectoryService.GetAllEntitiesAsync());
        }

        /// <summary>
        /// Gets the BusinessDirectory info by id.
        /// </summary>
        /// <param name="id">id of the BusinessDirectory</param>
        /// <returns>BusinessDirectory info</returns>
        [HttpGet]
        [Route("{id}", Name = "GetBusinessDirectory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DirectoryCategoryDTO>> GetBusinessDirectory(Guid id)
        {
            _logger.LogInformation("GetBusinessDirectory called : ");
            var businessDirectory = _mapper.Map<BusinessDirectoryDTO>(await _businessDirectoryService.GetEntityByIdAsync(id));

            if (businessDirectory == null)
            {
                _logger.LogInformation($"BusinessDirectory with id {id} is not found: ");
                return NotFound();
            }

            return Ok(businessDirectory);
        }

        #endregion

        #region HTTPPOST

        /// <summary>
        /// Creates a BusinessDirectory.
        /// </summary>
        /// <param name="businessDirectoryForCreationDTO">create BusinessDirectory model</param>
        /// <returns>BusinessDirectory model</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BusinessDirectoryDTO>> CreateBusinessDirectory(BusinessDirectoryForCreationDTO businessDirectoryForCreationDTO)
        {
            _logger.LogInformation("CreateBusinessDirectory called : ");
            var directoryToReturn = await _businessDirectoryService.CreateEntityAsync<BusinessDirectoryDTO, BusinessDirectoryForCreationDTO>(businessDirectoryForCreationDTO);
            return CreatedAtRoute("GetBusinessDirectory", new { directoryToReturn.Id }, directoryToReturn);
        }

        #endregion

        #region HTTPUT

        /// <summary>
        /// Updates a BusinessDirectory.
        /// </summary>
        /// <param name="id">id of the BusinessDirectory</param>
        /// <param name="businessDirectoryForUpdateDTO">BusinessDirectory model</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}", Name = "UpdateBusinessDirectory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateBusinessDirectory(Guid id, BusinessDirectoryForUpdateDTO businessDirectoryForUpdateDTO)
        {
            _logger.LogInformation("UpdateBusinessDirectory called : ");

            if (!await _businessDirectoryService.ExistAsync(x => x.Id == id))
            {
                return NotFound();
            }

            await _businessDirectoryService.UpdateEntityAsync(id, businessDirectoryForUpdateDTO);

            return NoContent();
        }

        #endregion

        #region HTTPPATCH

        /// <summary>
        /// Partially updates the BusinessDirectory.
        /// </summary>
        /// <param name="id">id of the BusinessDirectory</param>
        /// <param name="patchDocument">patchDocument for BusinessDirectory</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id}", Name = "PartiallyUpdateBusinessDirectory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PartiallyUpdateBusinessDirectory(Guid id, JsonPatchDocument<BusinessDirectoryForUpdateDTO> patchDocument)
        {
            _logger.LogInformation("PartiallyUpdateBusinessDirectory called : ");

            BusinessDirectoryForUpdateDTO dto = new BusinessDirectoryForUpdateDTO();
            BusinessDirectory businessDirectory = new BusinessDirectory();

            //if show not found
            if (!await _businessDirectoryService.ExistAsync(x => x.Id == id))
            {
                //then return not found response.
                return NotFound();
            }

            //apply the patch changes to the dto. 
            patchDocument.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(dto))
            {
                return BadRequest(ModelState);
            }

            //map the chnages from dto to entity.
            _mapper.Map(dto, businessDirectory);

            //set the Id for the show model.
            businessDirectory.Id = id;

            //partially update the chnages to the db. 
            await _businessDirectoryService.UpdatePartialEntityAsync(businessDirectory, patchDocument);

            return NoContent();
        }

        #endregion

        #region HTTPDELETE

        /// <summary>
        /// Deletes the BusinessDorectory.
        /// </summary>
        /// <param name="id">id of the BusinessDirectory</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteBusinessDirectory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBusinessDirectory(Guid id)
        {        
            if (await _businessDirectoryService.ExistAsync(x => x.Id == id))
            {               
                await _businessDirectoryService.DeleteEntityAsync(id);
            }
            else
            {            
                return NotFound();
            }
           
            return NoContent();
        }

        #endregion

    }
}
