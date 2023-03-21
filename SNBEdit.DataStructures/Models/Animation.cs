using System.Collections.Generic;

namespace SNBEdit.DataStructures.Models
{
    public class Animation
    {
        public List<AnimationFrame> Frames { get; private set; }

        public Animation()
        {
            Frames = new List<AnimationFrame>();
        }
    }
}