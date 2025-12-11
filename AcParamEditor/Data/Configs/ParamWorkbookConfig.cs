using AcParamEditor.Configuration;
using SoulsFormats;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace AcParamEditor.Data.Configs
{
    /// <inheritdoc/>
    [JsonSourceGenerationOptions(WriteIndented = true,
        GenerationMode = JsonSourceGenerationMode.Metadata,
        IncludeFields = true,
        UseStringEnumConverter = true)]
    [JsonSerializable(typeof(ParamWorkbookConfig))]
    public partial class ParamWorkbookConfigSerializerContext : JsonSerializerContext
    {
    }

    /// <summary>
    /// A config json for importing params.
    /// </summary>
    public class ParamWorkbookConfig
    {
        /// <summary>
        /// The params contained within this config.
        /// </summary>
        public List<ParamSheet> Params { get; set; }

        /// <summary>
        /// Create a new <see cref="ParamWorkbookConfig"/> with the specified param capacity.
        /// </summary>
        public ParamWorkbookConfig(int paramCapacity)
        {
            Params = new List<ParamSheet>(paramCapacity);
        }

        /// <summary>
        /// Create a new and empty <see cref="ParamWorkbookConfig"/>.
        /// </summary>
        public ParamWorkbookConfig() : this(0) { }

        #region IO

        /// <summary>
        /// Loads an <see cref="ParamWorkbookConfig"/> from the specified path.
        /// </summary>
        /// <param name="path">The path to load an <see cref="ParamWorkbookConfig"/> from.</param>
        /// <returns>A newly read <see cref="ParamWorkbookConfig"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ParamWorkbookConfig Load(string path)
            => DataConfigLoader.Load(path, ParamWorkbookConfigSerializerContext.Default.ParamWorkbookConfig);

        /// <summary>
        /// Saves this <see cref="ParamWorkbookConfig"/> to the specified path.
        /// </summary>
        /// <param name="path">The path to save this <see cref="ParamWorkbookConfig"/> to.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Save(string path)
            => DataConfigLoader.Save(this, path, ParamWorkbookConfigSerializerContext.Default.ParamWorkbookConfig);

        /// <summary>
        /// Loads an <see cref="ParamWorkbookConfig"/> from the specified path.
        /// </summary>
        /// <param name="path">The path to load an <see cref="ParamWorkbookConfig"/> from.</param>
        /// <param name="config">A newly read <see cref="ParamWorkbookConfig"/>.</param>
        /// <returns>Whether or not the <see cref="ParamWorkbookConfig"/> could be loaded.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryLoad(string path, [NotNullWhen(true)] out ParamWorkbookConfig? config)
            => DataConfigLoader.TryLoad(path, ParamWorkbookConfigSerializerContext.Default.ParamWorkbookConfig, out config);

        #endregion

        #region Param Sheet

        /// <summary>
        /// A sheet representing a single param's configuration.
        /// </summary>
        public class ParamSheet
        {
            /// <summary>
            /// The name of the sheet; Used to find the right workbook sheet.
            /// </summary>
            public string SheetName { get; set; }

            /// <summary>
            /// The name of the param.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The extension of the param.
            /// </summary>
            public string Extension { get; set; }

            /// <summary>
            /// The type of the param; Used to find the paramdef.
            /// </summary>
            public string ParamType { get; set; }

            /// <summary>
            /// Whether or not the param is big endian.
            /// </summary>
            public bool BigEndian { get; set; }

            /// <summary>
            /// The first set of flags in the param.
            /// </summary>
            public PARAM.FormatFlags1 Flags1 { get; set; }

            /// <summary>
            /// The second set of flags in the param.
            /// </summary>
            public PARAM.FormatFlags2 Flags2 { get; set; }

            /// <summary>
            /// The paramdef format version.
            /// </summary>
            public byte ParamdefFormatVersion { get; set; }

            /// <summary>
            /// The paramdef data revision.
            /// </summary>
            public byte ParamdefDataVersion { get; set; }

            /// <summary>
            /// Unknown.
            /// </summary>
            public short Unk06 { get; set; }

            /// <summary>
            /// Whether or not rows have headers.
            /// </summary>
            public bool HeaderlessRows { get; set; }

            /// <summary>
            /// Whether or not rows have names; Ignored when <see cref="HeaderlessRows"/> is <see cref="true"/>.
            /// </summary>
            public bool NamelessRows { get; set; }

            /// <summary>
            /// Creates a new <see cref="ParamSheet"/> with the specified param type.
            /// </summary>
            public ParamSheet(string sheetName, string name, string extension, string paramType)
            {
                SheetName = sheetName;
                Name = name;
                Extension = extension;
                ParamType = paramType;
            }
        }

        #endregion
    }
}
