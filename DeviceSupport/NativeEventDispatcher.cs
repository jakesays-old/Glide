using System;
using System.Runtime.CompilerServices;

namespace Glide.DeviceSupport
{
	public delegate void NativeEventHandler(uint data1, uint data2, DateTime time);

	public class NativeEventDispatcher : IDisposable
	{
		protected NativeEventHandler m_threadSpawn = null;
		protected NativeEventHandler m_callbacks = null;
		protected bool m_disposed = false;
		private object m_NativeEventDispatcher;

		//--//

		[MethodImpl(MethodImplOptions.InternalCall)]
		extern public NativeEventDispatcher(string strDriverName, ulong drvData);

		[MethodImpl(MethodImplOptions.InternalCall)]
		extern public virtual void EnableInterrupt();

		[MethodImpl(MethodImplOptions.InternalCall)]
		extern public virtual void DisableInterrupt();

		[MethodImpl(MethodImplOptions.InternalCall)]
		extern protected virtual void Dispose(bool disposing);

		//--//

		~NativeEventDispatcher()
		{
			Dispose(false);
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public virtual void Dispose()
		{
			if (!m_disposed)
			{
				Dispose(true);

				GC.SuppressFinalize(this);

				m_disposed = true;
			}
		}

		public event NativeEventHandler OnInterrupt
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				if (m_disposed)
				{
					throw new ObjectDisposedException("NativeEventDispatcher");
				}

				NativeEventHandler callbacksOld = m_callbacks;
				NativeEventHandler callbacksNew = (NativeEventHandler) Delegate.Combine(callbacksOld, value);

				try
				{
					m_callbacks = callbacksNew;

					if (callbacksNew != null)
					{
						if (callbacksOld == null)
						{
							EnableInterrupt();
						}

						if (callbacksNew.Equals(value) == false)
						{
							callbacksNew = new NativeEventHandler(this.MultiCastCase);
						}
					}

					m_threadSpawn = callbacksNew;
				}
				catch
				{
					m_callbacks = callbacksOld;

					if (callbacksOld == null)
					{
						DisableInterrupt();
					}

					throw;
				}
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				if (m_disposed)
				{
					throw new ObjectDisposedException("NativeEventDispatcher");
				}

				NativeEventHandler callbacksOld = m_callbacks;
				NativeEventHandler callbacksNew = (NativeEventHandler) Delegate.Remove(callbacksOld, value);

				try
				{
					m_callbacks = (NativeEventHandler) callbacksNew;

					if (callbacksNew == null && callbacksOld != null)
					{
						DisableInterrupt();
					}
				}
				catch
				{
					m_callbacks = callbacksOld;

					throw;
				}
			}
		}

		private void MultiCastCase(uint port, uint state, DateTime time)
		{
			NativeEventHandler callbacks = m_callbacks;

			if (callbacks != null)
			{
				callbacks(port, state, time);
			}
		}
	}
}