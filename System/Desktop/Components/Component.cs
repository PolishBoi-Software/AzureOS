using System;
using Cosmos.System.Graphics;

namespace PBOS.System.Core.Desktop.Components
{
    public abstract class Component
    {
        public abstract int X { get; set; }
        public abstract int Y { get; set; }

        /// <summary>
        /// Used for logic (such as checking mouse coordinates, etc)
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Used to actually show the component in the desktop, this will also call <see cref="Update"/>
        /// </summary>
        public abstract void Display();
    }
}