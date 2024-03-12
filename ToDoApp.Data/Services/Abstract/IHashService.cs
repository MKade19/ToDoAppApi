namespace ToDoApp.Data.Services.Abstract
{
    public interface IHashService
    {
        /// <summary>
        /// Generates hash of the given string and salt for the hash.
        /// </summary>
        /// <param name="stringToHash">String that should be converted to hash.</param>
        /// <param name="salt">Output parameter of generated salt.</param>
        /// <returns>Hash of the given string.</returns>
        string GetHash(string stringToHash, out byte[] salt);

        /// <summary>
        /// Verifies whether string matches with given hash or not.
        /// </summary>
        /// <param name="stringToCompare">Normal string to compare with the hashed one.</param>
        /// <param name="hashedString">Hashed string.</param>
        /// <param name="salt">Salt of password.</param>
        /// <returns>True if string matches with hash, false if it doesn't.</returns>
        bool VerifyHash(string stringToCompare, string hashedString, byte[] salt);
    }
}
