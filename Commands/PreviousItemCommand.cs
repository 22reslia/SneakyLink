using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class PreviousItemCommand : ICommand
    {
        private Item item;

        public PreviousItemCommand(Item item)
        {
            this.item = item;
        }

        public void Execute()
        {
            item.PreviousImage();
        }
    }
}
