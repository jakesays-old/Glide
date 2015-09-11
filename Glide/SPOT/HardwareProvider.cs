using System;
using System.Collections;
using System.Threading;
using System.IO;
using System.Runtime.CompilerServices;

namespace Microsoft.SPOT.Hardware
{
    public class HardwareProvider
    {
        private static HardwareProvider s_hwProvider = null;

        //--//

        public static void Register(HardwareProvider provider)
        {
            s_hwProvider = provider;

        }

        //--//

        public static HardwareProvider HwProvider
        {
            get
            {
                if (s_hwProvider == null)
                {
                    s_hwProvider = new HardwareProvider();
                }

                return s_hwProvider;
            }
        }

        //--//

	    public virtual int GetSerialPortsCount()
        {

            return NativeGetSerialPortsCount();
        }

        public virtual bool SupportsNonStandardBaudRate(int com)
        {
            return NativeSupportsNonStandardBaudRate(com);
        }

        public virtual void GetBaudRateBoundary(int com, out uint MaxBaudRate, out uint MinBaudRate)
        {
            NativeGetBaudRateBoundary(com, out MaxBaudRate, out MinBaudRate);
        }

        public virtual bool IsSupportedBaudRate(int com, ref uint baudrateHz)
        {
            return NativeIsSupportedBaudRate(com, ref baudrateHz);
        }

	    //--//

	    public virtual int GetSpiPortsCount()
        {

            return NativeGetSpiPortsCount();
        }

        //--//


	    public virtual int GetPWMChannelsCount()
        {
            return NativeGetPWMChannelsCount();
        }

	    //--//

        public virtual int GetAnalogChannelsCount()
        {
            return NativeGetAnalogChannelsCount();
        }

	    //--//

        public virtual int GetAnalogOutputChannelsCount()
        {
            return NativeGetAnalogOutputChannelsCount();
        }


        //--//
        
        public virtual int GetPinsCount()
        {
            return NativeGetPinsCount();
        }


        //--//
        public virtual void GetLCDMetrics(out int width, out int height, out int bitsPerPixel, out int orientationDeg)
        {
            NativeGetLCDMetrics(out height, out width, out bitsPerPixel, out orientationDeg);
        }

        //---//

        //---// native calls

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private int NativeGetSerialPortsCount();
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private bool NativeSupportsNonStandardBaudRate(int com);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private void NativeGetBaudRateBoundary(int com, out uint MaxBaudRate, out uint MinBaudRate);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private bool NativeIsSupportedBaudRate(int com, ref uint baudrateHz);


        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private int NativeGetSpiPortsCount();

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private int NativeGetPinsCount();


        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private void NativeGetLCDMetrics(out int height, out int width, out int bitPerPixel, out int orientationDeg);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private int NativeGetPWMChannelsCount();

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private int NativeGetAnalogChannelsCount();
       
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern private int NativeGetAnalogOutputChannelsCount();
    }
}


