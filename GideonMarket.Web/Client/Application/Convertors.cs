/// <summary>
/// Извлнеает название из виюв модел например: UnitViewModel = > Unit предполагается что это назание контроллера
/// </summary>
using System;
namespace GideonMarket.Web.Client.Application
{
    public static class Convertors
    {
        public static string GetViewModelName<T>(T obj)
        {
            string str = nameof(obj);
            int indx = str.IndexOf("ViewModel");
            return  str.Substring(0, indx);
        }
    }
}
