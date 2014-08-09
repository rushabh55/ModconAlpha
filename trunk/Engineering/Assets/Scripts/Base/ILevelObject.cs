using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Base
{
    interface ILevelObject
    {
        void InitializePosition();
        void Explode();
        void LevelEnd();

    }
}
