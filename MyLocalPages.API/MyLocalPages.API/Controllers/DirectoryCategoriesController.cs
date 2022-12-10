using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyLocalPages.Domain;
using MyLocalPages.DTO;
using MyLocalPages.Services;

namespace MyLocalPages.API.Controllers
{
    [Route("api/BusinessDirectories/{directoryId}/DirectoryCategories")]
    [ApiController]
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

        [HttpGet]
        /// <summary>
        /// Gets the sub categories for a business category  
        /// </summary>
        /// <returns>List of business sub categories</returns>
        public async Task<ActionResult<IEnumerable<DirectoryCategoryDTO>>> GetDirectoryCategories(Guid directoryId)
        {
            if (!await _businessDirectoryService.ExistAsync(x => x.Id == directoryId))
            {
                return NotFound();
            }

            var categories = _mapper.Map<List<DirectoryCategoryDTO>>((await _directoryCategoryService.GetAllEntitiesAsync()).Where(x => x.BusinessDirectoryId == directoryId));

            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}", Name = "GetBusinessCategory")]
        /// <summary>
        /// get the business sub category info
        /// </summary>
        /// <param name="id">unique identifier for the sub category</param>
        /// <returns></returns>
        public async Task<ActionResult<DirectoryCategoryDTO>> GetBusinessCategory(Guid directoryId, Guid id)
        {

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

        [HttpPost]
        /// <summary>
        /// creates business directory category
        /// </summary>
        /// <param name="businessDirectory">BusinessDirectoryCategory creation model</param>
        /// <returns>BusinessDirectoryCategoryResposne Model</returns>
        public async Task<ActionResult<DirectoryCategoryDTO>> CreateBusinessDirectoryCategory(Guid directoryId,
            DirectoryCategoryForCreationDTO directoryCategoryForCreationDTO)
        {
            if (!await _businessDirectoryService.ExistAsync(x => x.Id == directoryId))
            {
                return NotFound();
            }

            directoryCategoryForCreationDTO.BusinessDirectoryId = directoryId;
            var categoryToReturn = await _directoryCategoryService.
                    CreateEntityAsync<DirectoryCategoryDTO, DirectoryCategoryForCreationDTO>(directoryCategoryForCreationDTO);
            return CreatedAtRoute("GetBusinessCategory", new { directoryId, categoryToReturn.Id }, categoryToReturn);
        }

        #endregion

        #region HTTPPUT

        [HttpPut]
        [Route("{id}", Name = "GetBusinessCategory")]
        /// <summary>
        /// updates business directory category
        /// </summary>
        /// <param name="businessDirectory">BusinessDirectoryCategory update model</param>
        /// <returns>BusinessDirectoryCategoryResposne Model</returns>
        public async Task<ActionResult> UpdateBusinessDirectoryCategory(Guid directoryId, Guid id, DirectoryCategoryForUpdateDTO directoryCategoryForUpdateDTO)
        {
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

        [HttpPatch]
        [Route("{id}", Name = "PartiallyUpdateBusinessDirectoryCategory")]
        /// <summary>
        /// partially updates business directory category
        /// </summary>
        /// <param name="businessDirectory">BusinessDirectoryCategory update model</param>
        /// <returns>BusinessDirectoryCategoryResposne Model</returns>
        public async Task<ActionResult> PartiallyUpdateBusinessDirectoryCategory(Guid directoryId, Guid id, JsonPatchDocument<DirectoryCategoryForUpdateDTO> patchDocument)
        {
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

            //map the changes from dto to entity.
            _mapper.Map(dto, category);

            category.Id = id;

            //partially update the changes to the db. 
            await _directoryCategoryService.UpdatePartialEntityAsync(category, patchDocument);

            return NoContent();
        }

        #endregion

        #region HTTPDELETE

        /// <summary>
        /// Deletes the business directory category.
        /// </summary>
        /// <param name="directoryId">Unique identifier business directory</param>
        /// <param name="id">Unique indetifier for directory category</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteBusinessDirectoryCategory")]
        public async Task<ActionResult> DeleteBusinessDirectoryCategory(Guid directoryId, Guid id)
        {
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
