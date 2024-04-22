using ToDoApp.Common.Exceptions;
using ToDoApp.Data.Services.Abstract;
using ToDoApp.Data.Constants;

namespace ToDoApp.Data.Services
{
    public class FileService : IFileService
    {
        private string FileFormatNotSupportedErrorMessage = "Format of given file is not supported!";

        public async Task<string> UploadImageFileAsync(IFormFile formFile)
        {
            IsImage(Path.GetExtension(formFile.FileName));

            long currentDateMilliseconds = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
            string directoryPath = Directory.GetCurrentDirectory() + "\\Resources\\Images";
            string filename = $"{ currentDateMilliseconds }-{ formFile.FileName }";
            string filePath = $"{ directoryPath }\\{ filename }";

            using (FileStream fs = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write))
            {
                await formFile.CopyToAsync(fs);
            }

            return filename;
        }

        public async Task DeleteImageFileAsync(string filename)
        {
            await Task.Run(() =>
            {
                string directoryPath = Directory.GetCurrentDirectory() + "\\Resources\\Images";
                string filePath = $"{directoryPath}\\{filename}";

                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            });
        }

        private void IsImage(string fileExtension)
        {
            if (!FileFormats.ImageFormats.Contains(fileExtension))
            {
                throw new BadRequestException(FileFormatNotSupportedErrorMessage);
            }
        }
    }
}
