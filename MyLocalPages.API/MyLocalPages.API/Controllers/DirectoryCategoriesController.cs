using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyLocalPages.Domain;
using MyLocalPages.DTO;
using MyLocalPages.Services;
using MyLocalPages.Utils;
using Newtonsoft.Json;

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
        [HttpGet(Name = "GetFilteredDirectoryCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DirectoryCategoryDTO>>> GetFilteredDirectoryCategories(Guid directoryId, [FromQuery] FilterOptionsModel filterOptionsModel)
        {
            _logger.LogInformation("GetDirectoryCategories called : ");

            if (!_directoryCategoryService.ValidMappingExists(filterOptionsModel.OrderBy))
            {
                return BadRequest();
            }

            if (!MyLocalPagesUtils.TypeHasProperties<DirectoryCategoryDTO>(filterOptionsModel.Fields))
            {
                return BadRequest();
            }

            if (!await _businessDirectoryService.ExistAsync(x => x.Id == directoryId))
            {
                return NotFound();
            }

            filterOptionsModel.SearchQuery += $"BusinessDirectoryId == \"{directoryId}\"";
            var directoryCategory = await _directoryCategoryService.GetFilteredEntities(filterOptionsModel);


            var previousPageLink = directoryCategory.HasPrevious ?
                   CreateEventsResourceUri(filterOptionsModel, ResourceUriType.PreviousPage) : null;

            var nextPageLink = directoryCategory.HasNext ?
                CreateEventsResourceUri(filterOptionsModel, ResourceUriType.NextPage) : null;

            //prepare the pagination metadata.
            var paginationMetadata = new
            {
                previousPageLink,
                nextPageLink,
                totalCount = directoryCategory.TotalCount,
                pageSize = directoryCategory.PageSize,
                currentPage = directoryCategory.CurrentPage,
                totalPages = directoryCategory.TotalPages
            };

            //add pagination meta data to response header.
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

            return Ok(directoryCategory);
        }

        /// <summary>
        /// Gets the DirectoryCategory info by id.
        /// </summary>
        /// <param name="directoryId">id of the BusinessDirectory</param>
        /// <param name="id">id of the DirectoryCategory</param>
        /// <param name="fields">comma seperated fields to return for the DirectoryCategory</param>
        /// <returns>DirectoryCategory info</returns>
        [HttpGet]
        [Route("{id}", Name = "GetDirectoryCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DirectoryCategoryDTO>> GetDirectoryCategory(Guid directoryId, Guid id, string? fields)
        {
            _logger.LogInformation("GetDirectoryCategory called : ");
            object directoryCategory;

            if (!MyLocalPagesUtils.TypeHasProperties<DirectoryCategoryDTO>(fields))
            {
                return BadRequest();
            }

            if (!await _businessDirectoryService.ExistAsync(x => x.Id == directoryId))
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(fields))
            {
                directoryCategory = _mapper.Map<DirectoryCategoryDTO>(await _directoryCategoryService.GetEntityByIdAsync(id));
            }
            else
            {
                directoryCategory = await _directoryCategoryService.GetPartialEntityAsync(id, fields);
            }
               
            if (directoryCategory == null)
            {
                return NotFound();
            }

            return Ok(directoryCategory);
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

        #region PRIVATE METHODS

        private string CreateEventsResourceUri(FilterOptionsModel filterOptionsModel, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetFilteredDirectoryCategories",
                      new
                      {
                          fields = filterOptionsModel.Fields,
                          orderBy = filterOptionsModel.OrderBy,
                          searchQuery = filterOptionsModel.SearchQuery,
                          pageNumber = filterOptionsModel.PageNumber - 1,
                          pageSize = filterOptionsModel.PageSize
                      })!;
                case ResourceUriType.NextPage:
                    return Url.Link("GetFilteredDirectoryCategories",
                      new
                      {
                          fields = filterOptionsModel.Fields,
                          orderBy = filterOptionsModel.OrderBy!,
                          searchQuery = filterOptionsModel.SearchQuery!,
                          pageNumber = filterOptionsModel.PageNumber + 1,
                          pageSize = filterOptionsModel.PageSize
                      })!;

                default:
                    return Url.Link("GetFilteredDirectoryCategories",
                    new
                    {
                        fields = filterOptionsModel.Fields,
                        orderBy = filterOptionsModel.OrderBy,
                        searchQuery = filterOptionsModel.SearchQuery,
                        pageNumber = filterOptionsModel.PageNumber,
                        pageSize = filterOptionsModel.PageSize
                    })!;
            }
        }

        #endregion
    }
}
