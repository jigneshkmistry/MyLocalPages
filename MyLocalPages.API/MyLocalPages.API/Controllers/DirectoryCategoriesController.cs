using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyLocalPages.DTO.BusinessCategory;
using MyLocalPages.DTO.BusinessDirectory;
using System.Xml.XPath;

namespace MyLocalPages.API.Controllers
{
    [Route("api/BusinessDirectories/{directoryId}/DirectoryCategories")]
    [ApiController]
    public class DirectoryCategoriesController : ControllerBase
    {

        #region PRIVATE MEMBERS

        private readonly MyLocalPagesDataStore _myLocalPagesDataStore;

        #endregion

        #region CONSTRUCTOR

        public DirectoryCategoriesController(MyLocalPagesDataStore myLocalPagesDataStore)
        {
            _myLocalPagesDataStore = myLocalPagesDataStore;
        }

        #endregion

        #region HTTPGET

        [HttpGet]
        /// <summary>
        /// Gets the sub categories for a business category  
        /// </summary>
        /// <returns>List of business sub categories</returns>
        public ActionResult<IEnumerable<DirectoryCategoryDTO>> GetDirectoryCategories(string directoryId)
        {
            var directory = _myLocalPagesDataStore.BusinessDirectories.FirstOrDefault(x => x.Id == directoryId);

            if (directory == null)
            {
                return NotFound();
            }

            return Ok(directory.Categories);
        }

        [HttpGet]
        [Route("{id}", Name = "GetBusinessCategory")]
        /// <summary>
        /// get the business sub category info
        /// </summary>
        /// <param name="id">unique identifier for the sub category</param>
        /// <returns></returns>
        public ActionResult<DirectoryCategoryDTO> GetBusinessCategory(string directoryId, string id)
        {
            var directory = _myLocalPagesDataStore.BusinessDirectories.FirstOrDefault(x => x.Id == directoryId);

            if (directory == null)
            {
                return NotFound();
            }

            var category = directory.Categories.FirstOrDefault(x => x.Id == id);

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
        public ActionResult<DirectoryCategoryDTO> CreateBusinessDirectoryCategory(string directoryId, DirectoryCategoryForCreationDTO directoryCategoryForCreationDTO)
        {

            var directory = _myLocalPagesDataStore.BusinessDirectories.FirstOrDefault(x => x.Id == directoryId);

            if (directory == null)
            {
                return NotFound();
            }

            var directoryCategoryDTO = new DirectoryCategoryDTO()
            {
                Id = Guid.NewGuid().ToString(),
                Name = directoryCategoryForCreationDTO.Name
            };

            directory.Categories.Add(directoryCategoryDTO);

            return CreatedAtRoute("GetBusinessCategory", new { directoryId, directoryCategoryDTO.Id }, directoryCategoryDTO);
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
        public ActionResult UpdateBusinessDirectoryCategory(string directoryId,string id, DirectoryCategoryForUpdateDTO directoryCategoryForUpdateDTO)
        {
            var directory = _myLocalPagesDataStore.BusinessDirectories.FirstOrDefault(x => x.Id == directoryId);

            if (directory == null)
            {
                return NotFound();
            }

            var category = directory.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = directoryCategoryForUpdateDTO.Name;

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
        public ActionResult PartiallyUpdateBusinessDirectoryCategory(string directoryId, string id, JsonPatchDocument<DirectoryCategoryForUpdateDTO> patchDocument)
        {
            var directory = _myLocalPagesDataStore.BusinessDirectories.FirstOrDefault(x => x.Id == directoryId);

            if (directory == null)
            {
                return NotFound();
            }

            var category = directory.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            DirectoryCategoryForUpdateDTO directoryCategoryToPatch = new DirectoryCategoryForUpdateDTO()
            {
                Name = category.Name
            };

            patchDocument.ApplyTo(directoryCategoryToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(directoryCategoryToPatch))
            {
                return BadRequest(ModelState);
            }

            category.Name = directoryCategoryToPatch.Name;

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
        [HttpDelete("{id}",Name = "DeleteBusinessDirectoryCategory")]
        public ActionResult DeleteBusinessDirectoryCategory(string directoryId, string id)
        {
            var directory = _myLocalPagesDataStore.BusinessDirectories.FirstOrDefault(x => x.Id == directoryId);

            if (directory == null)
            {
                return NotFound();
            }

            var category = directory.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            directory.Categories.Remove(category);
            
            return NoContent();
        }

        #endregion

    }
}
