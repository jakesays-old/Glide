////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace Glide.DeviceSupport
{
	internal class TouchCollector
    {
        public TouchCollector()
        {
        }

        TimeSpan lastTime = TimeSpan.Zero;

        internal void SetBuffer(uint bufferSize)
        {
            if (TouchCollectorConfiguration.CollectionMethod == CollectionMethod.Managed)
            {
            }
            else if (TouchCollectorConfiguration.CollectionMethod == CollectionMethod.Native)
            {
                // Not needed at this moment, we are using static buffer.
                // TouchCollectorConfiguration.SetNativeBufferSize(bufferSize, bufferSize);
                _nativeBufferSize = bufferSize;
            }
        }

        private uint _nativeBufferSize = 200;
    }
}


