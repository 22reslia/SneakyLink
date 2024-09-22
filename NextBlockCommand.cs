using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class NextBlockCommand : ICommand
    {
        private Block block;

        public NextBlockCommand(Block block)
        {
            this.block = block;
        }

        public void Execute()
        {
            block.NextImage();
        }
    }
}
