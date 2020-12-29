using Microsoft.AspNetCore.Components;

namespace VxTel.Blazor.Auxiliar
{
    public class TableAction<T>
    {
        public EventCallback<T> Action { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
    }
}