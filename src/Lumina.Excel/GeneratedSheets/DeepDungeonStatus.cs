// ReSharper disable All

using Lumina.Text;
using Lumina.Data;
using Lumina.Data.Structs.Excel;

namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "DeepDungeonStatus", columnHash: 0xa64a4cec )]
    public partial class DeepDungeonStatus : ExcelRow
    {
        
        public LazyRow< ScreenImage > ScreenImage { get; set; }
        public LazyRow< LogMessage > LogMessage { get; set; }
        public LazyRow< DeepDungeonFloorEffectUI > Name { get; set; }
        
        public override void PopulateData( RowParser parser, GameData gameData, Language language )
        {
            base.PopulateData( parser, gameData, language );

            ScreenImage = new LazyRow< ScreenImage >( gameData, parser.ReadColumn< ushort >( 0 ), language );
            LogMessage = new LazyRow< LogMessage >( gameData, parser.ReadColumn< ushort >( 1 ), language );
            Name = new LazyRow< DeepDungeonFloorEffectUI >( gameData, parser.ReadColumn< ushort >( 2 ), language );
        }
    }
}