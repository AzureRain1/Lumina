using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lumina;
using Lumina.Models.Models;

namespace SaintCoinach.Graphics.Sgb {

    public class SgbGroup1CEntry : ISgbGroupEntry {
        [StructLayout(LayoutKind.Sequential)]
        public struct HeaderData {
            public uint Unk;
            public uint Unk2;
            public int NameOffset;
            public uint Index;
            public uint Unk3;
            public int ModelFileOffset;
        }

        SgbGroupEntryType ISgbGroupEntry.Type { get { return (SgbGroupEntryType)0xFF; } }
        public HeaderData Header { get; private set; }
        public string Name { get; private set; }
        public Model Model { get; private set; }
        public Sgb.SgbFile Gimmick { get; private set; }

        public SgbGroup1CEntry(GameData luminaData, byte[] buffer, int offset) {
            this.Header = buffer.ToStructure<HeaderData>(offset);
            this.Name = buffer.ReadString(offset + Header.NameOffset + 9);

            var mdlFilePath = buffer.ReadString(offset + Header.ModelFileOffset + 9);
            if (!string.IsNullOrWhiteSpace(mdlFilePath)) {
                if (mdlFilePath.Contains(".mdl")) {
                    if( luminaData.FileExists( mdlFilePath ) )
                        this.Model = new Model( luminaData, mdlFilePath );
                }
                else if (mdlFilePath.Contains(".sgb")) {
                    if ( luminaData.FileExists( mdlFilePath ) )
                    {
                        var rawData = luminaData.GetFile( mdlFilePath )?.Data;
                        if (rawData != null) this.Gimmick = new Sgb.SgbFile(luminaData, rawData );
                    }
                }
            }
        }
    };
}
