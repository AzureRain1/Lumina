// ReSharper disable All

using Lumina.Text;
using Lumina.Data;
using Lumina.Data.Structs.Excel;

namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "EurekaAethernet", columnHash: 0x4e043d72 )]
    public partial class EurekaAethernet : ExcelRow
    {
        
        public LazyRow< PlaceName > Location { get; set; }
        
        public override void PopulateData( RowParser parser, GameData gameData, Language language )
        {
            base.PopulateData( parser, gameData, language );

            Location = new LazyRow< PlaceName >( gameData, parser.ReadColumn< ushort >( 0 ), language );
        }
    }
}