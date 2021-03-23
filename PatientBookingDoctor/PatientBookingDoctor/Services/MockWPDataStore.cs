using PatientBookingDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientBookingDoctor.Services
{
    public class MockWPDataStore : WPDataStore<WaitingPatient>
    {
        readonly List<WaitingPatient> items;

        public MockWPDataStore()
        {
            items = new List<WaitingPatient>()
            {
                new WaitingPatient { ID = Guid.NewGuid(), RegistrationDate = "22/12/2020", PatientName = "Vũ Tuấn Hiền",ExaminationDept = "Khoa Nội", ClinicName = "PKĐK Thống Nhất"},
                new WaitingPatient { ID = Guid.NewGuid(), RegistrationDate = "22/12/2020", PatientName = "Đoàn Minh Hoàng",ExaminationDept = "Khoa Nội", ClinicName = "PKĐK Thống Nhất"},
                new WaitingPatient { ID = Guid.NewGuid(), RegistrationDate = "22/12/2020", PatientName = "Nguyễn Công Ấn",ExaminationDept = "Khoa Nội", ClinicName = "PKĐK Thống Nhất"},
                new WaitingPatient { ID = Guid.NewGuid(), RegistrationDate = "22/12/2020", PatientName = "Nguyễn Tấn Nhân",ExaminationDept = "Khoa Nội", ClinicName = "PKĐK Thống Nhất"},
                new WaitingPatient { ID = Guid.NewGuid(), RegistrationDate = "22/12/2020", PatientName = "Lê Nhật Nam",ExaminationDept = "Khoa Nội", ClinicName = "PKĐK Thống Nhất"},
            };
        }

        public async Task<bool> AddItemAsync(WaitingPatient item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(WaitingPatient item)
        {
            var oldItem = items.Where((WaitingPatient arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var oldItem = items.Where((WaitingPatient arg) => arg.ID == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<WaitingPatient> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<WaitingPatient>> GetItemsAsync(bool forceRefresh = false)
        {
            var x = await Task.FromResult(items);
            // return await Task.FromResult( items);
            return x;
        }
    }
}