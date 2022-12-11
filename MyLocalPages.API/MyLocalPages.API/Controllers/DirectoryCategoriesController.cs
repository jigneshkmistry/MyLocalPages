using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyLocalPages.Domain;
using MyLocalPages.DTO;
using MyLocalPages.Services;

namespace MyLocalPages.API.Controllers
{
    /// <summary>
    /// DirectoryCategory Controller
    /// </summary>
    [Route("api/v{version:apiVersion}/BusinessDirectories/{directoryId}/DirectoryCategories")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DirectoryCategoriesController : ControllerBase
    {

        #region PRIVATE MEMBERS

        private readonly ILogger<DirectoryCategoriesController> _logger;
        private readonly IBusinessDirectoryService _businessDirectoryService;
        private readonly IDirectoryCategoryService _directoryCategoryService;
        private readonly IMapper _mapper;

        #endregion

        #region CONSTRUCTOR

        public DirectoryCategoriesController(ILogger<DirectoryCategoriesController> logger,
             IDirectoryCategoryService directoryCategoryService,
            IBusinessDirectoryService businessDirectoryService,
            IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _businessDirectoryService = businessDirectoryService ?? throw new ArgumentNullException(nameof(businessDirectoryService));
            _directoryCategoryService = directoryCategoryService ?? throw new ArgumentNullException(nameof(directoryCategoryService));           
        }

        #endregion

        #region HTTPGET

        /// <summary>
        /// Gets the list of DirectoryCategory.
        /// </summary>
        /// <param name="directoryId">id of the BusinessDirectory</param>
        /// <returns>List of DirectoryCategory</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DirectoryCategoryDTO>>> GetDirectoryCategories(Guid directoryId)
        {
            _logger.LogInformation("GetDirectoryCategories called : ");
            if (!await _businessDirectoryService.ExistAsync(x => x.Id == directoryId))
            {
                return NotFound();
            }

            var categories = _mapper.Map<List<DirectoryCategoryDTO>>((await _directoryCategoryService.GetAllEntitiesAsync()).Where(x => x.BusinessDirectoryId == directoryId));

            return Ok(categories);
        }

        /// <summary>
        /// Gets the DirectoryCategory info by id.
        /// </summary>
        /// <param name="directoryId">id of the BusinessDirectory</param>
        /// <param name="id">id of the DirectoryCategory</param>
        /// <returns>DirectoryCategory info</returns>
        [HttpGet]
        [Route("{id}", Name = "GetDirectoryCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DirectoryCategoryDTO>> GetDirectoryCategory(Guid directoryId, Guid id)
        {
            _logger.LogInformation("GetDirectoryCategory called : ");
            if (!await _businessDirectoryService.ExistAsync(x => x.Id == directoryId))
            {
                return NotFound();
            }

            var category = _mapper.Map<DirectoryCategoryDTO>(await _directoryCategoryService.GetEntityByIdAsync(id));

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        #endregion

        #region HTTPPOST

        /// <summary>
        ///  Creates a DirectoryCategory.
        /// </summary>
        /// <param name="directoryId">Id of the BusinessDirectory</param>
        /// <param name="directoryCategoryForCreationDTO">DirectoryCategory model</param>
        /// <returns>DirectoryCategory model</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DirectoryCategoryDTO>> CreateDirectoryCategory(Guid directoryId,
            DirectoryCategoryForCreationDTO directoryCategoryForCreationDTO)
        {
            _logger.LogInformation("CreateBusinessDirectoryCategory called : ");
            if (!await _businessDirectoryService.ExistAsync(x => x.Id == directoryId))
            {
                return NotFound();
            }

            directoryCategoryForCreationDTO.BusinessDirectoryId = directoryId;
            var categoryToReturn = await _directoryCategoryService.
                    CreateEntityAsync<DirectoryCategoryDTO, DirectoryCategoryForCreationDTO>(directoryCategoryForCreationDTO);
            return CreatedAtRoute("GetDirectoryCategory", new { directoryId, categoryToReturn.Id }, categoryToReturn);
        }

        #endregion

        #region HTTPPUT

        /// <summary>
        /// Updates a DirectoryCategory.
        /// </summary>
        /// <param name="directoryId">id of the BusinessDirectory</param>
        /// <param name="id">id of the DirectoryCategory</param>
        /// <param name="directoryCategoryForUpdateDTO">DirectoryCategory model</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}", Name = "UpdateDirectoryCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateDirectoryCategory(Guid directoryId, Guid id, DirectoryCategoryForUpdateDTO directoryCategoryForUpdateDTO)
        {
            _logger.LogInformation("UpdateDirectoryCategory called : ");
            if (!await _businessDirectoryService.ExistAsync(x => x.Id == directoryId))
            {
                return NotFound();
            }

            if (!await _directoryCategoryService.ExistAsync(x => x.Id == id))
            {
                return NotFound();
            }

            await _directoryCategoryService.UpdateEntityAsync(id, directoryCategoryForUpdateDTO);

            return NoContent();
        }

        #endregion

        #region HTTPPATCH

        /// <summary>
        /// Partially updates the DirectoryCategory.
        /// </summary>
        /// <param name="directoryId">id of the BusinessDirectory</param>
        /// <param name="id">id of the DirectoryCategory</param>
        /// <param name="patchDocument">patchDocument for DirectoryCategory</param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id}", Name = "PartiallyUpdateDirectoryCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PartiallyUpdateDirectoryCategory(Guid directoryId, Guid id, JsonPatchDocument<DirectoryCategoryForUpdateDTO> patchDocument)
        {
            _logger.LogInformation("PartiallyUpdateDirectoryCategory called : ");
            DirectoryCategoryForUpdateDTO dto = new DirectoryCategoryForUpdateDTO();
            DirectoryCategory category = new DirectoryCategory();

            if (!await _businessDirectoryService.ExistAsync(x => x.Id == directoryId))
            {
                return NotFound();
            }

            if (!await _directoryCategoryService.ExistAsync(x => x.Id == id))
            {
                return NotFound();
            }

            patchDocument.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(dto))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(dto, category);

            category.Id = id;

            await _directoryCategoryService.UpdatePartialEntityAsync(category, patchDocument);

            return NoContent();
        }

        #endregion

        #region HTTPDELETE

        /// <summary>
        /// Deletes the DirectoryCategory.
        /// </summary>
        /// <param name="directoryId">id of the BusinessDirectory</param>
        /// <param name="id">id if the DitectoryCategory</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteBusinessDirectoryCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBusinessDirectoryCategory(Guid directoryId, Guid id)
        {
            _logger.LogInformation("DeleteBusinessDirectoryCategory called : ");
            if (!await _businessDirectoryService.ExistAsync(x => x.Id == directoryId))
            {
                return NotFound();
            }

            if (await _directoryCategoryService.ExistAsync(x => x.Id == id))
            {
                //delete the event from the db.
                await _directoryCategoryService.DeleteEntityAsync(id);
            }
            else
            {
                //if event doesn't exists then returns not found.
                return NotFound();
            }

            return NoContent();
        }

        #endregion

    }
}
