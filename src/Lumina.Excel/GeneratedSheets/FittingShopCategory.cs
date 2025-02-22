// ReSharper disable All

using Lumina.Text;
using Lumina.Data;
using Lumina.Data.Structs.Excel;

namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "FittingShopCategory", columnHash: 0xc0d62405 )]
    public partial class FittingShopCategory : ExcelRow
    {
        
        public byte Unknown0 { get; set; }
        public SeString Unknown1 { get; set; }
        
        public override void PopulateData( RowParser parser, GameData gameData, Language language )
        {
            base.PopulateData( parser, gameData, language );

            Unknown0 = parser.ReadColumn< byte >( 0 );
            Unknown1 = parser.ReadColumn< SeString >( 1 );
        }
    }
}