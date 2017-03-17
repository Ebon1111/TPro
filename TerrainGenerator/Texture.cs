using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainGenerator
{
    class Texture : GameComponent
    {
        public Texture(Game game, String type, GraphicsDevice device) 
            : base(game)
        {
        }
    }
}
