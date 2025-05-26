using SoulsFormats;

namespace ACParamEditor
{
    public class ParamDefInfo
    {
        public string Name { get; set; }
        public PARAMDEF Def { get; set; }

        public ParamDefInfo(string name, PARAMDEF def)
        {
            Name = name;
            Def = def;
        }
    }
}
