using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingDoctor.Services
{
    interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
