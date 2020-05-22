using System;
using System.Threading.Tasks;
namespace Kursach_AL
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
