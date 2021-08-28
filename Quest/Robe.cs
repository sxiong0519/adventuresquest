using System.Collections.Generic;

namespace Quest
{
    public class Robe 
    {
        public List<string> ColorOfTheRobe = new List<string>();
        public int Length { get; set; }
        
        public Robe()
        {
            ColorOfTheRobe = new List<string>{"midnight sky", "blue"};
            Length = 14;
        }
    }
}