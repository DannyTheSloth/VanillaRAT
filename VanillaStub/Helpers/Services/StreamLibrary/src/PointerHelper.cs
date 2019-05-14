using System;

namespace VanillaStub.Helpers.Services.StreamLibrary.src
{
    /// <summary>
    ///     A helper class for pointers
    /// </summary>
    public class PointerHelper
    {
        private int _offset;

        public PointerHelper(IntPtr pointer, int Length)
        {
            TotalLength = Length;
            Pointer = pointer;
        }

        public IntPtr Pointer { get; }

        public int TotalLength { get; }

        public int Offset
        {
            get => _offset;
            set
            {
                if (value < 0)
                    throw new Exception("Offset must be >= 1");

                if (value >= TotalLength)
                    throw new Exception("Offset cannot go outside of the reserved buffer space");

                _offset = value;
            }
        }

        /// <summary>
        ///     Copies data from Source to the current Pointer Offset
        /// </summary>
        public void Copy(IntPtr Source, int SourceOffset, int SourceLength)
        {
            if (CheckBoundries(Offset, SourceLength))
                throw new AccessViolationException("Cannot write outside of the buffer space");
            NativeMethods.memcpy(new IntPtr(Pointer.ToInt64() + Offset), new IntPtr(Source.ToInt64() + SourceOffset),
                (uint) SourceLength);
        }

        private bool CheckBoundries(int offset, int length)
        {
            return offset + length > TotalLength;
        }
    }
}