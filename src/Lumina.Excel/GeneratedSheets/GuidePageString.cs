// ReSharper disable All

using Lumina.Text;
using Lumina.Data;
using Lumina.Data.Structs.Excel;

namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "GuidePageString", columnHash: 0xb0d02604 )]
    public partial class GuidePageString : ExcelRow
    {
        
        public SeString String { get; set; }
        
        public override void PopulateData( RowParser parser, GameData gameData, Language language )
        {
            base.PopulateData( parser, gameData, language );

            String = parser.ReadColumn< SeString >( 0 );
        }
    }
}