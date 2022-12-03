using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyLocalPages.DTO.BusinessCategory;
using MyLocalPages.DTO.BusinessDirectory;
using System.IO;

namespace MyLocalPages.API.Controllers
{
    [Route("api/BusinessDirectories")]
    [ApiController]
    public class BusinessDirectoriesController : ControllerBase
    {

        #region PRIVATE MEMBERS

        #endregion

        #region CONSTRUCTOR

        public BusinessDirectoriesController()
        {

        }

        #endregion

        #region HTTPGET

        [HttpGet]
        /// <summary>
        /// Gets the business directories 
        /// </summary>
        /// <returns>List of business directories</returns>
        public ActionResult<IEnumerable<DirectoryCategoryDTO>> GetBusinessDirectories()
        {
            return Ok(MyLocalPagesDataStore.Current.BusinessDirectories);
        }

        [HttpGet]
        [Route("{id}", Name = "GetBusinessDirectory")]
        /// <summary>
        /// get the business category info
        /// </summary>
        /// <param name="id">unique identifier for the category</param>
        /// <returns></returns>
        public ActionResult<DirectoryCategoryDTO> GetBusinessDirectory(string id)
        {
            var category = MyLocalPagesDataStore.Current.BusinessDirectories.FirstOrDefault(x => x.Id == id);

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
        /// creates business directory
        /// </summary>
        /// <param name="businessDirectory">BusinessDirectory creation model</param>
        /// <returns>BusinessDirectoryResposne Model</returns>
        public ActionResult<BusinessDirectoryDTO> CreateBusinessDirectory(BusinessDirectoryForCreationDTO businessDirectoryForCreationDTO)
        {
            var businessDirectory = new BusinessDirectoryDTO()
            {
                Id = Guid.NewGuid().ToString(),
                Name = businessDirectoryForCreationDTO.Name
            };

            MyLocalPagesDataStore.Current.BusinessDirectories.Add(businessDirectory);
            
            return CreatedAtRoute("GetBusinessDirectory", new { businessDirectory.Id }, businessDirectory);
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
        public ActionResult UpdateBusinessDirectory(string id, BusinessDirectoryForUpdateDTO businessDirectoryForUpdateDTO)
        {
            var directory = MyLocalPagesDataStore.Current.BusinessDirectories.FirstOrDefault(x => x.Id == id);

            if (directory == null)
            {
                return NotFound();
            }

            directory.Name = businessDirectoryForUpdateDTO.Name;

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
        public ActionResult PartiallyUpdateBusinessDirectory(string id, JsonPatchDocument<BusinessDirectoryForUpdateDTO> patchDocument)
        {
            var directory = MyLocalPagesDataStore.Current.BusinessDirectories.FirstOrDefault(x => x.Id == id);

            if (directory == null)
            {
                return NotFound();
            }

            BusinessDirectoryForUpdateDTO directoryToPatch = new BusinessDirectoryForUpdateDTO()
            {
                Name = directory.Name
            };

            patchDocument.ApplyTo(directoryToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(directoryToPatch))
            {
                return BadRequest(ModelState);
            }

            directory.Name = directoryToPatch.Name;

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
        public ActionResult DeleteBusinessDirectory(string id)
        {
            var directory = MyLocalPagesDataStore.Current.BusinessDirectories.FirstOrDefault(x => x.Id == id);

            if (directory == null)
            {
                return NotFound();
            }

            MyLocalPagesDataStore.Current.BusinessDirectories.Remove(directory);

            return NoContent();
        }

        #endregion
    }
}
