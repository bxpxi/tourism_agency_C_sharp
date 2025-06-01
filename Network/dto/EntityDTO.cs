using System;
using Network.utils;

namespace Network.dto
{
    [Serializable]
    public class EntityDTO : IStringifiable
    {
        public int Id {get;set;}
    }
}