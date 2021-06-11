using System.IO;
using System.Threading.Tasks;

namespace TAP.StorageAccess
{
    public interface StorageContext
    {
        public Task<string> uploadAsync(Stream stream, string fileName, bool overwrite);

        public Task<bool> deleteAsync(string fileUri);
    }
}