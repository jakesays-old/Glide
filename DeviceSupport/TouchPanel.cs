////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Runtime.CompilerServices;

namespace Glide.DeviceSupport
{
    public class TouchPanel
    {

        public bool Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                EnableInternal(value);
                _enabled = value;
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void SetCalibration(int cCalibrationPoints,
                short[] screenXBuffer,
                short[] screenYBuffer,
                short[] uncalXBuffer,
                short[] uncalYBuffer);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void GetCalibrationPointCount(ref int count);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void StartCalibration();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void GetCalibrationPoint(int index, ref int x, ref int y);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void EnableInternal(bool enable);

        private bool _enabled = false;
    }
}


