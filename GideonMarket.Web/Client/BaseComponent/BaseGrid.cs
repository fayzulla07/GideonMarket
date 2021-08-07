﻿using GideonMarket.Web.Client.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

  
namespace GideonMarket.Web.Client.BaseComponent
{
    public class BaseGrid<T>  : ComponentBase where T : class
    {
        [Inject]
        public NotificationService NotificationService { get; set; }
        [Inject]
        public IAppService client { get; set; }
        
        public RadzenDataGrid<T> Grid { get; set; }
        public List<T> Data { get; set; } = new List<T>();
        private T currentEditingData = default(T);
        private T currentSelectData = default(T);
        public int Count { get; set; }
        public string RemotePath { get; set; }

      
        public void RowDoubleClickHandler(DataGridRowMouseEventArgs<T> entity)
        {
            SaveRow();
            currentEditingData = entity.Data;
            Grid.EditRow(currentEditingData);
        }
        public void RowClickHandler(T entity)
        {
            SaveRow();
            currentSelectData = entity;
           
        }

        public async Task GetData()
        {
            Data = await client.GetAsync<List<T>>(RemotePath);
            Count = Data.Count;
        }
        public async virtual void OnCreateRow(T entity)
        {
            try
            {
                int id = await client.PostAsync<int>(entity, RemotePath);
                entity.GetType().GetProperty("Id").SetValue(entity, id, null);
                NotificationService.Notify(NotificationSeverity.Info, "Успешно", "Успешно создано!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                NotificationService.Notify(NotificationSeverity.Info, "Ошибка", "Что-то пошло не так");
            }
            
        }

        public async virtual void OnUpdateRow(T entity)
        {
            try
            {
                int id = (int)entity.GetType().GetProperty("Id").GetValue(entity);
                await client.UpdateAsync<T>(entity, id, RemotePath);
                NotificationService.Notify(NotificationSeverity.Success, "Успешно", "Успешно обновлено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                NotificationService.Notify(NotificationSeverity.Info, "Ошибка", "Что-то пошло не так");
            }
            
        }
        public async virtual void OnDeleteRow(T entity)
        {
            try
            {
                int id = (int)entity.GetType().GetProperty("Id").GetValue(entity);
                await client.DeleteAsync(id, $"api/{nameof(T)}");
                NotificationService.Notify(NotificationSeverity.Warning, "Успешно", "Успешно удалено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                NotificationService.Notify(NotificationSeverity.Info, "Ошибка", "Что-то пошло не так");
            }
            
        }
        public void SaveRow()
        {
            if (currentEditingData != null)
            {
                
                Grid.UpdateRow(currentEditingData);
                currentEditingData = null;
            }
           
        }

        public void CancelEdit()
        {
            Grid.CancelEditRow(currentEditingData);
            currentEditingData = null;
        }

        public void DeleteRow()
        {
            Data.Remove(currentSelectData);
            OnDeleteRow(currentSelectData);
            Grid.Reload();
        }

        public void InsertRow()
        {
            var data = Activator.CreateInstance<T>();
            currentEditingData = data;
            Grid.InsertRow(data);
        }

        public void KeyPressed(KeyboardEventArgs e)
        {
            bool hotKeyEnter = e.Code.Contains("Enter");

            if (hotKeyEnter && e.Code.Contains(""))
            {
              //  SaveRow();
            }
        }

    }
}
