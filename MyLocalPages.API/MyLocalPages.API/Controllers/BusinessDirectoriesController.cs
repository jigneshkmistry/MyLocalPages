using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyLocalPages.Domain;
using MyLocalPages.DTO;
using MyLocalPages.Services;

namespace MyLocalPages.API.Controllers
{
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

        [HttpGet]
        /// <summary>
        /// Gets the business directories 
        /// </summary>
        /// <returns>List of business directories</returns>
        public async Task<IActionResult> GetBusinessDirectories()
        {
            _logger.LogInformation("GetBusinessDirectories called : ");
            return Ok(await _businessDirectoryService.GetAllEntitiesAsync());
        }

        [HttpGet]
        [Route("{id}", Name = "GetBusinessDirectory")]
        /// <summary>
        /// get the business category info
        /// </summary>
        /// <param name="id">unique identifier for the category</param>
        /// <returns></returns>
        public async Task<ActionResult<DirectoryCategoryDTO>> GetBusinessDirectory(Guid id)
        {
            var category = _mapper.Map<BusinessDirectoryDTO>(await _businessDirectoryService.GetEntityByIdAsync(id));

            if (category == null)
            {
                _logger.LogInformation($"Business category with id {id} is not found: ");
                return NotFound();
            }

            return Ok(category);
        }

        #endregion

        #region HTTPPOST

        [HttpPost]
        /// <summary>
        /// creates business directory
        /// </summary>
        /// <param name="businessDirectory">BusinessDirectory creation model</param>
        /// <returns>BusinessDirectoryResposne Model</returns>
        public async Task<ActionResult<BusinessDirectoryDTO>> CreateBusinessDirectory(BusinessDirectoryForCreationDTO businessDirectoryForCreationDTO)
        {
            var directoryToReturn = await _businessDirectoryService.CreateEntityAsync<BusinessDirectoryDTO, BusinessDirectoryForCreationDTO>(businessDirectoryForCreationDTO);
            return CreatedAtRoute("GetBusinessDirectory", new { directoryToReturn.Id }, directoryToReturn);
        }

        #endregion

        #region HTTPUT

        [HttpPut]
        [Route("{id}", Name = "UpdateBusinessDirectory")]
        /// <summary>
        /// updates business directory
        /// </summary>
        /// <param name="businessDirectory">BusinessDirectory update model</param>
        /// <returns>BusinessDirectoryResposne Model</returns>
        public async Task<ActionResult> UpdateBusinessDirectory(Guid id, BusinessDirectoryForUpdateDTO businessDirectoryForUpdateDTO)
        {
            //if show not found
            if (!await _businessDirectoryService.ExistAsync(x => x.Id == id))
            {
                //then return not found response.
                return NotFound();
            }

            //Update an entity.
            await _businessDirectoryService.UpdateEntityAsync(id, businessDirectoryForUpdateDTO);

            return NoContent();
        }

        #endregion

        #region HTTPPATCH

        [HttpPatch]
        [Route("{id}", Name = "PartiallyUpdateBusinessDirectory")]
        /// <summary>
        /// partially updates business directory category
        /// </summary>
        /// <param name="businessDirectory">BusinessDirectoryCategory update model</param>
        /// <returns>BusinessDirectoryCategoryResposne Model</returns>
        public async Task<ActionResult> PartiallyUpdateBusinessDirectory(Guid id, JsonPatchDocument<BusinessDirectoryForUpdateDTO> patchDocument)
        {
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
        /// Deletes the business directory.
        /// </summary>
        /// <param name="id">Unique indetifier for business directory</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteBusinessDirectory")]
        public async Task<ActionResult> DeleteBusinessDirectory(Guid id)
        {
            //if the event exists
            if (await _businessDirectoryService.ExistAsync(x => x.Id == id))
            {
                //delete the event from the db.
                await _businessDirectoryService.DeleteEntityAsync(id);
            }
            else
            {
                //if event doesn't exists then returns not found.
                return NotFound();
            }

            //return the response.
            return NoContent();
        }

        #endregion

    }
}
