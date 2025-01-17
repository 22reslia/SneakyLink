﻿using Microsoft.Xna.Framework;

namespace SneakyLink.Collision
{
    public enum CollisionType { None, Left, Right, Top, Bottom, Item }
    public enum CollisionObjectType { Player, Enemy, Block, Sand, Stair, Box, roomItem, Projectile };

    public interface ICollision
    {
        CollisionObjectType ObjectType { get; }
    }
}
