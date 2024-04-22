namespace ToDoApp.Data.Services.Abstract
{
    public interface IFileService
    {   
        /// <summary>
        /// Uploads image file.
        /// </summary>
        /// <param name="formFile">File that must be uploaded.</param>
        /// <returns>Name of created file.</returns>
        Task<string> UploadImageFileAsync(IFormFile formFile);

        /// <summary>
        /// Deletes file from image directory by its name.
        /// </summary>
        /// <param name="filename">Name of file that must be deleted.</param>
        /// <returns></returns>
        Task DeleteImageFileAsync(string filename);
    }
}
