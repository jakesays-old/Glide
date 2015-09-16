////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) GHI Electronics, LLC.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Threading;
using Glide.DeviceSupport;

namespace GHI.Glide
{
	/// <summary>
    /// The GlideTouch class handles all touch functionality.
    /// </summary>
    public static class GlideTouch
    {
        /// <summary>
        /// X-axis of the last touch point.
        /// </summary>
        public static int TouchX;

        /// <summary>
        /// Y-axis of the last touch point.
        /// </summary>
        public static int TouchY;

        /// <summary>
        /// Indicates whether all touch events are ignored or not.
        /// </summary>
        public static bool IgnoreAllEvents = false;

        private class TouchConnection : IEventListener
        {
            public void InitializeForEventSource() { }

            private bool wasMoveEvent = false;

            public TouchConnection()
            {
                Calibrated = false;
            }

            public bool OnEvent(BaseEvent baseEvent)
            {
                if (IgnoreAllEvents)
                    return true;

                if (baseEvent is TouchEvent)
                {
                    TouchEvent e = (TouchEvent)baseEvent;

                    if (e.EventMessage == 3)
                    {
                        // If the same position -- do nothing
                        if (wasMoveEvent && e.Touches[0].X == TouchX && e.Touches[0].Y == TouchY)
                        {
                            // Nothing
                        }
                        else
                        {
                            wasMoveEvent = true;
                            TouchX = e.Touches[0].X;
                            TouchY = e.Touches[0].Y;
                            RaiseTouchMoveEvent(this, new TouchEventArgs(e.Touches));
                        }
                    }
                    else if (e.EventMessage == 1)
                    {
                        wasMoveEvent = false;
                        RaiseTouchDownEvent(this, new TouchEventArgs(e.Touches));
                    }
                    else if (e.EventMessage == 2)
                    {
                        wasMoveEvent = false;
                        RaiseTouchUpEvent(this, new TouchEventArgs(e.Touches));
                    }
                }
                else if (baseEvent is GenericEvent)
                {
                    GenericEvent genericEvent = (GenericEvent)baseEvent;
                    if (genericEvent.EventCategory == (byte)EventCategory.Gesture)
                        RaiseTouchGestureEvent(this, new TouchGestureEventArgs((TouchGesture)genericEvent.EventMessage, genericEvent.X, genericEvent.Y, (ushort)genericEvent.EventData, genericEvent.Time));
                }

                return true;
            }
        }

        private static TouchConnection touchConnection;

//        private static ExtendedWeakReference calWeakRef;
        private static class GlideCalibration { }

        /// <summary>
        /// Initializes the touch panel.
        /// </summary>
        public static void Initialize()
        {
            touchConnection = new TouchConnection();
            Touch.Initialize(touchConnection);
            
            TouchCollectorConfiguration.CollectionMode = CollectionMode.InkAndGesture;
            TouchCollectorConfiguration.CollectionMethod = CollectionMethod.Native;
            TouchCollectorConfiguration.SamplingFrequency = 50;

            //calWeakRef = ExtendedWeakReference.RecoverOrCreate(typeof(GlideCalibration), 0, ExtendedWeakReference.c_SurvivePowerdown);
            //calWeakRef.Priority = (Int32)ExtendedWeakReference.PriorityLevel.Important;
            //CalSettings = (CalibrationSettings)calWeakRef.Target;

            //if (CalSettings != null)
            //{
            //    Touch.ActiveTouchPanel.SetCalibration(CalSettings.Points.Length, CalSettings.SX, CalSettings.SY, CalSettings.CX, CalSettings.CY);
            //    Calibrated = true;
            //}
        }

        internal static void SaveCalibration(CalibrationSettings settings)
        {
//            calWeakRef.Target = settings;
        }

        /// <summary>
        /// Raises a touch down event.
        /// </summary>
        /// <param name="sender">Object associated with the event.</param>
        /// <param name="e">Touch event arguments.</param>
        /// <remarks>
        /// Raises a touch down event. This event is handled by the Window currently assigned to Glide.MainWindow.
        /// Once this Window receives a touch down event, it's passed on to it's children.
        /// The first child to handle the event stops propagation to the remaining children.
        /// </remarks>
        public static void RaiseTouchDownEvent(object sender, TouchEventArgs e) { TouchDownEvent(sender, e); }

        /// <summary>
        /// Raises a touch up event.
        /// </summary>
        /// <param name="sender">Object associated with the event.</param>
        /// <param name="e">Touch event arguments.</param>
        /// <remarks>
        /// Raises a touch up event. This event is handled by the Window currently assigned to Glide.MainWindow.
        /// Once this Window receives a touch up event, it's passed on to it's children.
        /// The first child to handle the event stops propagation to the remaining children.
        /// </remarks>
        public static void RaiseTouchUpEvent(object sender, TouchEventArgs e) { TouchUpEvent(sender, e); }

        /// <summary>
        /// Raises a touch move event.
        /// </summary>
        /// <param name="sender">Object associated with the event.</param>
        /// <param name="e">Touch event arguments.</param>
        /// <remarks>
        /// Raises a touch move event. This event is handled by the Window currently assigned to Glide.MainWindow.
        /// Once this Window receives a touch move event, it's passed on to it's children.
        /// The first child to handle the event stops propagation to the remaining children.
        /// </remarks>
        public static void RaiseTouchMoveEvent(object sender, TouchEventArgs e) { TouchMoveEvent(sender, e); }

        /// <summary>
        /// Raises a touch gesture event.
        /// </summary>
        /// <param name="sender">Object associated with the event.</param>
        /// <param name="e">Touch event arguments.</param>
        public static void RaiseTouchGestureEvent(object sender, TouchGestureEventArgs e) { TouchGestureEvent(sender, e); }

        /// <summary>
        /// Touch down event handler.
        /// </summary>
        public static event TouchEventHandler TouchDownEvent = delegate { };

        /// <summary>
        /// Touch up event handler.
        /// </summary>
        public static event TouchEventHandler TouchUpEvent = delegate { };

        /// <summary>
        /// Touch move event handler.
        /// </summary>
        public static event TouchEventHandler TouchMoveEvent = delegate { };

        /// <summary>
        /// Touch gesture event handler.
        /// </summary>
        public static event TouchGestureEventHandler TouchGestureEvent = delegate { };

        /// <summary>
        /// Indicates whether or not the panel has been calibrated.
        /// </summary>
        public static bool Calibrated { get; internal set; }

        /// <summary>
        /// Current calibration settings if set othwerwise null.
        /// </summary>
        public static CalibrationSettings CalSettings;
    }
}
