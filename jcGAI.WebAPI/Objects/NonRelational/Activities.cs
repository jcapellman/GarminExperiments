using jcGAI.WebAPI.Objects.NonRelational.Base;

namespace jcGAI.WebAPI.Objects.NonRelational
{
    public class Activities : BaseNonRelational
    {
        public byte[] GpxFileData { get; set; }

        public Activities()
        {
            GpxFileData = Array.Empty<byte>();
        }
    }
}