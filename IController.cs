using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public interface IController<T>
    {
        void RegisterCommand(T input, ICommand command);
        void Update(GameTime gameTime);
    }
}
