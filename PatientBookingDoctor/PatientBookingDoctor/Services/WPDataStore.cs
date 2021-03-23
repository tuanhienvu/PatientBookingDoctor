﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientBookingDoctor.Services
{
    public interface WPDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(Guid id);
        Task<T> GetItemAsync(Guid id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = true);
    }
}
