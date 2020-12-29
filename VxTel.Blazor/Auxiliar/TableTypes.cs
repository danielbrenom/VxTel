using System.ComponentModel;

namespace VxTel.Blazor.Auxiliar
{
    public enum TableTypes
    {
        [Description("table-dark")]
        TableDark,
        [Description("stripped")]
        TableStriped,
        [Description("table-bordered")]
        TableBordered,
        [Description("table-borderless")]
        TableBorderless,
        [Description("table-hover")]
        TableHover,
        [Description("centered")]
        TableCentered,
        [Description("responsive-table")]
        TableResponsive,
        [Description("highlight")]
        TableHighlight
    }
}