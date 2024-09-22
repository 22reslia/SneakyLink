using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class PreviousBlockCommand : ICommand
    {
        private Block block;

        public PreviousBlockCommand(Block block)
        {
            this.block = block;
        }

        public void Execute()
        {
            block.PreviousImage();
        }
    }
}
