﻿using Plugins.AudioService.Services.ID.Core;

namespace Plugins.AudioService.Services.ID
{
    public class IDService : IIDService
    {
        private int _id = -1;

        public int Get() => ++_id;
    }
}