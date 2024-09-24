using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class NextItemCommand : ICommand
    {
        private Item item;

        public NextItemCommand(Item item)
        {
            this.item = item;
        }

        public void Execute()
        {
            item.NextImage();
        }
    }
}
