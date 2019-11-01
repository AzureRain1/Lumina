﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lumina.Example
{
    class Program
    {
        private class CustomFileType : Data.FileResource
        {
            public Dictionary< string, int > ExdMap;

            public int Version { get; private set; }

            public CustomFileType()
            {
                ExdMap = new Dictionary< string, int >();
            }

            public override void LoadFile()
            {
                var stream = DataSections[ 0 ];
                using var sr = new StreamReader( stream );

                // read version
                var header = sr.ReadLine().Split( ',' );
                if( header[ 0 ] != "EXLT" )
                {
                    throw new Exception( "invalid file format or something :(" );
                }

                Version = int.Parse( header[ 1 ] );

                // read exd mappings
                string row;
                while( ( row = sr.ReadLine() ) != null )
                {
                    var data = row.Split( ',' );
                    var id = int.Parse( data[ 1 ] );

                    ExdMap[ data[ 0 ] ] = id;
                }
            }
        }

        static void Main( string[] args )
        {
            var lumina = new Lumina( args[ 0 ] );

            var file = lumina.GetFile( "exd/root.exl" );

            file.SaveFile( "root.exl" );

            // custom data type
            var file2 = lumina.GetFile< CustomFileType >( "exd/root.exl" );
            var aetheryte = file2.ExdMap.First( m => m.Key == "Aetheryte" );

            Console.WriteLine( $"aetheryte: id: {aetheryte.Value} name: {aetheryte.Key}" );
        }
    }
}