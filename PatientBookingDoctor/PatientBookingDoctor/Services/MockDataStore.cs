using PatientBookingDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientBookingDoctor.Services
{
    public class MockDataStore : IDataStore<MenuItems>
    {
        readonly List<MenuItems> items;

        public MockDataStore()
        {
            items = new List<MenuItems>()
            {
                new MenuItems { Id = Guid.NewGuid().ToString(), Title = "BN chờ khám", TargetItem =""},
                new MenuItems { Id = Guid.NewGuid().ToString(), Title = "Lịch Khám bệnh", TargetItem ="" },
                new MenuItems { Id = Guid.NewGuid().ToString(), Title = "Nhật ký nhận bệnh", TargetItem ="" },
                new MenuItems { Id = Guid.NewGuid().ToString(), Title = "Danh sách khám bệnh mới", TargetItem ="" },
                new MenuItems { Id = Guid.NewGuid().ToString(), Title = "Bản tin", TargetItem ="" },
                new MenuItems { Id = Guid.NewGuid().ToString(), Title = "Thông tin cá nhân", TargetItem ="" },
                new MenuItems { Id = Guid.NewGuid().ToString(), Title = "Hướng dẫn sử dụng", TargetItem ="AboutPage" },
                new MenuItems { Id = Guid.NewGuid().ToString(), Title = "Đăng xuất", TargetItem = "LoginPage" }
            };
        }

        public async Task<bool> AddItemAsync(MenuItems items)
        {
            this.items.Add(items);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(MenuItems items)
        {
            var oldItem = this.items.Where((MenuItems arg) => arg.Id == items.Id).FirstOrDefault();
            this.items.Remove(oldItem);
            this.items.Add(items);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((MenuItems arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<MenuItems> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<MenuItems>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}